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
    public partial class Form1103 : Form, FormRoot
    {
        private FormMain _parent;
        private CPSYSDIBLib.CpSvr7254 _CpSvr7254;

        private DataTable _Table1;
        private DataTable _Table2;
        
        public Form1103()
        {
            InitializeComponent();
        }

        public void ChangedStockCode(string code, string name)
        {
            TextBoxName.Text = name;
            TextBoxCode.Text = code;
        }

        private void Form1103_Load(object sender, EventArgs e)
        {
            _parent = (FormMain)this.ParentForm;

            _CpSvr7254 = new CPSYSDIBLib.CpSvr7254();

            _Table1 = new DataTable();
            _Table2 = new DataTable();

            DataTable table;
            DataGridView grid;

            for (int i = 0; i <= 13; i++)
            {
                if (i == 0)
                {
                    table = _Table1;
                    table.Columns.Add("일자");
                    table.Columns.Add("개인");
                    table.Columns.Add("외국인");
                    table.Columns.Add("기관계");
                    table.Columns.Add("금융투자");
                    table.Columns.Add("보험");
                    table.Columns.Add("투신");
                    table.Columns.Add("은행");
                    table.Columns.Add("기타금융");
                    table.Columns.Add("연기금");
                    table.Columns.Add("기타법인");
                    table.Columns.Add("기타외인");
                    table.Columns.Add("사모펀드");
                    table.Columns.Add("국가지자체");
                    table.Columns.Add("종가");
                    grid = DataGridView1;
                }
                else
                {
                    table = _Table2;
                    table.Columns.Clear();

                    table.Columns.Add("일자");
                    table.Columns.Add("매도수량");
                    table.Columns.Add("매도수량비중");
                    table.Columns.Add("매도금액");
                    table.Columns.Add("매도금액비중");
                    table.Columns.Add("매수수량");
                    table.Columns.Add("매수수량비중");
                    table.Columns.Add("매수금액");
                    table.Columns.Add("매수금액비중");
                    table.Columns.Add("일별순매수수량");
                    table.Columns.Add("일별순매수금액");

                    if (i == 1)
                        grid = DataGridView2;
                    else if (i == 2)
                        grid = DataGridView3;
                    else if (i == 3)
                        grid = DataGridView4;
                    else if (i == 4)
                        grid = DataGridView5;
                    else if (i == 5)
                        grid = DataGridView6;
                    else if (i == 6)
                        grid = DataGridView7;
                    else if (i == 7)
                        grid = DataGridView8;
                    else if (i == 8)
                        grid = DataGridView9;
                    else if (i == 9)
                        grid = DataGridView10;
                    else if (i == 10)
                        grid = DataGridView11;
                    else if (i == 11)
                        grid = DataGridView12;
                    else if (i == 12)
                        grid = DataGridView13;
                    else if (i == 13)
                        grid = DataGridView14;
                    else
                        grid = null;
                }

                grid.DataSource = table;
                grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                grid.AllowUserToResizeRows = false;
                grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                grid.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grid.Refresh();
            }

            TextBoxName.Text = _parent.stockName;
            TextBoxCode.Text = _parent.stockCode;

            DateTimePickerFrom.Enabled = false;
            DateTimePickerTo.Enabled = false;

            ButtonNext.Enabled = false;

            ComboBoxPeriod.SelectedIndex = 6;
            ComboBoxData.SelectedIndex = 0;
            ComboBoxTrade.SelectedIndex = 0;
        }

        private void Form1103_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.CloseStockSelector(this);
        }

        private void Form1103_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
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

        private void ComboBoxPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxPeriod.SelectedIndex == 0)
            {
                DateTimePickerFrom.Enabled = true;
                DateTimePickerTo.Enabled = true;
            }
            else
            {
                DateTimePickerFrom.Enabled = false;
                DateTimePickerTo.Enabled = false;
            }

            if (ComboBoxPeriod.SelectedIndex == 6)
            {
                ComboBoxTrade.Enabled = true;

                if (ComboBoxTrade.SelectedIndex == 0)
                    ComboBoxData.Enabled = true;
                else
                    ComboBoxData.Enabled = false;
            }
            else
            {
                ComboBoxTrade.Enabled = false;
                ComboBoxData.Enabled = true;
            }

            Request();
        }

        private void ComboBoxTrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxTrade.SelectedIndex == 0)
                ComboBoxData.Enabled = true;
            else
                ComboBoxData.Enabled = false;

            Request();
        }

        private void ComboBoxData_SelectedIndexChanged(object sender, EventArgs e)
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
            _parent.ShowHelp("1103");
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Request();
        }
        
        private void RefreshCurrentTab()
        {
            DataTable table;
            DataGridView grid;

            int i = TabControl1.SelectedIndex;

            if (i == 0)
            {
                table = _Table1;

                grid = DataGridView1;
            }
            else
            {
                table = _Table2;

                if (i == 1)
                    grid = DataGridView2;
                else if (i == 2)
                    grid = DataGridView3;
                else if (i == 3)
                    grid = DataGridView4;
                else if (i == 4)
                    grid = DataGridView5;
                else if (i == 5)
                    grid = DataGridView6;
                else if (i == 6)
                    grid = DataGridView7;
                else if (i == 7)
                    grid = DataGridView8;
                else if (i == 8)
                    grid = DataGridView9;
                else if (i == 9)
                    grid = DataGridView10;
                else if (i == 10)
                    grid = DataGridView11;
                else if (i == 11)
                    grid = DataGridView12;
                else if (i == 12)
                    grid = DataGridView13;
                else if (i == 13)
                    grid = DataGridView14;
                else
                    grid = null;
            }

            grid.Refresh();
        }

        private void Request()
        {
            if (_CpSvr7254.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                return;
            }

            LabelMsg1.Text = "";
            LabelMsg2.Text = "";
            LabelContinue.Text = "";

            if (ComboBoxPeriod.SelectedIndex == -1 || ComboBoxData.SelectedIndex == -1 || ComboBoxTrade.SelectedIndex == -1)
                return;

            if (TextBoxCode.Text.Length < 7)
            {
                MessageBox.Show("종목을 선택해주세요");
                return;
            }

            if (ComboBoxPeriod.SelectedIndex.ToString() == "0")
            {
                if (DateTimePickerFrom.Value.ToString("yyyyMMdd").Length < 8)
                {
                    MessageBox.Show("조회 시작 날짜를 선택해주세요");
                    return;
                }

                if (DateTimePickerTo.Value.ToString("yyyyMMdd").Length < 8)
                {
                    MessageBox.Show("조회 끝 날짜를 선택해주세요");
                    return;
                }
            }

            _Table1.Clear();
            _Table2.Clear();
            
            RefreshCurrentTab();

            ButtonNext.Enabled = false;

            _CpSvr7254.SetInputValue(0, TextBoxCode.Text.ToUpper());
            _CpSvr7254.SetInputValue(1, ComboBoxPeriod.SelectedIndex.ToString());
            _CpSvr7254.SetInputValue(2, DateTimePickerFrom.Value.ToString("yyyyMMdd"));
            _CpSvr7254.SetInputValue(3, DateTimePickerTo.Value.ToString("yyyyMMdd"));
            _CpSvr7254.SetInputValue(4, Encoding.ASCII.GetBytes(ComboBoxTrade.SelectedIndex.ToString())[0]);
            _CpSvr7254.SetInputValue(5, TabControl1.SelectedIndex.ToString());
            _CpSvr7254.SetInputValue(6, Encoding.ASCII.GetBytes((ComboBoxData.SelectedIndex + 1).ToString())[0]);

            Trace.TraceInformation("****************** RQ ******************");
            Trace.TraceInformation("기간 : " + ComboBoxPeriod.SelectedIndex.ToString());
            Trace.TraceInformation("From : " + DateTimePickerFrom.Value.ToString("yyyyMMdd"));
            Trace.TraceInformation("To : " + DateTimePickerTo.Value.ToString("yyyyMMdd"));
            Trace.TraceInformation("투자자 : " + TabControl1.SelectedIndex.ToString());
            Trace.TraceInformation("데이터구분 : " + (ComboBoxData.SelectedIndex + 1).ToString());
            Trace.TraceInformation("매매비중 : " + ComboBoxTrade.SelectedIndex.ToString());

            JustRequest();
        }

        private void JustRequest()
        {
            if (_CpSvr7254.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                return;
            }

            int result = _CpSvr7254.BlockRequest();

            LabelMsg1.Text = _CpSvr7254.GetDibMsg1();
            LabelMsg2.Text = _CpSvr7254.GetDibMsg2();
            if (_CpSvr7254.Continue == 1)
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
                DataTable table;

                if (TabControl1.SelectedIndex == 0)
                    table = _Table1;
                else
                    table = _Table2;

                string fromDate = _CpSvr7254.GetHeaderValue(2).ToString();
                string toDate = _CpSvr7254.GetHeaderValue(3).ToString();

                if (fromDate.Length >= 8)
                    DateTimePickerFrom.Value = new DateTime(Int32.Parse(fromDate.Substring(0, 4)), Int32.Parse(fromDate.Substring(4, 2)), Int32.Parse(fromDate.Substring(6, 2)));

                if (toDate.Length >= 8)
                    DateTimePickerTo.Value = new DateTime(Int32.Parse(toDate.Substring(0, 4)), Int32.Parse(toDate.Substring(4, 2)), Int32.Parse(toDate.Substring(6, 2)));

                for (int i = 0; i < Int32.Parse(_CpSvr7254.GetHeaderValue(1).ToString()); i++)
                {
                    DataRow row = table.NewRow();

                    for (int j = 0; j < 15; j++)
                    {
                        if (j == 15 && table.Equals(_Table1) == true)
                            break;
                        else if (j == 11 && table.Equals(_Table2) == true)
                            break;
                        else if (j == 0)
                            row[j] = ClassUtil.ConvertToDateTime(_CpSvr7254.GetDataValue(j, i).ToString());
                        else
                            row[j] = _CpSvr7254.GetDataValue(j, i);
                    }

                    table.Rows.Add(row);
                }

                RefreshCurrentTab();
            }
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView1.ClearSelection();
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
