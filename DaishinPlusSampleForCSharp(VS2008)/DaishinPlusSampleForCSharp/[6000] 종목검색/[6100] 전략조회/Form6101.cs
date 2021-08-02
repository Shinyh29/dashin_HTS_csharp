using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DaishinPlusSampleForCSharp.Common;
using System.Diagnostics;

namespace DaishinPlusSampleForCSharp._6000__종목검색._6100__전략조회
{
    public partial class Form6101 : Form
    {
        private FormMain _parent;
        private DataTable _Table;
        private CPSYSDIBLib.CssStgList _CssStgList;
        private Boolean _bMy;
        private ArrayList _arrURL;
        private int _index;
    
        public Form6101()
        {
            InitializeComponent();

            _bMy = true;
        }

        private void Form6101_Load(object sender, EventArgs e)
        {
            _parent = (FormMain)this.ParentForm;

            _arrURL = new ArrayList();

            _CssStgList = new CPSYSDIBLib.CssStgList();

            _Table = new DataTable();
            _Table.Columns.Add("순번");
            _Table.Columns.Add("전략명");
            _Table.Columns.Add("전략ID");
            _Table.Columns.Add("평균 종목수");
            _Table.Columns.Add("평균 승률");
            _Table.Columns.Add("평균 수익률");
            _Table.Columns.Add("등록 일시");

            DataGridView1.DataSource = _Table;

            DataGridViewButtonColumn button1 = new DataGridViewButtonColumn();
            DataGridView1.Columns.Add(button1);
            button1.HeaderText = "검색 결과";
            button1.Text = "결과";
            button1.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn button2 = new DataGridViewButtonColumn();
            DataGridView1.Columns.Add(button2);
            button2.HeaderText = "실시간 감시";
            button2.Text = "감시";
            button2.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn button3 = new DataGridViewButtonColumn();
            DataGridView1.Columns.Add(button3);
            button3.HeaderText = "전략 URL";
            button3.Text = "URL";
            button3.UseColumnTextForButtonValue = true;
            
            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridView1.AllowUserToResizeRows = false;
            DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView1.Columns[2].Visible = false;
            DataGridView1.Refresh();
        }

        private void Form6101_Shown(object sender, EventArgs e)
        {
            this.Request();
        }

        private void Form6101_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView1.ClearSelection();
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DataGridView1.Columns[e.ColumnIndex].HeaderText == "평균 수익률")
            {
                String value = e.Value.ToString().Replace("%", "");
                if (value != "")
                {
                    if (Convert.ToDouble(value) > 0)
                        e.CellStyle.ForeColor = Color.Red;
                    else if (Convert.ToDouble(value) < 0)
                        e.CellStyle.ForeColor = Color.Blue;
                    else
                        e.CellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView1.Columns[e.ColumnIndex].HeaderText == "전략 URL")
            {
                if (e.RowIndex >= _arrURL.Count)
                    return;

                FormWeb web = new FormWeb();
                web.Show();
                web.ShowWeb(DataGridView1.Rows[e.RowIndex].Cells["전략명"].Value.ToString(), _arrURL[e.RowIndex].ToString());
            }
            else if (DataGridView1.Columns[e.ColumnIndex].HeaderText == "검색 결과")
            {
                _parent.ShowSTGResultList(DataGridView1.Rows[e.RowIndex].Cells["전략ID"].Value.ToString(), DataGridView1.Rows[e.RowIndex].Cells["전략명"].Value.ToString());
            }
            else if (DataGridView1.Columns[e.ColumnIndex].HeaderText == "실시간 감시")
            {
                _parent.ShowSTGMonitor(DataGridView1.Rows[e.RowIndex].Cells["전략ID"].Value.ToString(), DataGridView1.Rows[e.RowIndex].Cells["전략명"].Value.ToString());
            }
            else
            {
                _parent.ChangeSTG(DataGridView1.Rows[e.RowIndex].Cells["전략ID"].Value.ToString(), DataGridView1.Rows[e.RowIndex].Cells["전략명"].Value.ToString());
            }

            DataGridView1.ClearSelection();
        }

        private void ButtonHelp_Click(object sender, EventArgs e)
        {
            _parent.ShowHelp("6101");
        }

        private void ButtonQuery_Click(object sender, EventArgs e)
        {
            this.Request();
        }

        public void SetScreenType(string type)
        {
            if (type == "나의 전략")
            {
                this.Text = "[6101] 나의 전략 (CpSysDib.CssStgList)";
                _bMy = true;
            }
            else
            {
                this.Text = "[6102] 예제 전략 (CpSysDib.CssStgList)";
                _bMy = false;
            }
        }

        private void Request()
        {
            _Table.Clear();
            DataGridView1.Refresh();
            TextBoxCount.Text = "0";
            _index = 1;
            _arrURL.Clear();

            if (_bMy)
                _CssStgList.SetInputValue(0, Encoding.ASCII.GetBytes("1")[0]);
            else
                _CssStgList.SetInputValue(0, Encoding.ASCII.GetBytes("0")[0]);
            
            this.JustRequest();
        }

        private void JustRequest()
        {
            if (_CssStgList.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                return;
            }

            LabelMsg1.Text = "";

            int result = _CssStgList.BlockRequest();

            LabelMsg1.Text = _CssStgList.GetDibMsg1();
            
            if (result == 0)
            {
                for (int i = 0; i <= Convert.ToInt32(_CssStgList.GetHeaderValue(0).ToString()) - 1; i++)
                {
                    DataRow row = _Table.NewRow();

                    row["순번"] = _index.ToString();
                    row["전략명"] = _CssStgList.GetDataValue(0, i);
                    row["전략ID"] = _CssStgList.GetDataValue(1, i);
                    row["등록 일시"] = _CssStgList.GetDataValue(2, i);
                    row["평균 종목수"] = _CssStgList.GetDataValue(4, i);
                    double value = Convert.ToDouble(_CssStgList.GetDataValue(5, i));
                    if (value == -999.99)
                        row["평균 승률"] = "";
                    else
                        row["평균 승률"] = value.ToString("0.00%");
                    
                    value = Convert.ToDouble(_CssStgList.GetDataValue(6, i));
                    if (value == -999.99)
                        row["평균 수익률"] = "";
                    else
                        row["평균 수익률"] = value.ToString("0.00%");
                    
                    _arrURL.Add(_CssStgList.GetDataValue(7, i));

                    _Table.Rows.Add(row);

                    _index += 1;
                }
            }

            if (_CssStgList.Continue == 1)
            {
                this.JustRequest();
            }
            else
            {
                LabelMsg1.Text = "조회가 완료되었습니다.";
                TextBoxCount.Text = _Table.Rows.Count.ToString();

                DataGridView1.Refresh();
            }
        }
    }
}
