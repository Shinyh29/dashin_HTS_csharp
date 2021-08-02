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

namespace DaishinPlusSampleForCSharp._1000__주식._1400__잔고
{
    public partial class Form1402 : Form, FormTrade
    {
        private FormMain _parent;
        private DataTable _Table1;
        private DataTable _Table2;
        CPTRADELib.CpTd0732 _CpTd0732;
        
        public Form1402()
        {
            InitializeComponent();
        }

        public void ReceivedStockTrade()
        {
        }

        private void Form1402_Load(object sender, EventArgs e)
        {
            _parent = (FormMain)this.ParentForm;

            _CpTd0732 = new CPTRADELib.CpTd0732();

            _Table1 = new DataTable();
            _Table1.Columns.Add("장내현금매도");
            _Table1.Columns.Add("장내현금매수");
            _Table1.Columns.Add("현금수수료");
            _Table1.Columns.Add("현금제세금");
            _Table1.Columns.Add("현금정산금");
            _Table1.Columns.Add("현금거래세");

            _Table2 = new DataTable();
            _Table2.Columns.Add("장내현금매도");
            _Table2.Columns.Add("장내현금매수");
            _Table2.Columns.Add("현금수수료");
            _Table2.Columns.Add("현금제세금");
            _Table2.Columns.Add("현금정산금");
            _Table2.Columns.Add("현금거래세");

            DataGridView1.DataSource = _Table1;
            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridView1.AllowUserToResizeRows = false;
            DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridView1.Refresh();

            DataGridView2.DataSource = _Table2;
            DataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridView2.AllowUserToResizeRows = false;
            DataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView2.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridView2.Refresh();

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

        private void Form1402_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView1.ClearSelection();
        }

        private void DataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView2.ClearSelection();
        }

        private void ButtonQuery_Click(object sender, EventArgs e)
        {
            Request();
        }

        private void ButtonHelp1_Click(object sender, EventArgs e)
        {
            _parent.ShowHelp("1402");
        }

        private void ComboBoxAccountKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            _parent.ChangedAccountKind(ComboBoxAccountKind.SelectedText);
            Request();
        }

        private void Request()
        {
            if (_CpTd0732.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                return;
            }

            _Table1.Clear();
            DataGridView1.Refresh();

            _Table2.Clear();
            DataGridView2.Refresh();

            _CpTd0732.SetInputValue(0, TextBoxAccountNo1.Text + TextBoxAccountNo2.Text);
            _CpTd0732.SetInputValue(1, ComboBoxAccountKind.SelectedItem);

            LabelMsg1.Text = "";

            TextBoxTotal.Text = "";
            TextBoxNot.Text = "";
            LabelD1.Text = "";
            LabelD2.Text = "";
            TextBoxD1.Text = "";
            TextBoxD2.Text = "";

            int result = _CpTd0732.BlockRequest();

            LabelMsg1.Text = _CpTd0732.GetDibMsg1();

            if (result == 0)
            {
                TextBoxTotal.Text = _CpTd0732.GetHeaderValue(3).ToString();
                TextBoxNot.Text = _CpTd0732.GetHeaderValue(4).ToString();
                LabelD1.Text = ClassUtil.ConvertToDateTime(_CpTd0732.GetHeaderValue(63).ToString());
                LabelD2.Text = ClassUtil.ConvertToDateTime(_CpTd0732.GetHeaderValue(65).ToString());
                TextBoxD1.Text = _CpTd0732.GetHeaderValue(64).ToString();
                TextBoxD2.Text = _CpTd0732.GetHeaderValue(66).ToString();

                DataRow row1 = _Table1.NewRow();

                row1[0] = _CpTd0732.GetHeaderValue(5);
                row1[1] = _CpTd0732.GetHeaderValue(6);
                row1[2] = _CpTd0732.GetHeaderValue(11);
                row1[3] = _CpTd0732.GetHeaderValue(12);
                row1[4] = _CpTd0732.GetHeaderValue(13);
                row1[5] = _CpTd0732.GetHeaderValue(31);

                _Table1.Rows.Add(row1);
                
                DataGridView1.Refresh();

                DataRow row2 = _Table2.NewRow();

                row2[0] = _CpTd0732.GetHeaderValue(34);
                row2[1] = _CpTd0732.GetHeaderValue(35);
                row2[2] = _CpTd0732.GetHeaderValue(40);
                row2[3] = _CpTd0732.GetHeaderValue(41);
                row2[4] = _CpTd0732.GetHeaderValue(42);
                row2[5] = _CpTd0732.GetHeaderValue(60);

                _Table2.Rows.Add(row2);

                DataGridView2.Refresh();
            }
        }
    }
}
