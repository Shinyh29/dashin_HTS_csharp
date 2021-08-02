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
    public partial class Form1202 : Form, FormRoot, FormOrder
    {
        private FormMain _parent;

        CPTRADELib.CpTdNew5331A _CpTdNew5331A;

        DataTable _TablePrice;
        DataTable _TableCount;

        public Form1202()
        {
            InitializeComponent();
        }

        public void ChangedStockCode(string code, string name)
        {
            TextBoxName.Text = name;
            TextBoxCode.Text = code;
        }

        private void Form1202_Load(object sender, EventArgs e)
        {
            _parent = (FormMain)this.ParentForm;

            _CpTdNew5331A = new CPTRADELib.CpTdNew5331A();
            
            TextBoxPrice.Text = "0";

            _TablePrice = new DataTable();
            _TablePrice.Columns.Add("증거금20%금액");
            _TablePrice.Columns.Add("증거금30%금액");
            _TablePrice.Columns.Add("증거금40%금액");
            _TablePrice.Columns.Add("증거금50%금액");
            _TablePrice.Columns.Add("증거금60%금액");
            _TablePrice.Columns.Add("증거금70%금액");
            _TablePrice.Columns.Add("증거금100%금액");
            _TablePrice.Columns.Add("현금가능금액");

            _TableCount = new DataTable();
            _TableCount.Columns.Add("증거금20%수량");
            _TableCount.Columns.Add("증거금30%수량");
            _TableCount.Columns.Add("증거금40%수량");
            _TableCount.Columns.Add("증거금50%수량");
            _TableCount.Columns.Add("증거금60%수량");
            _TableCount.Columns.Add("증거금70%수량");
            _TableCount.Columns.Add("증거금100%수량");
            _TableCount.Columns.Add("현금가능수량");

            DataGridView1.DataSource = _TablePrice;
            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            DataGridView1.AllowUserToResizeRows = false;
            DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridView1.Refresh();

            DataGridView2.DataSource = _TableCount;
            DataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            DataGridView2.AllowUserToResizeRows = false;
            DataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView2.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridView2.Refresh();

            ComboBoxTrade.SelectedIndex = 0;
            ComboBoxQueryKind.SelectedIndex = 0;

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

            TextBoxName.Text = _parent.stockName;
            TextBoxCode.Text = _parent.stockCode;
        }

        private void Form1202_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void Form1202_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.CloseStockSelector(this);
        }

        private void ComboBoxAccountKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            _parent.ChangedAccountKind(ComboBoxAccountKind.SelectedText);
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

        private void ButtonBuyPrice_Click(object sender, EventArgs e)
        {
            _parent.ShowStockQuote(this);
        }

        private void ButtonQuery_Click(object sender, EventArgs e)
        {
            Request();
        }

        private void ButtonHelp1_Click(object sender, EventArgs e)
        {
            _parent.ShowHelp("1202");
        }

        public void ChangedStockQuote(string price)
        {
            TextBoxPrice.Text = price;
        }
        
        private void Request()
        {
            if (_CpTdNew5331A.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                return;
            }

            if (ComboBoxQueryKind.SelectedIndex == 1)
            {
                if (TextBoxPrice.Text == "0" || TextBoxPrice.Text == "")
                {
                    MessageBox.Show("주문단가를 입력하세요.");
                    return;
                }
            }

            LabelMsg1.Text = "";

            _TablePrice.Clear();
            _TableCount.Clear();

            _CpTdNew5331A.SetInputValue(0, TextBoxAccountNo1.Text + TextBoxAccountNo2.Text);
            _CpTdNew5331A.SetInputValue(1, ComboBoxAccountKind.SelectedItem);
            _CpTdNew5331A.SetInputValue(2, TextBoxCode.Text.ToUpper());
            _CpTdNew5331A.SetInputValue(3, ComboBoxTrade.SelectedItem.ToString().Substring(0, 2));
            _CpTdNew5331A.SetInputValue(4, TextBoxPrice.Text);
            if (CheckBoxCharge.Checked)
                _CpTdNew5331A.SetInputValue(5, "Y");
            else
                _CpTdNew5331A.SetInputValue(5, "N");
            
            if (ComboBoxQueryKind.SelectedIndex == 0)
                _CpTdNew5331A.SetInputValue(6, Encoding.ASCII.GetBytes("1")[0]);
            else
                _CpTdNew5331A.SetInputValue(6, Encoding.ASCII.GetBytes("2")[0]);
            
            int result = _CpTdNew5331A.BlockRequest();

            LabelMsg1.Text = _CpTdNew5331A.GetDibMsg1();
            if (result == 0)
            {
                DataRow rowPrice = _TablePrice.NewRow();

                rowPrice[0] = _CpTdNew5331A.GetHeaderValue(3);
                rowPrice[1] = _CpTdNew5331A.GetHeaderValue(4);
                rowPrice[2] = _CpTdNew5331A.GetHeaderValue(5);
                rowPrice[3] = _CpTdNew5331A.GetHeaderValue(6);
                rowPrice[4] = _CpTdNew5331A.GetHeaderValue(7);
                rowPrice[5] = _CpTdNew5331A.GetHeaderValue(8);
                rowPrice[6] = _CpTdNew5331A.GetHeaderValue(9);
                rowPrice[7] = _CpTdNew5331A.GetHeaderValue(10);

                _TablePrice.Rows.Add(rowPrice);
                DataGridView1.Refresh();

                DataRow rowCount = _TableCount.NewRow();
                rowCount[0] = _CpTdNew5331A.GetHeaderValue(11);
                rowCount[1] = _CpTdNew5331A.GetHeaderValue(12);
                rowCount[2] = _CpTdNew5331A.GetHeaderValue(13);
                rowCount[3] = _CpTdNew5331A.GetHeaderValue(14);
                rowCount[4] = _CpTdNew5331A.GetHeaderValue(15);
                rowCount[5] = _CpTdNew5331A.GetHeaderValue(16);
                rowCount[6] = _CpTdNew5331A.GetHeaderValue(17);
                rowCount[7] = _CpTdNew5331A.GetHeaderValue(18);

                _TableCount.Rows.Add(rowCount);
                DataGridView2.Refresh();
            }
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView1.ClearSelection();
        }

        private void DataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView2.ClearSelection();
        }

        private void ComboBoxQueryKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TextBoxCode.Text.Length >= 7)
                Request();
        }

        private void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView2.SelectedCells.Count > 0)
                _parent.ChangedStockCount(DataGridView2.SelectedCells[0].Value.ToString());
        }

        private void DataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView2.SelectedCells.Count > 0)
            {
                _parent.ChangedStockCount(DataGridView2.SelectedCells[0].Value.ToString());
                this.Close();
            }
        }
    }
}
