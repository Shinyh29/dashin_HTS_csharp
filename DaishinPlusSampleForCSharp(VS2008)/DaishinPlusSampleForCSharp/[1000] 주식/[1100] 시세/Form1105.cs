using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DaishinPlusSampleForCSharp.Common;
using System.Diagnostics;

namespace DaishinPlusSampleForCSharp._1000__주식._1100__시세
{
    public partial class Form1105 : Form, FormRoot
    {
        private FormMain _parent;

        private DSCBO1Lib.StockWeek _StockWeek;
        private DSCBO1Lib.StockCur _StockCur;

        private DataTable _DayTable;

        public Form1105()
        {
            InitializeComponent();
        }

        public void ChangedStockCode(string code, string name)
        {
            Unsubscribe(TextBoxCode.Text);

            TextBoxName.Text = name;
            TextBoxCode.Text = code;
        }

        private void Form1105_Load(object sender, EventArgs e)
        {
            _parent = (FormMain)this.ParentForm;

            _StockWeek = new DSCBO1Lib.StockWeek();
            _StockCur = new DSCBO1Lib.StockCur();
            _StockCur.Received += new DSCBO1Lib._IDibEvents_ReceivedEventHandler(_StockCur_Received);

            _DayTable = new DataTable();
            _DayTable.Columns.Add("일자");
            _DayTable.Columns.Add("시가");
            _DayTable.Columns.Add("고가");
            _DayTable.Columns.Add("저가");
            _DayTable.Columns.Add("종가");
            _DayTable.Columns.Add("전일대비");
            _DayTable.Columns.Add("누적거래량");
            _DayTable.Columns.Add("외인보유");
            _DayTable.Columns.Add("외인전일대비");
            _DayTable.Columns.Add("외인비중");
            _DayTable.Columns.Add("등락률");
            _DayTable.Columns.Add("대비상태");
            _DayTable.Columns.Add("기관순매수");

            DataGridView1.DataSource = _DayTable;
            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridView1.AllowUserToResizeRows = false;
            DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridView1.Refresh();

            ButtonNext.Enabled = false;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         

            TextBoxName.Text = _parent.stockName;
            TextBoxCode.Text = _parent.stockCode;
        }

        private void Form1105_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void Form1105_FormClosed(object sender, FormClosedEventArgs e)
        {
            Unsubscribe(TextBoxCode.Text);

            _parent.CloseStockSelector(this);
        }

        private void TextBoxCode_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxCode.Text.Length >= 7)
            {
                TextBoxName.Text = _parent.FindStockName(TextBoxCode.Text.ToUpper());
                Request();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            _parent.ShowStockSelector(this);
        }

        private void ButtonQuery_Click(object sender, EventArgs e)
        {
            Request();
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            JustRequest();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            _parent.ShowHelp("1104");
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 11)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (e.ColumnIndex == 11 && e.Value.ToString() != "")
                {
                    if (e.Value.ToString() == "상한" || e.Value.ToString() == "상승" || e.Value.ToString() == "기세상한" || e.Value.ToString() == "기세상승")
                        e.CellStyle.ForeColor = Color.Red;
                    else if (e.Value.ToString() == "보합")
                        e.CellStyle.ForeColor = Color.Black;
                    else
                        e.CellStyle.ForeColor = Color.Blue;
                }
            }

            if (Int32.Parse(DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()) > 0)
                DataGridView1.Rows[e.RowIndex].Cells[4].Style.ForeColor = Color.Red;
            else if (Int32.Parse(DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()) < 0)
                DataGridView1.Rows[e.RowIndex].Cells[4].Style.ForeColor = Color.Blue;
            else
                DataGridView1.Rows[e.RowIndex].Cells[4].Style.ForeColor = Color.Black;
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView1.ClearSelection();
        }

        private void Request()
        {
            if (_StockWeek.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                return;
            }

            LabelMsg1.Text = "";
            LabelMsg2.Text = "";
            LabelContinue.Text = "";

            _DayTable.Clear();
            DataGridView1.Refresh();

            ButtonNext.Enabled = false;

            _StockWeek.SetInputValue(0, TextBoxCode.Text.ToUpper());

            JustRequest();
        }

        private void JustRequest()
        {
            if (_StockWeek.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                return;
            }

            LabelMsg1.Text = "";
            LabelMsg2.Text = "";
            LabelContinue.Text = "";

            int result = _StockWeek.BlockRequest();

            LabelMsg1.Text = _StockWeek.GetDibMsg1();
            LabelMsg2.Text = _StockWeek.GetDibMsg2();
            if (_StockWeek.Continue == 1)
            {
                LabelContinue.Text = "연속 데이터 있음";
                ButtonNext.Enabled = true;
            }
            else
            {
                LabelContinue.Text = "연속 데이터 없음";
                ButtonNext.Enabled = false;
            }

            if (result == 0)
            {
                for (int i = 0; i< Int32.Parse(_StockWeek.GetHeaderValue(1).ToString()); i++)
                {
                    DataRow row = _DayTable.NewRow();

                    for (int j = 0; j < 13; j++)
                    {
                        if (j == 11)
                        {
                            if (Convert.ToChar(Int32.Parse(_StockWeek.GetDataValue(j, i).ToString())) == '1')
                                row[j] = "상한";
                            else if (Convert.ToChar(Int32.Parse(_StockWeek.GetDataValue(j, i).ToString())) == '2')
                                row[j] = "상승";
                            else if (Convert.ToChar(Int32.Parse(_StockWeek.GetDataValue(j, i).ToString())) == '3')
                                row[j] = "보합";
                            else if (Convert.ToChar(Int32.Parse(_StockWeek.GetDataValue(j, i).ToString())) == '4')
                                row[j] = "하한";
                            else if (Convert.ToChar(Int32.Parse(_StockWeek.GetDataValue(j, i).ToString())) == '5')
                                row[j] = "하락";
                            else if (Convert.ToChar(Int32.Parse(_StockWeek.GetDataValue(j, i).ToString())) == '6')
                                row[j] = "기세상한";
                            else if (Convert.ToChar(Int32.Parse(_StockWeek.GetDataValue(j, i).ToString())) == '7')
                                row[j] = "기세상승";
                            else if (Convert.ToChar(Int32.Parse(_StockWeek.GetDataValue(j, i).ToString())) == '8')
                                row[j] = "기세하한";
                            else if (Convert.ToChar(Int32.Parse(_StockWeek.GetDataValue(j, i).ToString())) == '9')
                                row[j] = "기세하락";
                        }
                        else if (j == 0)
                        {
                            row[j] = ClassUtil.ConvertToDateTime(_StockWeek.GetDataValue(j, i).ToString());
                        }
                        else
                        {
                            row[j] = _StockWeek.GetDataValue(j, i);
                        }
                    }

                    _DayTable.Rows.Add(row);
                }

                DataGridView1.Refresh();

                _StockCur.SetInputValue(0, TextBoxCode.Text.ToUpper());
                _StockCur.Subscribe();
            }
        }
        
        private void Unsubscribe(string code)
        {
            _StockCur.SetInputValue(0, code.ToUpper());
            _StockCur.Unsubscribe();
        }

        private void _StockCur_Received()
        {
            if (TextBoxCode.Text.ToUpper() == _StockCur.GetHeaderValue(0).ToString())
            {
                if (_DayTable.Rows.Count <= 0)
                    return;

                DataRow row = _DayTable.Rows[0];

                row[1] = _StockCur.GetHeaderValue(4);
                row[2] = _StockCur.GetHeaderValue(5);
                row[3] = _StockCur.GetHeaderValue(6);
                row[4] = _StockCur.GetHeaderValue(13);
                row[5] = _StockCur.GetHeaderValue(2);
                row[6] = _StockCur.GetHeaderValue(9);

                DataGridView1.Refresh();
            }
        }
    }
}
