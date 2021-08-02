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

namespace DaishinPlusSampleForCSharp._1000__주식._1300__체결
{
    public partial class Form1303 : Form, FormRoot, FormTrade
    {
        private FormMain _parent;
        private DataTable _Table;
        private CPTRADELib.CpTd5339 _CpTd5339;

        public Form1303()
        {
            InitializeComponent();
        }

        public void ChangedStockCode(string code, string name)
        {
            TextBoxName.Text = name;
            TextBoxCode.Text = code;
        }

        public void ReceivedStockTrade()
        {
            if (ComboBoxQueryKind.SelectedIndex == 0)
                Request(false);
            else
                Request(true);
        }

        private void Form1303_Load(object sender, EventArgs e)
        {
            _parent = (FormMain)this.ParentForm;

            _CpTd5339 = new CPTRADELib.CpTd5339();

            ButtonNext.Enabled = false;

            _Table = new DataTable();
            _Table.Columns.Add("주문번호");
            _Table.Columns.Add("원주문번호");
            _Table.Columns.Add("종목명");
            _Table.Columns.Add("주문구분내용");
            _Table.Columns.Add("주문수량");
            _Table.Columns.Add("주문단가");
            _Table.Columns.Add("체결수량");
            _Table.Columns.Add("정정취소가능수량");
            _Table.Columns.Add("매매");
            _Table.Columns.Add("구분");

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

            TextBoxName.Text = _parent.stockName;
            TextBoxCode.Text = _parent.stockCode;

            ComboBoxQueryKind.SelectedIndex = 0;
        }

        private void Form1303_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.CloseStockSelector(this);
        }

        private void Form1303_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void ComboBoxAccountKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TextBoxCode.Text.Length >= 7)
            {
                _parent.ChangedAccountKind(ComboBoxAccountKind.SelectedText);
                Request(true);
            }
        }

        private void TextBoxCode_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxCode.Text.Length >= 7)
            {
                TextBoxName.Text = _parent.FindStockName(TextBoxCode.Text.ToUpper());
                if (ComboBoxQueryKind.SelectedIndex == 0)
                    ComboBoxQueryKind.SelectedIndex = 1;
                else
                    Request(true);
            }
        }

        private void ButtonSelectCode_Click(object sender, EventArgs e)
        {
            _parent.ShowStockSelector(this);
        }

        private void ComboBoxQueryKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxQueryKind.SelectedIndex == 0)
                Request(false);
            else
                Request(true);
        }

        private void ButtonQuery_Click(object sender, EventArgs e)
        {
            if (ComboBoxQueryKind.SelectedIndex == 0)
                Request(false);
            else
                Request(true);
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            JustRequest();
        }

        private void ButtonHelp1_Click(object sender, EventArgs e)
        {
            _parent.ShowHelp("1303");
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 8 && e.Value.ToString() != "")
            {
                if (e.Value.ToString().Contains("매수"))
                    e.CellStyle.ForeColor = Color.Red;
                else
                    e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView1.ClearSelection();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView1.SelectedCells.Count > 0)
                _parent.ChangedStockNoneTradeNo(DataGridView1.SelectedCells[0].Value.ToString(), DataGridView1.SelectedCells[7].Value.ToString());
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView1.SelectedCells.Count > 0)
            {
                _parent.ChangedStockNoneTradeNo(DataGridView1.SelectedCells[0].Value.ToString(), DataGridView1.SelectedCells[7].Value.ToString());
                this.Close();
            }
        }

        private void Request(bool bEach)
        {
            if (_CpTd5339.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                return;
            }

            if (bEach)
            {
                if (TextBoxCode.Text.Length < 7)
                    return;
            }

            _Table.Clear();

            _CpTd5339.SetInputValue(0, TextBoxAccountNo1.Text + TextBoxAccountNo2.Text);
            _CpTd5339.SetInputValue(1, ComboBoxAccountKind.SelectedItem);

            if (bEach)
                _CpTd5339.SetInputValue(3, TextBoxCode.Text.ToUpper());
            else
                _CpTd5339.SetInputValue(3, "");

            _CpTd5339.SetInputValue(5, "1");
            _CpTd5339.SetInputValue(7, 20);

            ButtonNext.Enabled = false;

            JustRequest();
        }

        private void JustRequest()
        {
            LabelMsg1.Text = "";
            LabelContinue.Text = "";

            int result = _CpTd5339.BlockRequest();

            LabelMsg1.Text = _CpTd5339.GetDibMsg1();

            if (_CpTd5339.Continue == 1)
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
                for (int i = 0; i < Int32.Parse(_CpTd5339.GetHeaderValue(5).ToString()); i++)
                {
                    DataRow rowOrder = _Table.NewRow();

                    rowOrder[0] = _CpTd5339.GetDataValue(1, i);
                    rowOrder[1] = _CpTd5339.GetDataValue(2, i);
                    rowOrder[2] = _CpTd5339.GetDataValue(4, i);
                    rowOrder[3] = _CpTd5339.GetDataValue(5, i);
                    rowOrder[4] = _CpTd5339.GetDataValue(6, i);
                    rowOrder[5] = _CpTd5339.GetDataValue(7, i);
                    rowOrder[6] = _CpTd5339.GetDataValue(8, i);
                    rowOrder[7] = _CpTd5339.GetDataValue(11, i);
                    if (_CpTd5339.GetDataValue(13, i).ToString() == "1")
                        rowOrder[8] = "매도";
                    else
                        rowOrder[8] = "매수";

                    if (_CpTd5339.GetDataValue(21, i).ToString() == "01")
                        rowOrder[9] = "보통";
                    else if (_CpTd5339.GetDataValue(21, i).ToString() == "03")
                        rowOrder[9] = "시장가";
                    else if (_CpTd5339.GetDataValue(21, i).ToString() == "05")
                        rowOrder[9] = "조건부지정가";
                    else if (_CpTd5339.GetDataValue(21, i).ToString() == "12")
                        rowOrder[9] = "최유리지정가";
                    else if (_CpTd5339.GetDataValue(21, i).ToString() == "13")
                        rowOrder[9] = "최우선지정가";

                    _Table.Rows.Add(rowOrder);
                    DataGridView1.Refresh();
                }
            }
        }
    }
}
