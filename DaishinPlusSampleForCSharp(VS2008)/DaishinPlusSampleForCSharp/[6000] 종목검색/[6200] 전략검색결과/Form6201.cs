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

namespace DaishinPlusSampleForCSharp._6000__종목검색._6200__전략검색결과
{
    public partial class Form6201 : Form, FormMonitor
    {
        private FormMain _parent;
        private DataTable _Table;
        private CPSYSDIBLib.MarketEye _marketEye;
        private DSCBO1Lib.StockCur _stockCur;
        private CPSYSDIBLib.CssStgFind _CssStgFind;
        private int _index;
        private String _stgID;
        private ArrayList _arrCode;

        public Form6201()
        {
            InitializeComponent();
        }

        public void SetSTGInfo(String id, String name)
        {
            _stgID = id;
            TextBoxName.Text = name;

            this.Request();
        }

        private void Form6201_Load(object sender, EventArgs e)
        {
            _parent = (FormMain)this.ParentForm;

            _stockCur = new DSCBO1Lib.StockCur();
            _marketEye = new CPSYSDIBLib.MarketEye();
            _stockCur.Received += new DSCBO1Lib._IDibEvents_ReceivedEventHandler(_stockCur_Received);
            _CssStgFind = new CPSYSDIBLib.CssStgFind();

            _stgID = "";

            _arrCode = new ArrayList();
                
            _Table = new DataTable();
            _Table.Columns.Add("종목코드");
            _Table.Columns.Add("순번");
            _Table.Columns.Add("종목명");
            _Table.Columns.Add("시간");
            _Table.Columns.Add("현재가");
            _Table.Columns.Add("전일대비");
            _Table.Columns.Add("시가");
            _Table.Columns.Add("고가");
            _Table.Columns.Add("저가");
            _Table.Columns.Add("거래량");

            DataGridView1.DataSource = _Table;

            DataGridViewButtonColumn button1 = new DataGridViewButtonColumn();
            DataGridView1.Columns.Add(button1);
            button1.HeaderText = "매수";
            button1.Text = "매수";
            button1.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn button2 = new DataGridViewButtonColumn();
            DataGridView1.Columns.Add(button2);
            button2.HeaderText = "매도";
            button2.Text = "매도";
            button2.UseColumnTextForButtonValue = true;

            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridView1.AllowUserToResizeRows = false;
            DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView1.Columns["종목코드"].Visible = false;
            DataGridView1.Refresh();
        }

        private void Form6201_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void Form6201_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Unsubscribe();
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DataGridView1.Columns[e.ColumnIndex].HeaderText == "전일대비")
            {
                double value = Convert.ToDouble(e.Value.ToString());
                if (value > 0)
                    DataGridView1.Rows[e.RowIndex].Cells["현재가"].Style.ForeColor = Color.Red;
                else if (value < 0)
                    DataGridView1.Rows[e.RowIndex].Cells["현재가"].Style.ForeColor = Color.Blue;
                else
                    DataGridView1.Rows[e.RowIndex].Cells["현재가"].Style.ForeColor = Color.Black;
            }
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView1.ClearSelection();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridView1.ClearSelection();

            if (DataGridView1.Columns[e.ColumnIndex].HeaderText == "매수")
            {
                _parent.ShowStockOrder(this, 0);
                _parent.ChangedStockCode(DataGridView1.Rows[e.RowIndex].Cells["종목코드"].Value.ToString(), DataGridView1.Rows[e.RowIndex].Cells["종목명"].Value.ToString());
            }
            else if (DataGridView1.Columns[e.ColumnIndex].HeaderText == "매도")
            {
                _parent.ShowStockOrder(this, 1);
                _parent.ChangedStockCode(DataGridView1.Rows[e.RowIndex].Cells["종목코드"].Value.ToString(), DataGridView1.Rows[e.RowIndex].Cells["종목명"].Value.ToString());
            }
            else
            {
                _parent.ChangedStockCode(DataGridView1.Rows[e.RowIndex].Cells["종목코드"].Value.ToString(), DataGridView1.Rows[e.RowIndex].Cells["종목명"].Value.ToString());
            }
        }

        private void ButtonQuery_Click(object sender, EventArgs e)
        {
            this.Request();
        }

        private void ButtonHelp_Click(object sender, EventArgs e)
        {
            _parent.ShowHelp("6201");
        }

        private void Request()
        {
            if (_stgID == "")
            {
                MessageBox.Show("전략이 존재하지 않습니다. 전략조회 화면으로부터 연동이 되어야합니다.");
                return;
            }

            _Table.Clear();
            DataGridView1.Refresh();

            TextBoxCount.Text = "0";
            TextBoxDateTime.Text = "0";
            _index = 1;
            _arrCode.Clear();

            _CssStgFind.SetInputValue(0, _stgID);

            this.JustRequest();
        }

        private void JustRequest()
        {
            if (_CssStgFind.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                return;
            }

            LabelMsg1.Text = "";
            LabelContinue.Text = "";

            int result = _CssStgFind.BlockRequest();

            LabelMsg1.Text = _CssStgFind.GetDibMsg1();

            TextBoxCount.Text = _CssStgFind.GetHeaderValue(1).ToString();
            TextBoxDateTime.Text = _CssStgFind.GetHeaderValue(2).ToString();

            if (result == 0)
            {
                for (int i = 0; i <= Convert.ToInt32(_CssStgFind.GetHeaderValue(0).ToString()) - 1; i++)
                    _arrCode.Add(_CssStgFind.GetDataValue(0, i));
            }

            if (_CssStgFind.Continue == 1)
            {
                this.JustRequest();
                LabelMsg1.Text = "조회중입니다.";
            }
            else
            {
                this.Unsubscribe();

                this.RequestMarketEye();
            }
        }

        private void RequestMarketEye()
        {
            _index = 1;
            Boolean bOver200 = false;
            if (_arrCode.Count > 200)
                bOver200 = true;

            while (_arrCode.Count > 0)
            {
                int toIndex = 0;
                ArrayList arrTemp = new ArrayList();

                if (_arrCode.Count > 200)
                {
                    for (int i = 0; i <= 199; i++)
                        arrTemp.Add(_arrCode[i]);

                    toIndex = 200;
                }
                else
                {
                    for (int i = 0; i <= _arrCode.Count - 1; i++)
                        arrTemp.Add(_arrCode[i]);

                    toIndex = _arrCode.Count;
                }

                _arrCode.RemoveRange(0, toIndex);

                int[] items = { 0, 1, 2, 3, 4, 5, 6, 7, 10, 11, 17 };
                _marketEye.SetInputValue(0, items);

                String[] sCodes = new String[arrTemp.Count];

                for (int i = 0; i <= arrTemp.Count - 1; i++)
                    sCodes[i] = arrTemp[i].ToString();

                _marketEye.SetInputValue(1, sCodes);

                int resultMarketEye = _marketEye.BlockRequest();

                LabelMsg1.Text = _marketEye.GetDibMsg1();

                if (resultMarketEye == 0)
                {
                    for (int j = 0; j <= Convert.ToInt32(_marketEye.GetHeaderValue(2).ToString()) - 1; j++)
                    {
                        DataRow row = _Table.NewRow();
                        row["순번"] = _index.ToString();
                        row["종목코드"] = _marketEye.GetDataValue(0, j);
                        row["종목명"] = _marketEye.GetDataValue(10, j);
                        row["시간"] = TextBoxDateTime.Text;
                        row["현재가"] = _marketEye.GetDataValue(4, j);
                        row["전일대비"] = _marketEye.GetDataValue(3, j);
                        row["시가"] = _marketEye.GetDataValue(5, j);
                        row["고가"] = _marketEye.GetDataValue(6, j);
                        row["저가"] = _marketEye.GetDataValue(7, j);
                        row["거래량"] = _marketEye.GetDataValue(8, j);

                        _Table.Rows.Add(row);
                        _index += 1;
                    }

                    for (int j = 0; j <= _Table.Rows.Count - 1; j++)
                    {
                        if (_parent.GetRemainSB() > 0 && bOver200 == false)
                        {
                            _stockCur.SetInputValue(0, _Table.Rows[j]["종목코드"]);
                            _stockCur.Subscribe();
                        }
                    }
                }
            }

            LabelMsg1.Text = "조회가 완료되었습니다.";
            TextBoxCount.Text = _Table.Rows.Count.ToString();
            DataGridView1.Refresh();
        }

        private void Unsubscribe()
        {
            for (int i = 0; i <= DataGridView1.Rows.Count - 1; i++)
            {
                _stockCur.SetInputValue(0, DataGridView1.Rows[i].Cells["종목코드"].Value.ToString());
                _stockCur.Unsubscribe();
            }
        }

        private void _stockCur_Received()
        {
            for (int i = 0; i <= _Table.Rows.Count - 1; i++)
            {
                if (_Table.Rows[i][0].ToString().ToUpper() == _stockCur.GetHeaderValue(0).ToString().ToUpper())
                {
                    _Table.Rows[i]["현재가"] = _stockCur.GetHeaderValue(13);
                    _Table.Rows[i]["전일대비"] = _stockCur.GetHeaderValue(2);
                    _Table.Rows[i]["시간"] = ClassUtil.ConvertToDateTime(_stockCur.GetHeaderValue(18).ToString());
                    _Table.Rows[i]["고가"] = _stockCur.GetHeaderValue(5);
                    _Table.Rows[i]["저가"] = _stockCur.GetHeaderValue(6);
                    _Table.Rows[i]["거래량"] = _stockCur.GetHeaderValue(9);

                    DataGridView1.Refresh();

                    break;
                }
            }
        }
    }
}
