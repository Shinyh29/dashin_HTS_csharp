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
    public partial class Form1301 : Form, FormRoot, FormTrade
    {
        private FormMain _parent;
        private DataTable _Table;
        CPTRADELib.CpTd5341 _CpTd5341;

        public Form1301()
        {
            InitializeComponent();
        }

        public void ChangedStockCode(string code, string name)
        {
            TextBoxName.Text = name;
            TextBoxCode.Text = code;

            ReceivedStockTrade();
        }

        public void ReceivedStockTrade()
        {
            if (ComboBoxQueryKind.SelectedIndex == 0)
                Request(false);
            else
                Request(true);
        }

        private void Form1301_Load(object sender, EventArgs e)
        {
            _parent = (FormMain)this.ParentForm;

            _CpTd5341 = new CPTRADELib.CpTd5341();

            ButtonNext.Enabled = false;

            _Table = new DataTable();
            _Table.Columns.Add("주문번호");
            _Table.Columns.Add("원주문번호");
            _Table.Columns.Add("종목명");
            _Table.Columns.Add("거래");
            _Table.Columns.Add("정정취소");
            _Table.Columns.Add("매매구분");
            _Table.Columns.Add("주문수량");
            _Table.Columns.Add("주문단가");
            _Table.Columns.Add("체결수량");
            _Table.Columns.Add("체결단가");

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

        private void Form1301_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void Form1301_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.CloseStockSelector(this);
        }

        private void Request(bool bEach)
        {
            if (_CpTd5341.GetDibStatus() == 1)
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
            DataGridView1.Refresh();

            _CpTd5341.SetInputValue(0, TextBoxAccountNo1.Text + TextBoxAccountNo2.Text);
            _CpTd5341.SetInputValue(1, ComboBoxAccountKind.SelectedItem);
            if (bEach)
                _CpTd5341.SetInputValue(2, TextBoxCode.Text.ToUpper());
            else
                _CpTd5341.SetInputValue(2, "");

            _CpTd5341.SetInputValue(3, 0);
            _CpTd5341.SetInputValue(4, Encoding.ASCII.GetBytes("1")[0]);
            _CpTd5341.SetInputValue(5, 20);
            _CpTd5341.SetInputValue(6, Encoding.ASCII.GetBytes("2")[0]);

            ButtonNext.Enabled = false;

            JustRequest();
        }

        private void JustRequest()
        {
            LabelMsg1.Text = "";
            LabelContinue.Text = "";

            int result = _CpTd5341.BlockRequest();

            LabelMsg1.Text = _CpTd5341.GetDibMsg1();

            if (_CpTd5341.Continue == 1)
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
                for (int i = 0; i < Int32.Parse(_CpTd5341.GetHeaderValue(6).ToString()); i++)
                {
                    DataRow rowOrder = _Table.NewRow();

                    rowOrder[0] = _CpTd5341.GetDataValue(1, i);
                    rowOrder[1] = _CpTd5341.GetDataValue(2, i);
                    rowOrder[2] = _CpTd5341.GetDataValue(4, i);

                    if (_CpTd5341.GetDataValue(35, i).ToString() == "1")
                        rowOrder[3] = "매도";
                    else
                        rowOrder[3] = "매수";
                    
                    rowOrder[4] = _CpTd5341.GetDataValue(13, i);
                    rowOrder[5] = _CpTd5341.GetDataValue(6, i);
                    rowOrder[6] = _CpTd5341.GetDataValue(7, i);
                    rowOrder[7] = _CpTd5341.GetDataValue(8, i);
                    rowOrder[8] = _CpTd5341.GetDataValue(10, i);
                    rowOrder[9] = _CpTd5341.GetDataValue(11, i);

                    _Table.Rows.Add(rowOrder);
                }

                DataGridView1.Refresh();
            }
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.Value.ToString() != "")
            {
                if (e.Value.ToString().Contains("매수"))
                    e.CellStyle.ForeColor = Color.Red;
                else
                    e.CellStyle.ForeColor = Color.Blue;
            }
            else if (e.ColumnIndex == 4 && e.Value.ToString() != "")
            {
                if (e.Value.ToString().Contains("정정"))
                    e.CellStyle.ForeColor = Color.Green;
                else if (e.Value.ToString().Contains("취소"))
                    e.CellStyle.ForeColor = Color.FromArgb(236, 77, 0);
            }
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView1.ClearSelection();
        }

        private void ButtonSelectCode_Click(object sender, EventArgs e)
        {
            _parent.ShowStockSelector(this);
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
            _parent.ShowHelp("1301");
        }

        private void ComboBoxQueryKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReceivedStockTrade();
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
    }
}
