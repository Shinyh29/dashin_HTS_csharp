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

namespace DaishinPlusSampleForCSharp._6000__종목검색._6300__실시간감시
{
    public partial class Form6301 : Form, FormMonitor
    {
        private FormMain _parent;
        private DataTable _Table;
        private CPSYSDIBLib.MarketEye _marketEye;
        private CPSYSDIBLib.CssWatchStgSubscribe _CssWatchStgSubscribe;
        private CPSYSDIBLib.CssWatchStgControl _CssWatchStgControl;
        private CPSYSDIBLib.CssAlert _CssAlert;
        private DSCBO1Lib.StockCur _stockCur;
        private CPSYSDIBLib.CssStgFind _CssStgFind;
        private int _index;
        private String _stgID;
        private String _monitorID;
        private ArrayList _arrCode;
        private String _searchTime;

        public Form6301()
        {
            InitializeComponent();
        }

        public void SetSTGInfo(String id, String name)
        {
            this.StopSTG();
            
            this.Unsubscribe();

            _stgID = id;
            TextBoxName.Text = name;

            this.RequestSTGList();
        }

        private void Form6301_Load(object sender, EventArgs e)
        {
            _parent = (FormMain)this.ParentForm;

            _stockCur = new DSCBO1Lib.StockCur();
            _stockCur.Received += new DSCBO1Lib._IDibEvents_ReceivedEventHandler(_stockCur_Received);
            _marketEye = new CPSYSDIBLib.MarketEye();            
            _CssStgFind = new CPSYSDIBLib.CssStgFind();
            _CssWatchStgSubscribe = new CPSYSDIBLib.CssWatchStgSubscribe();
            _CssWatchStgControl = new CPSYSDIBLib.CssWatchStgControl();
            _CssAlert = new CPSYSDIBLib.CssAlert();
            _CssAlert.Received += new CPSYSDIBLib._ISysDibEvents_ReceivedEventHandler(_CssAlert_Received);

            _stgID = "";

            _arrCode = new ArrayList();

            _Table = new DataTable();
            _Table.Columns.Add("종목코드");
            _Table.Columns.Add("순번");
            _Table.Columns.Add("상태");
            _Table.Columns.Add("종목명");
            _Table.Columns.Add("현재가");
            _Table.Columns.Add("전일대비");
            _Table.Columns.Add("거래량");
            _Table.Columns.Add("포착가");
            _Table.Columns.Add("포착후 수익률");
            _Table.Columns.Add("포착시간");

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

            DataGridViewButtonColumn button3 = new DataGridViewButtonColumn();
            DataGridView1.Columns.Add(button3);
            button3.HeaderText = "삭제";
            button3.Text = "삭제";
            button3.UseColumnTextForButtonValue = true;

            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridView1.AllowUserToResizeRows = false;
            DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView1.Columns["종목코드"].Visible = false;
            DataGridView1.Refresh();
        }

        private void Form6301_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.StopSTG();

            this.Unsubscribe();
        }

        private void Form6301_KeyDown(object sender, KeyEventArgs e)
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
            if (DataGridView1.Columns[e.ColumnIndex].HeaderText == "상태" && e.Value.ToString() != "")
            {
                if (e.Value.ToString() == "진입")
                    DataGridView1.Rows[e.RowIndex].Cells["상태"].Style.ForeColor = Color.Red;
                else if (e.Value.ToString() == "퇴출")
                    DataGridView1.Rows[e.RowIndex].Cells["상태"].Style.ForeColor = Color.Blue;
            }
            else if (DataGridView1.Columns[e.ColumnIndex].HeaderText == "전일대비" && e.Value.ToString() != "")
            {
                double value = Convert.ToDouble(e.Value.ToString());
                if (value > 0)
                    DataGridView1.Rows[e.RowIndex].Cells["현재가"].Style.ForeColor = Color.Red;
                else if (value < 0)
                    DataGridView1.Rows[e.RowIndex].Cells["현재가"].Style.ForeColor = Color.Blue;
                else
                    DataGridView1.Rows[e.RowIndex].Cells["현재가"].Style.ForeColor = Color.Black;
            }
            else if (DataGridView1.Columns[e.ColumnIndex].HeaderText == "포착후 수익률" && e.Value.ToString() != "")
            {
                String text = e.Value.ToString().Replace("%", "");
                double value = Convert.ToDouble(text);
                if (value > 0)
                    DataGridView1.Rows[e.RowIndex].Cells["포착후 수익률"].Style.ForeColor = Color.Red;
                else if (value < 0)
                    DataGridView1.Rows[e.RowIndex].Cells["포착후 수익률"].Style.ForeColor = Color.Blue;
                else
                    DataGridView1.Rows[e.RowIndex].Cells["포착후 수익률"].Style.ForeColor = Color.Black;
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView1.ClearSelection();

            if (e.RowIndex == -1)
                return;

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
            else if (DataGridView1.Columns[e.ColumnIndex].HeaderText == "삭제")
            {
                _stockCur.SetInputValue(0, DataGridView1.Rows[e.RowIndex].Cells["종목코드"].Value.ToString());
                _stockCur.Unsubscribe();

                _Table.Rows[e.RowIndex].Delete();

                for (int i = 0; i <= _Table.Rows.Count - 1; i++)
                    _Table.Rows[i]["순번"] = (i + 1).ToString();
                
                DataGridView1.Refresh();

                TextBoxCount.Text = _Table.Rows.Count.ToString();
            }
            else
            {
                _parent.ChangedStockCode(DataGridView1.Rows[e.RowIndex].Cells["종목코드"].Value.ToString(), DataGridView1.Rows[e.RowIndex].Cells["종목명"].Value.ToString());
            }
        }

        private void _stockCur_Received()
        {
            double sumProfit = 0;
            bool bChanged = false;

            for (int i = 0; i <= _Table.Rows.Count - 1; i++)
            {
                if (_Table.Rows[i]["종목코드"].ToString().ToUpper() == _stockCur.GetHeaderValue(0).ToString().ToUpper())
                {
                    _Table.Rows[i]["현재가"] = _stockCur.GetHeaderValue(13);
                    _Table.Rows[i]["전일대비"] = _stockCur.GetHeaderValue(2);
                    _Table.Rows[i]["거래량"] = _stockCur.GetHeaderValue(9);

                    DataGridView1.Refresh();

                    double profit = Convert.ToDouble(_Table.Rows[i]["현재가"].ToString()) - Convert.ToDouble(_Table.Rows[i]["포착가"].ToString());
                    _Table.Rows[i]["포착후 수익률"] = (profit / Convert.ToDouble(_Table.Rows[i]["포착가"].ToString())).ToString("0.00%");
                    sumProfit += profit / 100;

                    bChanged = true;
                    break;
                }
            }

            if (bChanged)
            {
                TextBoxProfit.Text = (sumProfit / _Table.Rows.Count / 100).ToString("0.00%");

                String text = TextBoxProfit.Text.Replace("%", "");
                double value = Convert.ToDouble(text);
                if (value > 0)
                    TextBoxProfit.ForeColor = Color.Red;
                else if (value < 0)
                    TextBoxProfit.ForeColor = Color.Blue;
                else
                    TextBoxProfit.ForeColor = Color.Black;
            }
        }
        
        private void RequestMonitorID()
        {
            if (_CssWatchStgSubscribe.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                ButtonStart.Text = "▶";
                ButtonStart.BackColor = Color.Blue;
                LabelMonitor.Text = "감시 정지";
                return;
            }

            if (_stgID == "")
            {
                MessageBox.Show("전략이 존재하지 않습니다. 전략조회 화면으로부터 연동이 되어야합니다.");
                ButtonStart.Text = "▶";
                ButtonStart.BackColor = Color.Blue;
                LabelMonitor.Text = "감시 정지";
                return;
            }

            _CssWatchStgSubscribe.SetInputValue(0, _stgID);

            int result = _CssWatchStgSubscribe.BlockRequest();

            LabelMsg1.Text = _CssWatchStgSubscribe.GetDibMsg1();
            LabelMsg2.Text = _CssWatchStgSubscribe.GetDibMsg2();

            if (result == 0)
                _monitorID = _CssWatchStgSubscribe.GetHeaderValue(0).ToString();
        }

        private void StartSTG()
        {
            if (Convert.ToInt32(TextBoxCount.Text) > 200)
            {
                MessageBox.Show("실시간 감시는 200종목으로 제한합니다. 200종목 이상의 전략은 감시를 수행할 수 없습니다.");
                return;
            }

            if (_stgID == "")
            {
                MessageBox.Show("전략이 존재하지 않습니다. 전략화면으로부터 연동이 되어야합니다.");
                return;
            }

            if (Convert.ToInt32(_monitorID) < 0)
            {
                MessageBox.Show("감시 일련번호가 존재하지 않습니다.");
                return;
            }

            _CssAlert.Unsubscribe();

            _CssWatchStgControl.SetInputValue(0, _stgID);
            _CssWatchStgControl.SetInputValue(1, Convert.ToInt32(_monitorID));

            if (LabelMonitor.Text == "감시 정지")
            {
                _CssWatchStgControl.SetInputValue(2, Encoding.ASCII.GetBytes("1")[0]);
                ButtonStart.Text = "■";
                ButtonStart.BackColor = Color.Red;
                LabelMonitor.Text = "감시중";
            }
            else
            {
                _CssWatchStgControl.SetInputValue(2, Encoding.ASCII.GetBytes("3")[0]);
                ButtonStart.Text = "▶";
                ButtonStart.BackColor = Color.Blue;
                LabelMonitor.Text = "감시 정지";
            }

            int resultRQ = _CssWatchStgControl.BlockRequest();
            LabelMsg1.Text = _CssWatchStgControl.GetDibMsg1();
            LabelMsg2.Text = _CssWatchStgControl.GetDibMsg2();

            if (resultRQ == 0)
            {
                if (_CssWatchStgControl.GetHeaderValue(0).ToString() == "1")
                {
                    ButtonStart.Text = "■";
                    ButtonStart.BackColor = Color.Red;
                    LabelMonitor.Text = "감시중";
                    LabelMsg1.Text = "감시중입니다.";

                    if (_parent.GetRemainSB() > 0)
                        _CssAlert.Subscribe();
                }
                else
                {
                    LabelMsg1.Text = "감시가 정지되었습니다.";
                    ButtonStart.Text = "▶";
                    ButtonStart.BackColor = Color.Blue;
                    LabelMonitor.Text = "감시 정지";
                }
            }
        }

        private void StopSTG()
        {
            if (_stgID == "" || _monitorID == "")
                return;

            _CssAlert.Unsubscribe();

            _CssWatchStgControl.SetInputValue(0, _stgID);
            _CssWatchStgControl.SetInputValue(1, Convert.ToInt32(_monitorID));
            _CssWatchStgControl.SetInputValue(2, Encoding.ASCII.GetBytes("3")[0]);

            int resultRQ = _CssWatchStgControl.BlockRequest();
            LabelMsg1.Text = _CssWatchStgControl.GetDibMsg1();
            LabelMsg2.Text = _CssWatchStgControl.GetDibMsg2();

            if (resultRQ == 0)
            {
                if (_CssWatchStgControl.GetHeaderValue(0).ToString() == "1")
                {
                    ButtonStart.Text = "■";
                    ButtonStart.BackColor = Color.Red;
                    LabelMonitor.Text = "감시중";
                    LabelMsg1.Text = "감시중입니다.";

                    if (_parent.GetRemainSB() > 0)
                        _CssAlert.Subscribe();
                }
                else
                {
                    LabelMsg1.Text = "감시가 정지되었습니다.";
                    ButtonStart.Text = "▶";
                    ButtonStart.BackColor = Color.Blue;
                    LabelMonitor.Text = "감시 정지";
                }
            }
        }

        private void RequestSTGList()
        {
            if (_stgID == "")
            {
                MessageBox.Show("전략이 존재하지 않습니다. 전략화면으로부터 연동이 되어야합니다.");
                return;
            }

            _Table.Clear();
            DataGridView1.Refresh();

            TextBoxCount.Text = "0";
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
            LabelMsg2.Text = "";
            LabelContinue.Text = "";

            int result = _CssStgFind.BlockRequest();

            LabelMsg1.Text = _CssStgFind.GetDibMsg1();
            LabelMsg2.Text = _CssStgFind.GetDibMsg2();

            TextBoxCount.Text = _CssStgFind.GetHeaderValue(1).ToString();
            _searchTime = _CssStgFind.GetHeaderValue(2).ToString();

            if (result == 0)
            {
                for (int i = 0; i <= Convert.ToInt32(_CssStgFind.GetHeaderValue(0).ToString()) - 1; i++)
                    _arrCode.Add(_CssStgFind.GetDataValue(0, i));
                
                if (_CssStgFind.Continue == 1)
                {
                    this.JustRequest();
                    LabelMsg1.Text = "조회중입니다.";
                }
                else
                {
                    if (_arrCode.Count > 200)
                    {
                        MessageBox.Show("실시간 감시는 200종목으로 제한합니다. 200종목 이상의 전략은 감시를 수행할 수 없습니다.");
                        return;
                    }

                    this.Unsubscribe();

                    this.RequestMarketEye();
                }
            }
        }

        private void RequestMarketEye()
        {
            _index = 1;

            int [] items = {0, 1, 2, 3, 4, 5, 6, 7, 10, 11, 17};
            _marketEye.SetInputValue(0, items);

            String [] sCodes = new String[_arrCode.Count];
            
            for (int i = 0; i <= _arrCode.Count - 1; i++)
                sCodes[i] = _arrCode[i].ToString();

            _marketEye.SetInputValue(1, sCodes);

            int resultMarketEye = _marketEye.BlockRequest();

            LabelMsg1.Text = _marketEye.GetDibMsg1();

            if (resultMarketEye == 0)
            {
                double sumProfit = 0;
                for (int j = 0; j <= Convert.ToInt32(_marketEye.GetHeaderValue(2).ToString()) - 1; j++)
                {
                    DataRow row = _Table.NewRow();
                    row["순번"] = _index.ToString();
                    row["상태"] = "진입";
                    row["종목코드"] = _marketEye.GetDataValue(0, j);
                    row["종목명"] = _marketEye.GetDataValue(10, j);
                    row["현재가"] = _marketEye.GetDataValue(4, j);
                    row["포착가"] = _marketEye.GetDataValue(4, j);
                    row["전일대비"] = _marketEye.GetDataValue(3, j);
                    row["거래량"] = _marketEye.GetDataValue(8, j);
                    row["포착시간"] = _searchTime;

                    double profit = Convert.ToDouble(row["현재가"].ToString()) - Convert.ToDouble(row["포착가"].ToString());
                    row["포착후 수익률"] = (profit / Convert.ToDouble(row["포착가"].ToString())).ToString("0.00%");
                    sumProfit += profit / 100;

                    _Table.Rows.Add(row);
                    _index += 1;
                }

                TextBoxProfit.Text = (sumProfit / _Table.Rows.Count / 100).ToString("0.00%");

                String text = TextBoxProfit.Text.Replace("%", "");
                double value = Convert.ToDouble(text);
                if (value > 0)
                    TextBoxProfit.ForeColor = Color.Red;
                else if (value < 0)
                    TextBoxProfit.ForeColor = Color.Blue;
                else
                    TextBoxProfit.ForeColor = Color.Black;

                for (int j = 0; j <= _Table.Rows.Count - 1; j++)
                {
                    if (_parent.GetRemainSB() > 0)
                    {
                        _stockCur.SetInputValue(0, _Table.Rows[j]["종목코드"]);
                        _stockCur.Subscribe();
                    }
                }

                LabelMsg1.Text = "조회가 완료되었습니다.";
                TextBoxCount.Text = _Table.Rows.Count.ToString();

                DataGridView1.Refresh();

                RequestMonitorID();
            }
        }

        private void Unsubscribe()
        {
            for (int i = 0; i <= DataGridView1.Rows.Count - 1; i++)
            {
                _stockCur.SetInputValue(0, DataGridView1.Rows[i].Cells["종목코드"].Value.ToString());
                _stockCur.Unsubscribe();
            }
        }

        private void _CssAlert_Received()
        {
            if (_stgID == _CssAlert.GetHeaderValue(0).ToString() && _monitorID == _CssAlert.GetHeaderValue(1).ToString())
            {
                bool bNew = true;
                int rowIndex = -1;

                for (int i = 0; i <= _Table.Rows.Count - 1; i++)
                {
                    if (_Table.Rows[i]["종목코드"].ToString().ToUpper() == _CssAlert.GetHeaderValue(2).ToString().ToUpper())
                    {
                        _Table.Rows[i]["포착시간"] = _CssAlert.GetHeaderValue(4).ToString();
                        _Table.Rows[i]["포착가"] = _CssAlert.GetHeaderValue(5).ToString();
                        if (_CssAlert.GetHeaderValue(3).ToString() == "1")
                            _Table.Rows[i]["상태"] = "진입";
                        else
                            _Table.Rows[i]["상태"] = "퇴출";

                        double profit = Convert.ToDouble(_Table.Rows[i]["현재가"].ToString()) - Convert.ToDouble(_Table.Rows[i]["포착가"].ToString());
                        _Table.Rows[i]["포착후 수익률"] = (profit / Convert.ToDouble(_Table.Rows[i]["포착가"].ToString())).ToString("0.00%");

                        rowIndex = i;
                        bNew = false;
                        break;
                    }
                }

                if (bNew)
                {
                    DataRow row = _Table.NewRow();
                    row["순번"] = (_Table.Rows.Count + 1).ToString();
                    if (_CssAlert.GetHeaderValue(3).ToString() == "1")
                        row["상태"] = "진입";
                    else
                        row["상태"] = "퇴출";

                    row["종목코드"] = _CssAlert.GetHeaderValue(2).ToString();
                    row["종목명"] = _parent.FindStockName(_CssAlert.GetHeaderValue(2).ToString().ToUpper());
                    row["현재가"] = _CssAlert.GetHeaderValue(5).ToString();
                    row["포착가"] = _CssAlert.GetHeaderValue(5).ToString();
                    row["전일대비"] = "";
                    row["거래량"] = "";
                    row["포착시간"] = _CssAlert.GetHeaderValue(4).ToString();

                    double profit = Convert.ToDouble(row["현재가"].ToString()) - Convert.ToDouble(row["포착가"].ToString());
                    row["포착후 수익률"] = (profit / Convert.ToDouble(row["포착가"].ToString())).ToString("0.00%");

                    _Table.Rows.Add(row);

                    _stockCur.SetInputValue(0, row["종목코드"]);
                    _stockCur.Subscribe();
                }

                double sumProfit = 0;
                for (int i = 0; i <= _Table.Rows.Count - 1; i++)
                {
                    double profit = Convert.ToDouble(_Table.Rows[i]["현재가"].ToString()) - Convert.ToDouble(_Table.Rows[i]["포착가"].ToString());
                    _Table.Rows[i]["포착후 수익률"] = (profit / Convert.ToDouble(_Table.Rows[i]["포착가"].ToString())).ToString("0.00%");
                    sumProfit += profit / 100;

                    _Table.Rows[i]["순번"] = (i + 1).ToString();
                }

                TextBoxProfit.Text = (sumProfit / _Table.Rows.Count / 100).ToString("0.00%");

                String text = TextBoxProfit.Text.Replace("%", "");
                double value = Convert.ToDouble(text);
                if (value > 0)
                    TextBoxProfit.ForeColor = Color.Red;
                else if (value < 0)
                    TextBoxProfit.ForeColor = Color.Blue;
                else
                    TextBoxProfit.ForeColor = Color.Black;

                TextBoxCount.Text = _Table.Rows.Count.ToString();

                this.ClearOut(true);
            }
        }

        private void ClearOut(bool bRefresh)
        {
            if (CheckBoxDelete.Checked == false)
            {
                if (bRefresh)
                    DataGridView1.Refresh();

                return;
            }

            bool bDeleted = false;
            for (int i = _Table.Rows.Count - 1; i >= 0; i--)
            {
                if (_Table.Rows[i]["상태"].ToString() == "퇴출")
                {
                    _stockCur.SetInputValue(0, _Table.Rows[i]["종목코드"].ToString().ToUpper());
                    _stockCur.Unsubscribe();

                    _Table.Rows[i].Delete();

                    bDeleted = true;
                }
            }

            if (bDeleted)
            {
                for (int i = 0; i <= _Table.Rows.Count - 1; i++)
                    _Table.Rows[i]["순번"] = (i + 1).ToString();
            }

            if (bRefresh)
                DataGridView1.Refresh();
        }

        private void CheckBoxDelete_CheckedChanged(object sender, EventArgs e)
        {
            this.ClearOut(true);
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            this.StartSTG();
        }

        private void ButtonOrder_Click(object sender, EventArgs e)
        {
            if (DataGridView1.Rows.Count <= 0)
                return;

            DialogResult result = MessageBox.Show("전체 종목을 시장가로 1주씩 매수 주문합니다.", "대신증권", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                for (int i = 0; i <= _Table.Rows.Count - 1; i++)
                    _parent.SendStockOrder(true, _Table.Rows[i]["종목코드"].ToString(), "1", "0", "03", "0");
            }
        }

        private void ButtonHelp_Click(object sender, EventArgs e)
        {
            _parent.ShowHelp("6301");
        }
    }
}
