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
    public partial class Form1401 : Form, FormTrade
    {
        private FormMain _parent;
        private DataTable _Table;
        CPTRADELib.CpTd6033 _CpTd6033;
        
        public Form1401()
        {
            InitializeComponent();
        }

        public void ReceivedStockTrade()
        {
            Request();
        }

        private void Form1401_Load(object sender, EventArgs e)
        {
            _parent = (FormMain)this.ParentForm;

            _CpTd6033 = new CPTRADELib.CpTd6033();

            ButtonNext.Enabled = false;

            _Table = new DataTable();
            _Table.Columns.Add("종목명");
            _Table.Columns.Add("결제잔고수량");
            _Table.Columns.Add("결제장부단가");
            _Table.Columns.Add("체결잔고수량");
            _Table.Columns.Add("평가금액");
            _Table.Columns.Add("평가손익");
            _Table.Columns.Add("수익률");
            _Table.Columns.Add("매도가능수량");
            _Table.Columns.Add("체결장부단가");
            _Table.Columns.Add("손익단가");

            DataGridView1.DataSource = _Table;
            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridView1.AllowUserToResizeRows = false;
            DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridView1.Refresh();

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

        private void Form1401_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void ComboBoxAccountKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            _parent.ChangedAccountKind(ComboBoxAccountKind.SelectedText);
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

        private void ButtonHelp1_Click(object sender, EventArgs e)
        {
            _parent.ShowHelp("1401");
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView1.ClearSelection();
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.Value.ToString() != "")
            {
                double percent = Convert.ToDouble(e.Value.ToString().Replace("%", ""));

                if (percent > 0)
                {
                    DataGridView1.Rows[e.RowIndex].Cells[5].Style.ForeColor = Color.Red;
                    DataGridView1.Rows[e.RowIndex].Cells[6].Style.ForeColor = Color.Red;
                }
                else if (percent < 0)
                {
                    DataGridView1.Rows[e.RowIndex].Cells[5].Style.ForeColor = Color.Blue;
                    DataGridView1.Rows[e.RowIndex].Cells[6].Style.ForeColor = Color.Blue;
                }
                else
                {
                    DataGridView1.Rows[e.RowIndex].Cells[5].Style.ForeColor = Color.Black;
                    DataGridView1.Rows[e.RowIndex].Cells[6].Style.ForeColor = Color.Black;
                }
            }
        }
                
        private void Request()
        {
            if (_CpTd6033.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                return;
            }

            _Table.Clear();
            DataGridView1.Refresh();

            _CpTd6033.SetInputValue(0, TextBoxAccountNo1.Text + TextBoxAccountNo2.Text);
            _CpTd6033.SetInputValue(1, ComboBoxAccountKind.SelectedItem);
            _CpTd6033.SetInputValue(2, 20);

            ButtonNext.Enabled = false;

            JustRequest();
        }

        private void JustRequest()
        {
            LabelMsg1.Text = "";
            LabelContinue.Text = "";

            int result = _CpTd6033.BlockRequest();

            LabelMsg1.Text = _CpTd6033.GetDibMsg1();

            if (_CpTd6033.Continue == 1)
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
                TextBoxTotal.Text = _CpTd6033.GetHeaderValue(3).ToString();
                TextBoxProfit.Text = _CpTd6033.GetHeaderValue(4).ToString();

                if (Convert.ToDouble(TextBoxProfit.Text) > 0)
                    TextBoxProfit.ForeColor = Color.Red;
                else if (Convert.ToDouble(TextBoxProfit.Text) < 0)
                    TextBoxProfit.ForeColor = Color.Blue;
                else
                    TextBoxProfit.ForeColor = Color.Black;

                TextBoxD2.Text = _CpTd6033.GetHeaderValue(9).ToString();

                for (int i = 0; i < Int32.Parse(_CpTd6033.GetHeaderValue(7).ToString()); i++)
                {
                    DataRow rowOrder = _Table.NewRow();

                    rowOrder[0] = _CpTd6033.GetDataValue(0, i);
                    rowOrder[1] = _CpTd6033.GetDataValue(3, i);
                    rowOrder[2] = _CpTd6033.GetDataValue(4, i);
                    rowOrder[3] = _CpTd6033.GetDataValue(7, i);
                    rowOrder[4] = _CpTd6033.GetDataValue(9, i);
                    rowOrder[5] = _CpTd6033.GetDataValue(10, i);
                    rowOrder[6] = (Convert.ToDouble(_CpTd6033.GetDataValue(11, i)) / 100).ToString("0.00%");
                    rowOrder[7] = _CpTd6033.GetDataValue(15, i);
                    rowOrder[8] = Convert.ToInt32(_CpTd6033.GetDataValue(17, i));
                    rowOrder[9] = _CpTd6033.GetDataValue(18, i);

                    _Table.Rows.Add(rowOrder);
                }

                DataGridView1.Refresh();
            }
        }
    }
}
