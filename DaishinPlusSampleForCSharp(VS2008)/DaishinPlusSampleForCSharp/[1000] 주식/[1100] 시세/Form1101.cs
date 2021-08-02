using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using CPUTILLib;
using DaishinPlusSampleForCSharp.Common;

namespace DaishinPlusSampleForCSharp._1000__주식._1100__시세
{
    public partial class Form1101 : Form, FormRoot
    {
        private FormMain _parent;
        private DataTable _stockTable;

        private DSCBO1Lib.StockMst _stockMst;
        private DSCBO1Lib.StockCur _stockCur;

        public Form1101()
        {
            InitializeComponent();
        }

        private void Form1101_Load(object sender, EventArgs e)
        {
            _parent = (FormMain)this.ParentForm;

            _stockMst = new DSCBO1Lib.StockMst();
            _stockCur = new DSCBO1Lib.StockCur();

            _stockMst.Received += new DSCBO1Lib._IDibEvents_ReceivedEventHandler(_stockMst_Received);
            _stockCur.Received += new DSCBO1Lib._IDibEvents_ReceivedEventHandler(_stockCur_Received);

            _stockTable = new DataTable();
            _stockTable.Columns.Add("시간");
            _stockTable.Columns.Add("현재가");
            _stockTable.Columns.Add("전일대비");
            _stockTable.Columns.Add("시가");
            _stockTable.Columns.Add("고가");
            _stockTable.Columns.Add("저가");
            _stockTable.Columns.Add("거래량");
            _stockTable.Columns.Add("거래대금");
            _stockTable.Rows.Add("0", "0", "0", "0", "0", "0", "0", "0");

            DataGridView1.DataSource = _stockTable;
            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridView1.AllowUserToResizeRows = false;
            DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridView1.Refresh();

            TextBoxName.Text = _parent.stockName;
            TextBoxCode.Text = _parent.stockCode;
        }

        private void Form1101_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void Form1101_FormClosed(object sender, FormClosedEventArgs e)
        {
            Unsubscribe(TextBoxCode.Text);

            _parent.CloseStockSelector(this);

            this.Dispose();
        }

        private void ButtonRQ_Click(object sender, EventArgs e)
        {
            Request();
        }

        private void Request()
        {
            if (_stockMst.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                return;
            }

            if (TextBoxCode.Text.Length < 7)
            {
                MessageBox.Show("종목을 선택해주세요");
                return;
            }

            LabelMsg1.Text = "";
            LabelMsg2.Text = "";
        
            _stockMst.SetInputValue(0, TextBoxCode.Text.ToUpper());
            _stockMst.Request();
        }

        private void _stockMst_Received()
        {
            LabelMsg1.Text = _stockMst.GetDibMsg1();
            LabelMsg2.Text = _stockMst.GetDibMsg2();
            
            _stockTable.Clear();
            _stockTable.Rows.Add(ClassUtil.ConvertToDateTime(_stockMst.GetHeaderValue(4).ToString()), _stockMst.GetHeaderValue(11), _stockMst.GetHeaderValue(12), _stockMst.GetHeaderValue(13), _stockMst.GetHeaderValue(14), _stockMst.GetHeaderValue(15), _stockMst.GetHeaderValue(18), _stockMst.GetHeaderValue(19));

            DataGridView1.Refresh();

            ButtonReal.Text = "실시간(수신중)";
            _stockCur.SetInputValue(0, TextBoxCode.Text.ToUpper());
            _stockCur.Subscribe();
        }

        private void _stockCur_Received()
        {
            if (TextBoxCode.Text.ToUpper() == _stockCur.GetHeaderValue(0).ToString().ToUpper())
            {
                _stockTable.Rows[0][0] = ClassUtil.ConvertToDateTime(_stockCur.GetHeaderValue(3).ToString());
                _stockTable.Rows[0][1] = _stockCur.GetHeaderValue(13);
                _stockTable.Rows[0][2] = _stockCur.GetHeaderValue(2);
                _stockTable.Rows[0][4] = _stockCur.GetHeaderValue(5);
                _stockTable.Rows[0][5] = _stockCur.GetHeaderValue(6);

                CPE_MARKET_KIND market = _parent.GetStockMarketKind(TextBoxCode.Text);

                _stockTable.Rows[0][6] = _stockCur.GetHeaderValue(9);

                if (market == CPE_MARKET_KIND.CPC_MARKET_KOSPI)
                    _stockTable.Rows[0][7] = Convert.ToString(Convert.ToDouble(_stockCur.GetHeaderValue(10)) * 10000);
                else if (market == CPE_MARKET_KIND.CPC_MARKET_KOSDAQ || market == CPE_MARKET_KIND.CPC_MARKET_FREEBOARD)
                    _stockTable.Rows[0][7] = Convert.ToString(Convert.ToDouble(_stockCur.GetHeaderValue(10)) * 1000);
                else
                    _stockTable.Rows[0][7] = _stockCur.GetHeaderValue(10);
            }
        }

        private void ButtonSelectCode_Click(object sender, EventArgs e)
        {
            _parent.ShowStockSelector(this);
        }

        public void ChangedStockCode(string code, string name)
        {
            Unsubscribe(TextBoxCode.Text);

            TextBoxCode.Text = code;
            TextBoxName.Text = name;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            _parent.ShowHelp("11011");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            _parent.ShowHelp("11012");
        }

        private void Unsubscribe(string code)
        {
            _stockCur.SetInputValue(0, code.ToUpper());
            _stockCur.Unsubscribe();
        }

        private void ButtonReal_Click(object sender, EventArgs e)
        {
            _stockCur.SetInputValue(0, TextBoxCode.Text.ToUpper());

            if (ButtonReal.Text == "실시간(수신중)")
            {
                ButtonReal.Text = "실시간(시작)";
                _stockCur.Unsubscribe();
            }
            else
            {
                ButtonReal.Text = "실시간(수신중)";
                _stockCur.Subscribe();
            }
        }

        private void TextBoxCode_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxCode.Text.Length >= 7)
            {
                TextBoxName.Text = _parent.FindStockName(TextBoxCode.Text.ToUpper());
                Request();
            }
        }
    }
}
