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
    public partial class Form1106 : Form, FormRoot
    {
        private FormMain _parent;

        private DSCBO1Lib.StockJpbid2 _StockJpbid2 ;
        private DSCBO1Lib.StockJpbid _StockJpbid;

        private DataTable _QuoteTable;

        private object _sender;

        public Form1106()
        {
            InitializeComponent();
        }

        public void ChangedStockCode(string code, string name)
        {
            Unsubscribe(TextBoxCode.Text);

            TextBoxName.Text = name;
            TextBoxCode.Text = code;
        }

        private void Form1106_Load(object sender, EventArgs e)
        {
            _parent = (FormMain)this.ParentForm;

            _StockJpbid2 = new DSCBO1Lib.StockJpbid2();
            _StockJpbid = new DSCBO1Lib.StockJpbid();;
            _StockJpbid.Received += new DSCBO1Lib._IDibEvents_ReceivedEventHandler(StockJpbid_Received);

            _QuoteTable = new DataTable();
            _QuoteTable.Columns.Add("매도잔량");
            _QuoteTable.Columns.Add("호가");
            _QuoteTable.Columns.Add("매수잔량");

            for (int i = 0; i < 20; i++)
                _QuoteTable.Rows.Add("", "", "");

            DataGridView1.DataSource = _QuoteTable;
            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView1.AllowUserToResizeRows = false;
            DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridView1.Refresh();

            TextBoxName.Text = _parent.stockName;
            TextBoxCode.Text = _parent.stockCode;
        }
    
        public void SetSender(object sender)
        {
            _sender = sender;
        }

        private void Form1106_FormClosed(object sender, FormClosedEventArgs e)
        {
            Unsubscribe(TextBoxCode.Text);

            _parent.CloseStockSelector(this);
        }

        private void Form1106_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView1.ClearSelection();
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= 9 && (e.ColumnIndex == 0 || e.ColumnIndex == 1))
                DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(217, 236, 255);
            else if (e.RowIndex >= 10 && e.RowIndex <= 19 && (e.ColumnIndex == 1 || e.ColumnIndex == 2))
                DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(255, 230, 230);

            if (e.ColumnIndex == 1)
                DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            else
                DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void TextBoxCode_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxCode.Text.Length >= 7)
            {
                TextBoxName.Text = _parent.FindStockName(TextBoxCode.Text.ToUpper());
                Request();
            }
        }

        private void ButtonSelectCode_Click(object sender, EventArgs e)
        {
            _parent.ShowStockSelector(this);
        }

        private void ButtonRQ_Click(object sender, EventArgs e)
        {
            Request();
        }

        private void ButtonHelpRQ_Click(object sender, EventArgs e)
        {
            _parent.ShowHelp("11061");
        }
        
        private void ButtonHelpSB_Click(object sender, EventArgs e)
        {
            _parent.ShowHelp("11062");
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = DataGridView1.SelectedRows[0];
                _parent.ChangedStockQuote(row.Cells["호가"].Value.ToString());
            }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = DataGridView1.SelectedRows[0];
                _parent.ChangedStockQuote(row.Cells["호가"].Value.ToString());
                this.Close();
            }
        }

        private void Unsubscribe(string code)
        {
            _StockJpbid.SetInputValue(0, code.ToUpper());
            _StockJpbid.Unsubscribe();
        }

        private void Request()
        {
            if (_StockJpbid2.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                return;
            }

            if (TextBoxCode.Text.Length < 7)
            {
                MessageBox.Show("종목을 선택해주세요");
                return;
            }

            _QuoteTable.Clear();
            for (int i = 0; i < 20; i++)
                _QuoteTable.Rows.Add("", "", "");

            DataGridView1.Refresh();

            _StockJpbid2.SetInputValue(0, TextBoxCode.Text.ToUpper());

            int result = _StockJpbid2.BlockRequest();

            if (result == 0)
            {
                LabelTime.Text = ClassUtil.ConvertToDateTime(_StockJpbid2.GetHeaderValue(3).ToString());
                LabelSell.Text = _StockJpbid2.GetHeaderValue(4).ToString();
                LabelBuy.Text = _StockJpbid2.GetHeaderValue(6).ToString();

                int IndexSell = 9;
                int IndexBuy = 10;

                for (int i = 0; i < Int32.Parse(_StockJpbid2.GetHeaderValue(1).ToString()); i++)
                {
                    _QuoteTable.Rows[IndexSell]["호가"] = _StockJpbid2.GetDataValue(0, i);
                    _QuoteTable.Rows[IndexBuy]["호가"] = _StockJpbid2.GetDataValue(1, i);

                    _QuoteTable.Rows[IndexSell]["매도잔량"] = _StockJpbid2.GetDataValue(2, i);
                    _QuoteTable.Rows[IndexBuy]["매수잔량"] = _StockJpbid2.GetDataValue(3, i);

                    IndexSell -= 1;
                    IndexBuy += 1;
                }

                DataGridView1.Refresh();

                _StockJpbid.SetInputValue(0, TextBoxCode.Text.ToUpper());
                _StockJpbid.SubscribeLatest();
            }
        }

        private void StockJpbid_Received()
        {
            if (TextBoxCode.Text.ToUpper() != _StockJpbid.GetHeaderValue(0).ToString())
                return;

            LabelTime.Text = ClassUtil.ConvertToDateTime(_StockJpbid.GetHeaderValue(1).ToString());
            LabelSell.Text = _StockJpbid.GetHeaderValue(23).ToString();
            LabelBuy.Text = _StockJpbid.GetHeaderValue(24).ToString();

            _QuoteTable.Rows[9]["호가"] = _StockJpbid.GetHeaderValue(3);
            _QuoteTable.Rows[10]["호가"] = _StockJpbid.GetHeaderValue(4);
            _QuoteTable.Rows[9]["매도잔량"] = _StockJpbid.GetHeaderValue(5);
            _QuoteTable.Rows[10]["매수잔량"] = _StockJpbid.GetHeaderValue(6);

            _QuoteTable.Rows[8]["호가"] = _StockJpbid.GetHeaderValue(7);
            _QuoteTable.Rows[11]["호가"] = _StockJpbid.GetHeaderValue(8);
            _QuoteTable.Rows[8]["매도잔량"] = _StockJpbid.GetHeaderValue(9);
            _QuoteTable.Rows[11]["매수잔량"] = _StockJpbid.GetHeaderValue(10);

            _QuoteTable.Rows[7]["호가"] = _StockJpbid.GetHeaderValue(11);
            _QuoteTable.Rows[12]["호가"] = _StockJpbid.GetHeaderValue(12);
            _QuoteTable.Rows[7]["매도잔량"] = _StockJpbid.GetHeaderValue(13);
            _QuoteTable.Rows[12]["매수잔량"] = _StockJpbid.GetHeaderValue(14);

            _QuoteTable.Rows[6]["호가"] = _StockJpbid.GetHeaderValue(15);
            _QuoteTable.Rows[13]["호가"] = _StockJpbid.GetHeaderValue(16);
            _QuoteTable.Rows[6]["매도잔량"] = _StockJpbid.GetHeaderValue(17);
            _QuoteTable.Rows[13]["매수잔량"] = _StockJpbid.GetHeaderValue(18);

            _QuoteTable.Rows[5]["호가"] = _StockJpbid.GetHeaderValue(19);
            _QuoteTable.Rows[14]["호가"] = _StockJpbid.GetHeaderValue(20);
            _QuoteTable.Rows[5]["매도잔량"] = _StockJpbid.GetHeaderValue(21);
            _QuoteTable.Rows[14]["매수잔량"] = _StockJpbid.GetHeaderValue(22);

            _QuoteTable.Rows[4]["호가"] = _StockJpbid.GetHeaderValue(27);
            _QuoteTable.Rows[15]["호가"] = _StockJpbid.GetHeaderValue(28);
            _QuoteTable.Rows[4]["매도잔량"] = _StockJpbid.GetHeaderValue(29);
            _QuoteTable.Rows[15]["매수잔량"] = _StockJpbid.GetHeaderValue(30);

            _QuoteTable.Rows[3]["호가"] = _StockJpbid.GetHeaderValue(31);
            _QuoteTable.Rows[16]["호가"] = _StockJpbid.GetHeaderValue(32);
            _QuoteTable.Rows[3]["매도잔량"] = _StockJpbid.GetHeaderValue(33);
            _QuoteTable.Rows[16]["매수잔량"] = _StockJpbid.GetHeaderValue(34);

            _QuoteTable.Rows[2]["호가"] = _StockJpbid.GetHeaderValue(35);
            _QuoteTable.Rows[17]["호가"] = _StockJpbid.GetHeaderValue(36);
            _QuoteTable.Rows[2]["매도잔량"] = _StockJpbid.GetHeaderValue(37);
            _QuoteTable.Rows[17]["매수잔량"] = _StockJpbid.GetHeaderValue(38);

            _QuoteTable.Rows[1]["호가"] = _StockJpbid.GetHeaderValue(39);
            _QuoteTable.Rows[18]["호가"] = _StockJpbid.GetHeaderValue(40);
            _QuoteTable.Rows[1]["매도잔량"] = _StockJpbid.GetHeaderValue(41);
            _QuoteTable.Rows[18]["매수잔량"] = _StockJpbid.GetHeaderValue(42);

            _QuoteTable.Rows[0]["호가"] = _StockJpbid.GetHeaderValue(43);
            _QuoteTable.Rows[19]["호가"] = _StockJpbid.GetHeaderValue(44);
            _QuoteTable.Rows[0]["매도잔량"] = _StockJpbid.GetHeaderValue(45);
            _QuoteTable.Rows[19]["매수잔량"] = _StockJpbid.GetHeaderValue(46);
        }
    }
}
