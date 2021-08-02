using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DaishinPlusSampleForCSharp.Common;

namespace DaishinPlusSampleForCSharp._1000__주식._1300__체결
{
    public partial class Form1304 : Form, FormTrade
    {
        private FormMain _parent;

        public Form1304()
        {
            InitializeComponent();
        }

        public void ReceivedStockTrade()
        {
            if (CheckBoxTop.Checked)
            {
                DataGridView1.FirstDisplayedScrollingRowIndex = 0;
                DataGridView1.ClearSelection();
                DataGridView1.Rows[0].Selected = true;
            }

            DataGridView1.Refresh();
        }

        private void Form1304_Load(object sender, EventArgs e)
        {
            _parent = (FormMain)this.ParentForm;

            DataGridView1.DataSource = _parent._stockTradeTable;
            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridView1.AllowUserToResizeRows = false;
            DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridView1.Refresh();
        }

        private void Form1304_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value.ToString().Contains("매수") || e.Value.ToString().Contains("체결") || e.Value.ToString().Contains("거부") )
                e.CellStyle.ForeColor = Color.Red;
            else if (e.Value.ToString().Contains("매도"))
                e.CellStyle.ForeColor = Color.Blue;
            else if (e.Value.ToString().Contains("정정"))
                e.CellStyle.ForeColor = Color.Green;
            else if (e.Value.ToString().Contains("취소"))
                e.CellStyle.ForeColor = Color.FromArgb(236, 77, 0);
        }

        private void ButtonHelp1_Click(object sender, EventArgs e)
        {
            _parent.ShowHelp("1304");
        }
    }
}
