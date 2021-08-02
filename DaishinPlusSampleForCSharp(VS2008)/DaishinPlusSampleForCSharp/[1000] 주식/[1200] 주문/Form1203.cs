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
    public partial class Form1203 : Form, FormRoot
    {
        private FormMain _parent;

        CPTRADELib.CpTdNew5331B _CpTdNew5331B;

        DataTable _TableCount;

        public Form1203()
        {
            InitializeComponent();
        }

        public void ChangedStockCode(string code, string name)
        {
            TextBoxName.Text = name;
            TextBoxCode.Text = code;
        }

        private void Form1203_Load(object sender, EventArgs e)
        {
            _parent = (FormMain)this.ParentForm;

            _CpTdNew5331B = new CPTRADELib.CpTdNew5331B();

            ButtonNext.Enabled = false;

            _TableCount = new DataTable();
            _TableCount.Columns.Add("종목명");
            _TableCount.Columns.Add("잔고수량");
            _TableCount.Columns.Add("전일매수체결수량");
            _TableCount.Columns.Add("전일매도체결수량");
            _TableCount.Columns.Add("지정수량");
            _TableCount.Columns.Add("금일매수체결수량");
            _TableCount.Columns.Add("금일매도체결수량");
            _TableCount.Columns.Add("매도가능수량");

            DataGridView1.DataSource = _TableCount;
            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
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
        }

        private void Form1203_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void Form1203_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.CloseStockSelector(this);
        }

        private void TextBoxCode_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxCode.Text.Length >= 7)
            {
                TextBoxName.Text = _parent.FindStockName(TextBoxCode.Text.ToUpper());
                if (ComboBoxQueryKind.SelectedIndex == 0)
                    Request(true);
                else
                    ComboBoxQueryKind.SelectedIndex = 1;
            }
        }

        private void ButtonSelectCode_Click(object sender, EventArgs e)
        {
            _parent.ShowStockSelector(this);
        }

        private void ButtonQuery_Click(object sender, EventArgs e)
        {
            if (ComboBoxQueryKind.SelectedIndex == 0)
                Request(true);
            else
                Request(false);
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            JustRequest();
        }

        private void ButtonHelp1_Click(object sender, EventArgs e)
        {
            _parent.ShowHelp("1203");
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView1.ClearSelection();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView1.SelectedCells.Count > 0)
                _parent.ChangedStockCount(DataGridView1.SelectedCells[0].Value.ToString());
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView1.SelectedCells.Count > 0)
            {
                _parent.ChangedStockCount(DataGridView1.SelectedCells[0].Value.ToString());
                this.Close();
            }
        }

        private void ComboBoxAccountKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            _parent.ChangedAccountKind(ComboBoxAccountKind.SelectedText);
        }

        private void Request(bool bEach)
        {
            if (_CpTdNew5331B.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                return;
            }

            if (bEach)
            {
                if (TextBoxCode.Text.Length < 7)
                    return;
            }

            _TableCount.Clear();

            _CpTdNew5331B.SetInputValue(0, TextBoxAccountNo1.Text + TextBoxAccountNo2.Text);
            _CpTdNew5331B.SetInputValue(1, ComboBoxAccountKind.SelectedItem);
            if (bEach)
                _CpTdNew5331B.SetInputValue(2, TextBoxCode.Text.ToUpper());
            else
                _CpTdNew5331B.SetInputValue(2, "");

            _CpTdNew5331B.SetInputValue(10, 20);

            ButtonNext.Enabled = false;

            JustRequest();
        }

        private void JustRequest()
        {
            LabelMsg1.Text = "";
            LabelContinue.Text = "";

            int result = _CpTdNew5331B.BlockRequest();

            LabelMsg1.Text = _CpTdNew5331B.GetDibMsg1();

            if (_CpTdNew5331B.Continue == 1)
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
                for (int i = 0; i < Int32.Parse(_CpTdNew5331B.GetHeaderValue(0).ToString()); i++)
                {
                    DataRow rowPrice = _TableCount.NewRow();

                    rowPrice[0] = _CpTdNew5331B.GetDataValue(1, i);
                    rowPrice[1] = _CpTdNew5331B.GetDataValue(6, i);
                    rowPrice[2] = _CpTdNew5331B.GetDataValue(7, i);
                    rowPrice[3] = _CpTdNew5331B.GetDataValue(8, i);
                    rowPrice[4] = _CpTdNew5331B.GetDataValue(9, i);
                    rowPrice[5] = _CpTdNew5331B.GetDataValue(10, i);
                    rowPrice[6] = _CpTdNew5331B.GetDataValue(11, i);
                    rowPrice[7] = _CpTdNew5331B.GetDataValue(12, i);

                    _TableCount.Rows.Add(rowPrice);
                    DataGridView1.Refresh();
                }
            }
        }

        private void ComboBoxQueryKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxQueryKind.SelectedIndex == 0)
                Request(true);
            else
                Request(false);
        }
    }
}
