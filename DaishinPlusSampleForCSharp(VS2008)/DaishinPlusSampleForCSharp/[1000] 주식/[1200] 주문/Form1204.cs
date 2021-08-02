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

namespace DaishinPlusSampleForCSharp._1000__주식._1200__주문
{
    public partial class Form1204 : Form, FormRoot, FormOrder
    {
        CPTRADELib.CpTdNew9061 _CpTdNew9061;
        CPTRADELib.CpTdNew9064 _CpTdNew9064;
        
        private FormMain _parent;

        DataTable _Table;
        
        public Form1204()
        {
            InitializeComponent();
        }

        public void ChangedStockCode(string code, string name)
        {
            TextBoxName.Text = name;
            TextBoxCode.Text = code;
        }

        private void Form1204_Load(object sender, EventArgs e)
        {
            _parent = (FormMain)this.ParentForm;

            _CpTdNew9061 = new CPTRADELib.CpTdNew9061();
            _CpTdNew9064 = new CPTRADELib.CpTdNew9064();
        
            _Table = new DataTable();
            _Table.Columns.Add("예약번호");
            _Table.Columns.Add("계좌명");
            _Table.Columns.Add("구분");
            _Table.Columns.Add("매매");
            _Table.Columns.Add("종목명");
            _Table.Columns.Add("주문수량");
            _Table.Columns.Add("호가구분");
            _Table.Columns.Add("주문가격");

            DataGridView1.DataSource = _Table;
            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridView1.AllowUserToResizeRows = false;
            DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridView1.Refresh();

            TextBoxName.Text = _parent.stockName;
            TextBoxCode.Text = _parent.stockCode;

            TextBoxBuyCount.Text = "0";
            TextBoxBuyPrice.Text = "0";

            TextBoxSellCount.Text = "0";
            TextBoxSellPrice.Text = "0";
            ComboBoxBuyTrade.SelectedIndex = 0;

            ComboBoxSellTrade.SelectedIndex = 0;

            TextBoxAccountNo1.Text = _parent.accountNo.Substring(0, 3);
            TextBoxAccountNo2.Text = _parent.accountNo.Substring(3, 6);

            int selectedIndex = -1;
            for (int i = 0; i < _parent.arrAccountGoodsStock.Length; i++)
            {
                ComboBoxAccountKind.Items.Add(_parent.arrAccountGoodsStock[i]);
                if (selectedIndex == -1 && _parent.arrAccountGoodsStock[i] == _parent.accountGoodsStock)
                    selectedIndex = i;
            }
            
            if (selectedIndex != -1)
                ComboBoxAccountKind.SelectedIndex = selectedIndex;
        }

        private void Form1204_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.CloseStockSelector(this);
        }

        private void Form1204_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void ComboBoxAccountKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            _parent.ChangedAccountKind(ComboBoxAccountKind.SelectedText);
        }

        private void TextBoxCode_TabIndexChanged(object sender, EventArgs e)
        {
            if (TextBoxCode.Text.Length >= 7)
                TextBoxName.Text = _parent.FindStockName(TextBoxCode.Text.ToUpper());
        }

        private void ButtonSelectCode_Click(object sender, EventArgs e)
        {
            _parent.ShowStockSelector(this);
        }

        private void ButtonBuyDown_Click(object sender, EventArgs e)
        {
            TextBoxBuyCount.Text = (Int32.Parse(TextBoxBuyCount.Text) - 1).ToString();

            if (Int32.Parse(TextBoxBuyCount.Text) <= 0)
                TextBoxBuyCount.Text = "0";
        }

        private void ButtonBuyUp_Click(object sender, EventArgs e)
        {
            TextBoxBuyCount.Text = (Int32.Parse(TextBoxBuyCount.Text) + 1).ToString();
        }

        private void ButtonBuyPrice_Click(object sender, EventArgs e)
        {
            _parent.ShowStockQuote(this);
        }

        private void ButtonOrderBuy_Click(object sender, EventArgs e)
        {
            if (_CpTdNew9061.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                return;
            }

            LabelMsg1.Text = "";
            _Table.Clear();
            DataGridView1.Refresh();

            _CpTdNew9061.SetInputValue(0, TextBoxAccountNo1.Text + TextBoxAccountNo2.Text);
            _CpTdNew9061.SetInputValue(1, ComboBoxAccountKind.SelectedItem);
            _CpTdNew9061.SetInputValue(2, "2");
            _CpTdNew9061.SetInputValue(3, TextBoxCode.Text.ToUpper());
            _CpTdNew9061.SetInputValue(4, TextBoxBuyCount.Text);
            
            string trade = ComboBoxBuyTrade.SelectedItem.ToString().Substring(0, 2);
            _CpTdNew9061.SetInputValue(5, trade);

            if (trade == "03")
                _CpTdNew9061.SetInputValue(6, "0");
            else
                _CpTdNew9061.SetInputValue(6, TextBoxBuyPrice.Text);

            _CpTdNew9061.SetInputValue(7, Encoding.ASCII.GetBytes("1")[0]);

            int result = _CpTdNew9061.BlockRequest();

            LabelMsg1.Text = _CpTdNew9061.GetDibMsg1();
            if (result == 0)
            {
                DataRow row = _Table.NewRow();

                row[0] = _CpTdNew9061.GetHeaderValue(0);
                row[1] = _CpTdNew9061.GetHeaderValue(1);
                row[2] = _CpTdNew9061.GetHeaderValue(2);
                row[3] = _CpTdNew9061.GetHeaderValue(3);
                row[4] = _CpTdNew9061.GetHeaderValue(4);
                row[5] = _CpTdNew9061.GetHeaderValue(5);
                row[6] = _CpTdNew9061.GetHeaderValue(6);
                row[7] = _CpTdNew9061.GetHeaderValue(7);

                _Table.Rows.Add(row);
                DataGridView1.Refresh();

                _parent.ReceivedStockReservedOrder();
            }
        }

        private void ButtonHelpBuy_Click(object sender, EventArgs e)
        {
            _parent.ShowHelp("12041");
        }

        private void ButtonSellDown_Click(object sender, EventArgs e)
        {
            TextBoxSellCount.Text = (Int32.Parse(TextBoxSellCount.Text) - 1).ToString();

            if (Int32.Parse(TextBoxBuyCount.Text) <= 0)
                TextBoxSellCount.Text = "0";
        }

        private void ButtonSellUp_Click(object sender, EventArgs e)
        {
            TextBoxSellCount.Text = (Int32.Parse(TextBoxSellCount.Text) + 1).ToString();
        }

        private void ButtonSellPrice_Click(object sender, EventArgs e)
        {
            _parent.ShowStockQuote(this);
        }

        private void ButtonOrderSell_Click(object sender, EventArgs e)
        {
            if (_CpTdNew9061.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                return;
            }

            LabelMsg1.Text = "";
            _Table.Clear();
            DataGridView1.Refresh();

            _CpTdNew9061.SetInputValue(0, TextBoxAccountNo1.Text + TextBoxAccountNo2.Text);
            _CpTdNew9061.SetInputValue(1, ComboBoxAccountKind.SelectedItem);
            _CpTdNew9061.SetInputValue(2, "1");
            _CpTdNew9061.SetInputValue(3, TextBoxCode.Text.ToUpper());
            _CpTdNew9061.SetInputValue(4, TextBoxSellCount.Text);

            string trade = ComboBoxSellTrade.SelectedItem.ToString().Substring(0, 2);
            _CpTdNew9061.SetInputValue(5, trade);

            if (trade == "03")
                _CpTdNew9061.SetInputValue(6, "0");
            else
                _CpTdNew9061.SetInputValue(6, TextBoxSellPrice.Text);

            _CpTdNew9061.SetInputValue(7, Encoding.ASCII.GetBytes("1")[0]);

            int result = _CpTdNew9061.BlockRequest();

            LabelMsg1.Text = _CpTdNew9061.GetDibMsg1();
            if (result == 0)
            {
                DataRow row = _Table.NewRow();

                row[0] = _CpTdNew9061.GetHeaderValue(0);
                row[1] = _CpTdNew9061.GetHeaderValue(1);
                row[2] = _CpTdNew9061.GetHeaderValue(2);
                row[3] = _CpTdNew9061.GetHeaderValue(3);
                row[4] = _CpTdNew9061.GetHeaderValue(4);
                row[5] = _CpTdNew9061.GetHeaderValue(5);
                row[6] = _CpTdNew9061.GetHeaderValue(6);
                row[7] = _CpTdNew9061.GetHeaderValue(7);

                _Table.Rows.Add(row);
                DataGridView1.Refresh();

                _parent.ReceivedStockReservedOrder();
            }
        }

        private void ButtonHelpSell_Click(object sender, EventArgs e)
        {
            _parent.ShowHelp("12041");
        }

        private void ButtonCancelQuery_Click(object sender, EventArgs e)
        {
            _parent.ShowStockReservedOrderList();
        }

        private void ButtonCancelOrder_Click(object sender, EventArgs e)
        {
            if (_CpTdNew9064.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                return;
            }

            if (TextBoxCancel.Text == "")
            {
                MessageBox.Show("예약번호를 입력하세요");
                return;
            }

            LabelMsg1.Text = "";
            _Table.Clear();
            DataGridView1.Refresh();

            _CpTdNew9064.SetInputValue(0, TextBoxCancel.Text);
            _CpTdNew9064.SetInputValue(1, TextBoxAccountNo1.Text + TextBoxAccountNo2.Text);
            _CpTdNew9064.SetInputValue(2, ComboBoxAccountKind.SelectedItem);
            _CpTdNew9064.SetInputValue(3, TextBoxCode.Text.ToUpper());
            
            int result = _CpTdNew9064.BlockRequest();

            LabelMsg1.Text = _CpTdNew9064.GetDibMsg1();
            if (result == 0)
            {
                DataRow row = _Table.NewRow();

                row[0] = _CpTdNew9064.GetHeaderValue(0);
                row[1] = _CpTdNew9064.GetHeaderValue(1);
                row[2] = _CpTdNew9064.GetHeaderValue(2);
                row[3] = _CpTdNew9064.GetHeaderValue(3);
                row[4] = _CpTdNew9064.GetHeaderValue(4);
                row[5] = _CpTdNew9064.GetHeaderValue(5);
                row[6] = _CpTdNew9064.GetHeaderValue(6);
                row[7] = _CpTdNew9064.GetHeaderValue(7);

                _Table.Rows.Add(row);
                DataGridView1.Refresh();

                _parent.ReceivedStockReservedOrder();
            }
        }

        private void ButtonHelp3_Click(object sender, EventArgs e)
        {
            _parent.ShowHelp("12042");
        }
                
        public void ChangedStockQuote(string price)
        {
            if (TabControl1.SelectedIndex == 0)
                TextBoxBuyPrice.Text = price;
            else if (TabControl1.SelectedIndex == 1)
                TextBoxSellPrice.Text = price;
        }

        public void ChangedStockCount(string count)
        {
            if (TabControl1.SelectedIndex == 0)
                TextBoxBuyCount.Text = count;
            else if (TabControl1.SelectedIndex == 1)
                TextBoxSellCount.Text = count;
        }

        public void ChangedStockReservedOrderNo(string no)
        {
            TextBoxCancel.Text = no;
        }
    
    }
}
