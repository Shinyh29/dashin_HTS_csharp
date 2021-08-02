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
    public partial class Form1104 : Form, FormRoot
    {
        private FormMain _parent;

        private DSCBO1Lib.StockBid _StockBid;
        private DSCBO1Lib.StockCur _StockCur;

        DataTable _timeTable;

        public Form1104()
        {
            InitializeComponent();
        }

        public void ChangedStockCode(string code, string name)
        {
            Unsubscribe(TextBoxCode.Text);

            TextBoxName.Text = name;
            TextBoxCode.Text = code;
        }

        private void Form1104_Load(object sender, EventArgs e)
        {
            _parent = (FormMain)this.ParentForm;

            _StockBid = new DSCBO1Lib.StockBid();
            _StockCur = new DSCBO1Lib.StockCur();
            _StockCur.Received += new DSCBO1Lib._IDibEvents_ReceivedEventHandler(_StockCur_Received);

            _timeTable = new DataTable();
            _timeTable.Columns.Add("시간");
            _timeTable.Columns.Add("현재가");
            _timeTable.Columns.Add("전일대비");
            _timeTable.Columns.Add("매도호가");
            _timeTable.Columns.Add("매수호가");
            _timeTable.Columns.Add("거래량");
            _timeTable.Columns.Add("순간체결량");
            _timeTable.Columns.Add("체결상태");
            _timeTable.Columns.Add("체결강도");
            _timeTable.Columns.Add("장구분");

            DataGridView1.DataSource = _timeTable;
            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridView1.AllowUserToResizeRows = false;
            DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridView1.Refresh();

            ComboBoxMethod.SelectedIndex = 0;

            ButtonNext.Enabled = false;

            TextBoxName.Text = _parent.stockName;
            TextBoxCode.Text = _parent.stockCode;
        }

        private void Form1104_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void Form1104_FormClosed(object sender, FormClosedEventArgs e)
        {
            Unsubscribe(TextBoxCode.Text);

            _parent.CloseStockSelector(this);
        }

        private void Request()
        {
            if (TextBoxCode.Text.Length < 7)
                return;

            LabelMsg1.Text = "";
            LabelMsg2.Text = "";
            LabelContinue.Text = "";

            _timeTable.Clear();
            DataGridView1.Refresh();

            ButtonNext.Enabled = false;

            _StockBid.SetInputValue(0, TextBoxCode.Text.ToUpper());
            _StockBid.SetInputValue(2, 20);
            if (ComboBoxMethod.SelectedIndex == 0)
                _StockBid.SetInputValue(3, Encoding.ASCII.GetBytes("C")[0]);
            else
                _StockBid.SetInputValue(3, Encoding.ASCII.GetBytes("H")[0]);

            JustRequest();
        }

        private void JustRequest()
        {
            if (_StockBid.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                return;
            }

            LabelMsg1.Text = "";
            LabelMsg2.Text = "";
            LabelContinue.Text = "";

            int result = _StockBid.BlockRequest();

            LabelMsg1.Text = _StockBid.GetDibMsg1();
            LabelMsg2.Text = _StockBid.GetDibMsg2();
            if (_StockBid.Continue == 1)
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
                LabelSell.Text = _StockBid.GetHeaderValue(3).ToString();
                LabelBuy.Text = _StockBid.GetHeaderValue(4).ToString();

                for (int i = 0; i < Int32.Parse(_StockBid.GetHeaderValue(2).ToString()); i++)
                {
                    if (_StockBid.GetDataValue(6, i).ToString() != "0")
                    {
                        DataRow row = _timeTable.NewRow();

                        row[0] = ClassUtil.ConvertToDateTime(_StockBid.GetDataValue(9, i).ToString());
                        row[1] = _StockBid.GetDataValue(4, i);
                        row[2] = _StockBid.GetDataValue(1, i);
                        row[3] = _StockBid.GetDataValue(2, i);
                        row[4] = _StockBid.GetDataValue(3, i);
                        row[5] = _StockBid.GetDataValue(5, i);
                        row[6] = _StockBid.GetDataValue(6, i);

                        if (_StockBid.GetDataValue(7, i).ToString() == "1")
                            row[7] = "매수";
                        else
                            row[7] = "매도";

                        row[8] = (Convert.ToDouble(_StockBid.GetDataValue(8, i)) / 100).ToString("0.00%");

                        if (Convert.ToChar(Int32.Parse(_StockBid.GetDataValue(10, i).ToString())) == '1')
                        {
                            row[9] = "동시호가(예상)";
                            row[4] = "* " + _StockBid.GetDataValue(4, i).ToString();
                        }
                        else
                        {
                            row[9] = "장중(체결)";
                            row[4] = _StockBid.GetDataValue(4, i);
                        }

                        _timeTable.Rows.Add(row);
                    }
                }

                DataGridView1.Refresh();
            }

            _StockCur.SetInputValue(0, TextBoxCode.Text.ToUpper());
            _StockCur.Subscribe();
        }

        private void _StockCur_Received()
        {
            if (TextBoxCode.Text.ToUpper() == _StockCur.GetHeaderValue(0).ToString())
            {
                DataRow row = _timeTable.NewRow();

                row[0] = ClassUtil.ConvertToDateTime(_StockCur.GetHeaderValue(18).ToString());
                row[1] = _StockCur.GetHeaderValue(13);
                row[2] = _StockCur.GetHeaderValue(2);

                row[3] = _StockCur.GetHeaderValue(7);
                row[4] = _StockCur.GetHeaderValue(8);
                row[5] = _StockCur.GetHeaderValue(9);
                row[6] = _StockCur.GetHeaderValue(17);
                
                if (ComboBoxMethod.SelectedIndex == 0)              // 체결가 비교
                {
                    if (Convert.ToChar(Int32.Parse(_StockCur.GetHeaderValue(14).ToString())) == '1')
                        row[7] = "매수";
                    else
                        row[7] = "매도";
                    
                    LabelSell.Text = _StockCur.GetHeaderValue(15).ToString();
                    LabelBuy.Text = _StockCur.GetHeaderValue(16).ToString();
                }
                else                                                // 호가비교
                {
                    if (Convert.ToInt32(_StockCur.GetHeaderValue(13).ToString()) <= Convert.ToInt32(_StockCur.GetHeaderValue(8).ToString()))
                        row[7] = "매도";
                    else if (Convert.ToInt32(_StockCur.GetHeaderValue(13).ToString()) >= Convert.ToInt32(_StockCur.GetHeaderValue(7).ToString()))
                        row[7] = "매수";
                    
                    LabelSell.Text = _StockCur.GetHeaderValue(27).ToString();
                    LabelBuy.Text = _StockCur.GetHeaderValue(28).ToString();
                }

                if (Convert.ToInt32(LabelBuy.Text) == 0 && Convert.ToInt32(LabelSell.Text) == 0)
                    row[8] = "0%";
                else if (Convert.ToInt32(LabelSell.Text) == 0)
                    row[8] = "500%";
                else
                    row[8] = (Convert.ToDouble(LabelBuy.Text) / Convert.ToDouble(LabelSell.Text)).ToString("0.00%");

                if (Convert.ToChar(Int32.Parse(_StockCur.GetHeaderValue(19).ToString())) == '1')
                    row[9] = "동시호가(예상)";
                else
                    row[9] = "장중(체결)";

                _timeTable.Rows.InsertAt(row, 0);

                if (CheckBoxTop.Checked)
                {
                    DataGridView1.FirstDisplayedScrollingRowIndex = 0;
                    DataGridView1.ClearSelection();
                    DataGridView1.Rows[0].Selected = true;
                }

                DataGridView1.Refresh();
            }
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView1.ClearSelection();
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 7 || e.ColumnIndex == 9 || e.ColumnIndex == 10)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (e.ColumnIndex == 7 && e.Value.ToString() != "")
                {
                    if (e.Value.ToString() == "매수")
                        e.CellStyle.ForeColor = Color.Red;
                    else
                        e.CellStyle.ForeColor = Color.Blue;
                }
            }

            if (e.ColumnIndex == 2 && e.Value.ToString() != "")
            {
                if (Convert.ToInt32(e.Value.ToString()) > 0)
                    e.CellStyle.ForeColor = Color.Red;
                else if (Convert.ToInt32(e.Value.ToString()) < 0)
                    e.CellStyle.ForeColor = Color.Blue;
                else
                    e.CellStyle.ForeColor = Color.Black;
            }            
        }

        private void Unsubscribe(string code)
        {
            _StockCur.SetInputValue(0, code.ToUpper());
            _StockCur.Unsubscribe();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            _parent.ShowStockSelector(this);
        }

        private void TextBoxCode_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxCode.Text.Length >= 7)
            {
                TextBoxName.Text = _parent.FindStockName(TextBoxCode.Text.ToUpper());
                Request();
            }
        }

        private void ComboBoxMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            Request();
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
    }

}
