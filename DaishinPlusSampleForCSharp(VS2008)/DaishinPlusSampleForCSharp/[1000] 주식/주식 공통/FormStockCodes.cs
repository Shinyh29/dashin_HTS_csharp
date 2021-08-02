using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DaishinPlusSampleForCSharp._1000__주식.주식_공통
{
    public partial class FormStockCodes : Form
    {
        private FormMain _main;
        private DataTable _searchTable;
        
        public FormStockCodes()
        {
            InitializeComponent();
        }

        private void FormStockCodes_Load(object sender, EventArgs e)
        {
            _main = (FormMain)this.MdiParent;

            _searchTable = new DataTable();
            _searchTable.Columns.Add("순번");
            _searchTable.Columns.Add("종목코드");
            _searchTable.Columns.Add("종목명");

            DataGridView1.DataSource = _main._stockTable;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridView1.AllowUserToResizeRows = false;
            DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView1.Refresh();
        }

        private void FormStockCodes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _main.ChangedStockCode(DataGridView1.Rows[e.RowIndex].Cells["종목코드"].Value.ToString(), DataGridView1.Rows[e.RowIndex].Cells["종목명"].Value.ToString());
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _main.ChangedStockCode(DataGridView1.Rows[e.RowIndex].Cells["종목코드"].Value.ToString(), DataGridView1.Rows[e.RowIndex].Cells["종목명"].Value.ToString());
            this.Close();
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
             if (e.ColumnIndex == 0)
                DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView1.ClearSelection();
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxSearch.Text.Length > 0)
            {
                _searchTable.Clear();

                int index = 1;
                for (int i = 0; i < _main._stockTable.Rows.Count; i++)
                {
                    if (Convert.ToString(_main._stockTable.Rows[i]["종목코드"]).Contains(TextBoxSearch.Text.ToUpper()) || Convert.ToString(_main._stockTable.Rows[i]["종목명"]).Contains(TextBoxSearch.Text.ToUpper()))
                        _searchTable.Rows.Add(index.ToString(), Convert.ToString(_main._stockTable.Rows[i]["종목코드"]), Convert.ToString(_main._stockTable.Rows[i]["종목명"]));
                        index += 1;
                }

                DataGridView1.DataSource = _searchTable;
            }
            else
            {
                DataGridView1.DataSource = _main._stockTable;
            }

            DataGridView1.Refresh();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            TextBoxSearch.Text = "";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            _main.ShowHelp("10001");
        }
    }
}
