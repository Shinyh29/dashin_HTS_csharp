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
    public partial class Form1205 : Form
    {
        private FormMain _parent;

        CPTRADELib.CpTd9065 _CpTd9065;
        private DataTable _Table;

        public Form1205()
        {
            InitializeComponent();
        }

        public void ReceivedStockReservedOrder()
        {
            Request();
        }

        private void Form1205_Load(object sender, EventArgs e)
        {
            _parent = (FormMain)this.ParentForm;

            _CpTd9065 = new CPTRADELib.CpTd9065();

            ButtonNext.Enabled = false;

            _Table = new DataTable();
            _Table.Columns.Add("예약번호");
            _Table.Columns.Add("처리상태");
            _Table.Columns.Add("시장구분");
            _Table.Columns.Add("주문구분");
            _Table.Columns.Add("종목명");
            _Table.Columns.Add("주문수량");
            _Table.Columns.Add("주문단가");
            _Table.Columns.Add("주문호가구분");
            _Table.Columns.Add("입력매체");
            _Table.Columns.Add("주문번호");
            _Table.Columns.Add("거부내용");

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

        private void Form1205_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.CloseStockSelector(this);
        }

        private void Form1205_KeyDown(object sender, KeyEventArgs e)
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
            _parent.ShowHelp("1205");
        }

        private void Request()
        {
            if (_CpTd9065.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                return;
            }

            _Table.Clear();
            DataGridView1.Refresh();

            _CpTd9065.SetInputValue(0, TextBoxAccountNo1.Text + TextBoxAccountNo2.Text);
            _CpTd9065.SetInputValue(1, ComboBoxAccountKind.SelectedItem);
            _CpTd9065.SetInputValue(2, 20);

            ButtonNext.Enabled = false;

            JustRequest();
        }

        private void JustRequest()
        {
            LabelMsg1.Text = "";
            LabelContinue.Text = "";

            int result = _CpTd9065.BlockRequest();

            LabelMsg1.Text = _CpTd9065.GetDibMsg1();

            if (_CpTd9065.Continue == 1)
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
                for (int i = 0; i < Int32.Parse(_CpTd9065.GetHeaderValue(4).ToString()); i++)
                {
                    DataRow rowOrder = _Table.NewRow();

                    rowOrder[0] = _CpTd9065.GetDataValue(6, i);
                    rowOrder[1] = _CpTd9065.GetDataValue(12, i);
                    rowOrder[2] = _CpTd9065.GetDataValue(0, i);
                    rowOrder[3] = _CpTd9065.GetDataValue(1, i);
                    rowOrder[4] = _CpTd9065.GetDataValue(8, i);
                    rowOrder[5] = _CpTd9065.GetDataValue(3, i);
                    rowOrder[6] = _CpTd9065.GetDataValue(9, i);
                    rowOrder[7] = _CpTd9065.GetDataValue(4, i);
                    rowOrder[8] = _CpTd9065.GetDataValue(5, i);
                    rowOrder[9] = _CpTd9065.GetDataValue(11, i);
                    rowOrder[10] = _CpTd9065.GetDataValue(14, i);

                    _Table.Rows.Add(rowOrder);
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
            if (e.ColumnIndex == 3 && e.Value.ToString() != "")
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (e.Value.ToString() == "매수")
                    e.CellStyle.ForeColor = Color.Red;
                else
                    e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView1.SelectedCells.Count > 0)
                _parent.ChangedStockReservedOrderNo(DataGridView1.SelectedRows[0].Cells["예약번호"].Value.ToString());
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView1.SelectedCells.Count > 0)
            {
                _parent.ChangedStockReservedOrderNo(DataGridView1.SelectedRows[0].Cells["예약번호"].Value.ToString());
                this.Close();
            }
        }
    }
}
