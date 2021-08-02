using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using CPUTILLib;
using CPTRADELib;
using System.Diagnostics;
using DaishinPlusSampleForCSharp.Common;
using DaishinPlusSampleForCSharp._1000__주식.주식_공통;
using DaishinPlusSampleForCSharp._1000__주식._1100__시세;
using DaishinPlusSampleForCSharp._1000__주식._1200__주문;
using DaishinPlusSampleForCSharp._1000__주식._1300__체결;
using DaishinPlusSampleForCSharp._1000__주식._1400__잔고;
using DaishinPlusSampleForCSharp._6000__종목검색._6100__전략조회;
using DaishinPlusSampleForCSharp._6000__종목검색._6200__전략검색결과;
using DaishinPlusSampleForCSharp._6000__종목검색._6300__실시간감시;

namespace DaishinPlusSampleForCSharp
{
    public partial class FormMain : Form
    {
        private CPUTILLib.CpStockCode _CpStockCode;
        private CPUTILLib.CpCodeMgr _CpCodeMgr;
        private CPUTILLib.CpCybos _CpCybos;
        private CPTRADELib.CpTdUtil _CpTdUtil;
        private DSCBO1Lib.CpConclusion _CpConclusion;

        private System.Timers.Timer _timerConnection;
        private int _timerCount;

        public DataTable _stockTable;
        private FormStockCodes _formStockCodes;

        private Form1101 _form1101;
        private Form1102 _form1102;
        private Form1103 _form1103;
        private Form1104 _form1104;
        private Form1105 _form1105;
        private Form1106 _form1106;

        private Form1201 _form1201;
        private Form1202 _form1202;
        private Form1203 _form1203;
        private Form1204 _form1204;
        private Form1205 _form1205;

        private Form1301 _form1301;
        private Form1302 _form1302;
        private Form1303 _form1303;
        private Form1304 _form1304;

        private Form1401 _form1401;
        private Form1402 _form1402;

        private Form6101 _form6101;
        private Form6201 _form6201;
        private Form6301 _form6301;

        public string stockCode;
        public string stockName;

        private bool _checkedTradeInit;

        public DataTable _stockTradeTable;
        
        public string accountNo ;
        public string accountGoodsStock;
        public string[] arrAccountGoodsStock;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            _CpStockCode = new CPUTILLib.CpStockCode();
            _CpCodeMgr = new CPUTILLib.CpCodeMgr();
            _CpTdUtil = new CPTRADELib.CpTdUtil();
            _CpConclusion = new DSCBO1Lib.CpConclusion();
            _CpConclusion.Received += new DSCBO1Lib._IDibEvents_ReceivedEventHandler(CpConclusion_Received);

            _CpCybos = new CPUTILLib.CpCybos();
            _CpCybos.OnDisconnect += CpCybos_OnDisconnect;

            _stockTable = new DataTable();

            _checkedTradeInit = false;

            stockCode = "A003540";
            stockName = "대신증권";

            labelStatus.Visible = false;

            _stockTradeTable = new DataTable();

            accountNo = "";
            accountGoodsStock = "";
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            ChangeMainTitleConnection();
        }

        private void 플러스접속ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CpCybos = null;
            _CpCybos = new CPUTILLib.CpCybos();
            
            if (_CpCybos.IsConnect == 1)
            {
                MessageBox.Show("대신증권 플러스에 이미 연결된 상태입니다.");
                return;
            };

            if (_timerConnection != null)
            {
                _timerConnection.Stop();
                _timerConnection.Dispose();
                _timerConnection = null;
            }

            _timerCount = 0;

            ChangeMainTitleConnection();
        }

        private void CpCybos_OnDisconnect()
        {
            _CpCybos = null;

            menuStrip1.BackColor = Color.FromArgb(255, 230, 230);

            this.Text = "대신증권 플러스 Sample for C# (연결 안됨)";

            MessageBox.Show("대신증권 플러스 연결이 종료되었습니다.");           
        }

        private void ChangeMainTitleConnection()
        {
            _CpCybos = null;
            _CpCybos = new CPUTILLib.CpCybos();

            if (_CpCybos.IsConnect == 1)
            {
                if (_timerConnection != null)
                {
                    _timerConnection.Stop();
                    _timerConnection.Dispose();
                    _timerConnection = null;
                }

                _timerCount = 0;

                menuStrip1.BackColor = Color.FromArgb(228, 254, 226);                            

                Invoke(new MethodInvoker(ConnectionCompleted));

                MessageBox.Show("대신증권 플러스에 연결되었습니다.");

                LoadStockCodes();
            }
            else
            {
                this.Text = "대신증권 플러스 Sample for C# (연결 안됨)";

                if (_timerCount == 0)
                {
                    DialogConnection dialog = new DialogConnection();
                    dialog.SetParent(this);
                    dialog.ShowDialog(this);
                }
            }
        }

        public void RequestConnection()
        {
            _timerConnection = new System.Timers.Timer();
            _timerConnection.Interval = 1000;
            _timerConnection.Elapsed += new ElapsedEventHandler(_timerConnection_Elapsed);
            _timerConnection.Start();
            _timerCount = 0;
        }

        private void _timerConnection_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_timerCount > 180)
            {
                _timerConnection.Stop();
                _timerConnection.Dispose();
                _timerConnection = null;
                _timerCount = 0;
            }

            _timerCount += 1;

            ChangeMainTitleConnection();
        }

        public void ConnectionCompleted()
        {
            this.Text = "대신증권 플러스 Sample for C# (연결 완료)";
        }

        private void LoadStockCodes()
        {
            SetStatus("주식 종목정보 수신중...");

            _stockTable.Columns.Clear();
            _stockTable.Columns.Add("순번");
            _stockTable.Columns.Add("종목코드");
            _stockTable.Columns.Add("종목명");

            _stockTable.Clear();
            
            for (short i = 0; i < _CpStockCode.GetCount(); i++)
                _stockTable.Rows.Add((i + 1).ToString(), _CpStockCode.GetData(0, i).ToString(), _CpStockCode.GetData(1, i).ToString());

            SetStatus("");
        }
         
        public void CloseStockSelector(object sender)
        {
            if (_formStockCodes != null && _formStockCodes.Visible == true)
                _formStockCodes.Visible = false;
        }

        public CPE_MARKET_KIND GetStockMarketKind(string code)
        {
            CPE_MARKET_KIND market = _CpCodeMgr.GetStockMarketKind(code);
            return market;
        }

        public void ShowStockSelector(Form sender)
        {
            if (_formStockCodes != null && _formStockCodes.Visible == true)
                _formStockCodes.Close();
            
            _formStockCodes = new FormStockCodes();
            _formStockCodes.MdiParent = this;
            _formStockCodes.StartPosition = FormStartPosition.Manual;
            _formStockCodes.Location = new Point(sender.Location.X + sender.Size.Width, sender.Location.Y);
            _formStockCodes.TopMost = true;
            _formStockCodes.Show();
        }

        public void ChangedStockCode(string code, string name)
        {
            stockCode = code;
            stockName = name;

            foreach (Form childForm in this.MdiChildren)
            {
                if (childForm.Text.Length >= 5)
                {
                    string title = childForm.Text.Substring(1, 4);
                    if (title == "1101" || title == "1102" || title == "1103" || title == "1104" || title == "1105" || title == "1106" || title == "1201" || title == "1202" || title == "1203" || title == "1204" || title == "1301" || title == "1302" || title == "1303")
                        ((FormRoot)childForm).ChangedStockCode(code, name);
                }
            }
        }

        private void SetStatus(string status)
        {
            if (status != "")
            {
                labelStatus.Visible = true;
                labelStatus.Text = status;
                labelStatus.Location = new Point((this.Size.Width - labelStatus.Size.Width) / 2, (this.Size.Height - labelStatus.Size.Height) / 2 - 50);
                this.Refresh();
            }
            else
            {
                labelStatus.Visible = false;
            }
        }

        
        public string FindStockName(string code)
        {
            if (_stockTable.Rows.Count <= 0)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                LoadStockCodes();
                return "";
            }

            string retName = "";

            for (int i = 0; i < _stockTable.Rows.Count; i++)
            {
                if (code == _stockTable.Rows[i]["종목코드"].ToString())
                {
                    retName = _stockTable.Rows[i]["종목명"].ToString();
                    break;
                }
            }

            return retName;
        }

        public void ChangedStockQuote(string price)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                if (childForm.Text.Length >= 5)
                {
                    string title = childForm.Text.Substring(1, 4);
                    if (title == "1201" || title == "1202" || title == "1204")
                        ((FormOrder)childForm).ChangedStockQuote(price);
                }
            }
        }
        
        public void ChangedStockCount(string count)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                if (childForm.Text.Length >= 5)
                {
                    string title = childForm.Text.Substring(1, 4);
                    if (title == "1201")
                        ((Form1201)childForm).ChangedStockCount(count);
                }
            }
        }

        public void ChangedStockNoneTradeNo(string no, string count)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                if (childForm.Text.Length >= 5)
                {
                    string title = childForm.Text.Substring(1, 4);
                    if (title == "1201")
                        ((Form1201)childForm).ChangedStockNoneTradeNo(no, count);
                }
            }
        }

        public void ShowHelp(string screen)
        {
            FormHelp formHelp = new FormHelp();
            formHelp.MdiParent = this;
            formHelp.SetScreen(screen);
            formHelp.Show();
        }

        private void 주식현재가단일종목ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _form1101 = new Form1101();
            _form1101.MdiParent = this;
            _form1101.Show();
        }

        private void 관심종목ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _form1102 = new Form1102();
            _form1102.MdiParent = this;
            _form1102.Show();
        }

        private void 투자주체별현황ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _form1103 = new Form1103();
            _form1103.MdiParent = this;
            _form1103.Show();
        }

        private void 주식시간대별체결ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _form1104 = new Form1104();
            _form1104.MdiParent = this;
            _form1104.Show();
        }

        private void 주식일자별주가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _form1105 = new Form1105();
            _form1105.MdiParent = this;
            _form1105.Show();
        }

        private void 주식호가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _form1106 = new Form1106();
            _form1106.MdiParent = this;
            _form1106.Show();
        }

        private void 주식시세종합화면ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
                childForm.Close();

            int xPos = 0;
            int yPos = 0;

            _form1106 = new Form1106();
            _form1106.MdiParent = this;
            _form1106.StartPosition = FormStartPosition.Manual;
            _form1106.Location = new Point(xPos, yPos);
            _form1106.Show();

            _form1101 = new Form1101();
            _form1101.MdiParent = this;
            _form1101.StartPosition = FormStartPosition.Manual;
            _form1101.Location = new Point(xPos + _form1106.Size.Width, yPos);
            _form1101.Show();

            _form1102 = new Form1102();
            _form1102.MdiParent = this;
            _form1102.StartPosition = FormStartPosition.Manual;
            _form1102.Location = new Point(xPos + _form1106.Size.Width, yPos + _form1101.Size.Height);
            _form1102.Show();
            _form1102.Height = _form1106.Size.Height - _form1101.Size.Height;

            _form1104 = new Form1104();
            _form1104.MdiParent = this;
            _form1104.StartPosition = FormStartPosition.Manual;
            _form1104.Location = new Point(xPos + _form1106.Size.Width + _form1101.Size.Width, yPos);
            _form1104.Show();
            _form1104.Height = 480;

            _form1105 = new Form1105();
            _form1105.MdiParent = this;
            _form1105.StartPosition = FormStartPosition.Manual;
            _form1105.Location = new Point(xPos + _form1106.Size.Width + _form1101.Size.Width, yPos + _form1104.Size.Height);
            _form1105.Show();
            _form1105.Height = 420;

            _form1103 = new Form1103();
            _form1103.MdiParent = this;
            _form1103.StartPosition = FormStartPosition.Manual;
            _form1103.Location = new Point(xPos, yPos + _form1106.Size.Height);
            _form1103.Show();
            _form1103.Height = _form1103.Height / 2;
        }

        private void 화면모두닫기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
                childForm.Close();
        }

        private void TradeInit()
        {
            if (_checkedTradeInit)
                return;

            int rv = _CpTdUtil.TradeInit(0);
            if (rv == 0)
            {
                _checkedTradeInit = true;

                string[] arrAccount = (string[])_CpTdUtil.AccountNumber;
                if (arrAccount.Length > 0)
                {
                    accountNo = arrAccount[0];

                    arrAccountGoodsStock = (string[])_CpTdUtil.get_GoodsList(accountNo, CPE_ACC_GOODS.CPC_STOCK_ACC);    // 주식
                    if (arrAccountGoodsStock.Length > 0)
                        accountGoodsStock = arrAccountGoodsStock[0];
                }

                StockTradeInit();
            }
            else if (rv == -1)
            {
                MessageBox.Show("계좌 비밀번호 오류 포함 에러.");
                _checkedTradeInit = false;
            }
            else if (rv == 1)
            {
                MessageBox.Show("OTP/보안카드키가 잘못되었습니다.");
                _checkedTradeInit = false;
            }
            else
            {
                MessageBox.Show("Error");
                _checkedTradeInit = false;
            }
        }

        public void ChangedAccountKind(string kind)
        {
            if (kind != "")
                accountGoodsStock = kind;
        }

        private void StockTradeInit()
        {
            _stockTradeTable.Columns.Clear();

            _stockTradeTable.Columns.Add("계좌명");
            _stockTradeTable.Columns.Add("계좌번호");
            _stockTradeTable.Columns.Add("계좌상품");
            _stockTradeTable.Columns.Add("종목명");
            _stockTradeTable.Columns.Add("종목코드");
            _stockTradeTable.Columns.Add("주문번호");
            _stockTradeTable.Columns.Add("원주문번호");
            _stockTradeTable.Columns.Add("체결가격");
            _stockTradeTable.Columns.Add("체결수량");
            _stockTradeTable.Columns.Add("매매");
            _stockTradeTable.Columns.Add("실시간");
            _stockTradeTable.Columns.Add("정정취소");
            _stockTradeTable.Columns.Add("주문구분");
            _stockTradeTable.Columns.Add("주문조건");
            _stockTradeTable.Columns.Add("장부가");
            _stockTradeTable.Columns.Add("체결기준잔고수량");

            _stockTradeTable.Clear();

            _CpConclusion.Subscribe();
        }

        private void CpConclusion_Received()
        {
            DataRow row = _stockTradeTable.NewRow();

            row["계좌명"] = _CpConclusion.GetHeaderValue(1);
            row["계좌번호"] = _CpConclusion.GetHeaderValue(7);
            row["계좌상품"] = _CpConclusion.GetHeaderValue(8);
            row["종목명"] = _CpConclusion.GetHeaderValue(2);
            row["종목코드"] = _CpConclusion.GetHeaderValue(9);
            row["주문번호"] = _CpConclusion.GetHeaderValue(5);
            row["원주문번호"] = _CpConclusion.GetHeaderValue(6);
            row["체결가격"] = _CpConclusion.GetHeaderValue(4);
            row["체결수량"] = _CpConclusion.GetHeaderValue(3);

            if (_CpConclusion.GetHeaderValue(12).ToString() == "1")
                row["매매"] = "매도";
            else
                row["매매"] = "매수";

            if (_CpConclusion.GetHeaderValue(14).ToString() == "1")
                row["실시간"] = "체결";
            else if (_CpConclusion.GetHeaderValue(14).ToString() == "2")
                row["실시간"] = "확인";
            else if (_CpConclusion.GetHeaderValue(14).ToString() == "3")
                row["실시간"] = "거부";
            else if (_CpConclusion.GetHeaderValue(14).ToString() == "4")
                row["실시간"] = "접수";

            if (_CpConclusion.GetHeaderValue(16).ToString() == "1")
                row["정정취소"] = "정상";
            else if (_CpConclusion.GetHeaderValue(16).ToString() == "2")
                row["정정취소"] = "정정";
            else if (_CpConclusion.GetHeaderValue(16).ToString() == "3")
                row["정정취소"] = "취소";

            if (_CpConclusion.GetHeaderValue(18).ToString() == "01")
                row["주문구분"] = "보통";
            else if (_CpConclusion.GetHeaderValue(18).ToString() == "03")
                row["주문구분"] = "시장가";
            else if (_CpConclusion.GetHeaderValue(18).ToString() == "05")
                row["주문구분"] = "조건부지정가";
            else if (_CpConclusion.GetHeaderValue(18).ToString() == "12")
                row["주문구분"] = "최유리지정가";
            else if (_CpConclusion.GetHeaderValue(18).ToString() == "13")
                row["주문구분"] = "최우선지정가";

            if (_CpConclusion.GetHeaderValue(19).ToString() == "0")
                row["주문조건"] = "없음";
            else if (_CpConclusion.GetHeaderValue(19).ToString() == "1")
                row["주문조건"] = "IOC";
            else if (_CpConclusion.GetHeaderValue(19).ToString() == "2")
                row["주문조건"] = "FOK";

            row["장부가"] = _CpConclusion.GetHeaderValue(21).ToString();
            row["체결기준잔고수량"] = _CpConclusion.GetHeaderValue(23).ToString();

            _stockTradeTable.Rows.InsertAt(row, 0);

            foreach (Form childForm in this.MdiChildren)
            {
                if (childForm.Text.Length >= 5)
                {
                    string title = childForm.Text.Substring(1, 4);
                    if (title == "1301" || title == "1302" || title == "1303" || title == "1304" || title == "1401" || title == "1402")
                        ((FormTrade)childForm).ReceivedStockTrade();
                }
            }
        }

        public void ReceivedStockReservedOrder()
        {
            foreach (Form childForm in this.MdiChildren)
            {
                if (childForm.Text.Length >= 5)
                {
                    string title = childForm.Text.Substring(1, 4);
                    if (title == "1205")
                        ((Form1205)childForm).ReceivedStockReservedOrder();
                }
            }
        }

        public void ChangedStockReservedOrderNo(string no)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                if (childForm.Text.Length >= 5)
                {
                    string title = childForm.Text.Substring(1, 4);
                    if (title == "1204")
                        ((Form1204)childForm).ChangedStockReservedOrderNo(no);
                }
            }
        }

        public void ShowStockReservedOrderList()
        {
            if (_form1205 != null && _form1205.Visible)
                _form1205.Close();

            _form1205 = new Form1205();
            _form1205.MdiParent = this;

            if (_form1204 != null && _form1204.Visible)
            {
                _form1205.StartPosition = FormStartPosition.Manual;
                _form1205.Location = new Point(_form1204.Location.X + _form1204.Size.Width, _form1204.Location.Y);
            }

            _form1205.TopMost = true;
            _form1205.Show();
        }

        private void 주식현금주문ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TradeInit();

            _form1201 = new Form1201();
            _form1201.MdiParent = this;
            _form1201.Show();
        }

        public void ShowStockQuote(Form sender)
        {   
            if (_form1106 != null && _form1106.Visible)
                _form1106.Close();

            _form1106 = new Form1106();
            _form1106.MdiParent = this;
            _form1106.StartPosition = FormStartPosition.Manual;

            if (sender.Equals(_form1201))
            {
                if (_form1201 != null && _form1201.Visible)
                    _form1106.Location = new Point(_form1201.Location.X + _form1201.Size.Width, _form1201.Location.Y);
                else
                    _form1106.Location = new Point(this.Width - _formStockCodes.Size.Width - _form1106.Size.Width - 30, 10);
            }
            else if (sender.Equals(_form1202))
            {
                if (_form1202 != null && _form1202.Visible)
                    _form1106.Location = new Point(_form1202.Location.X + _form1202.Size.Width, _form1202.Location.Y);
                else
                    _form1106.Location = new Point(this.Width - _formStockCodes.Size.Width - _form1106.Size.Width - 30, 10);
            }
            else if (sender.Equals(_form1204))
            {
                if (_form1204 != null && _form1204.Visible)
                    _form1106.Location = new Point(_form1204.Location.X + _form1204.Size.Width, _form1204.Location.Y);
                else
                    _form1106.Location = new Point(this.Width - _formStockCodes.Size.Width - _form1106.Size.Width - 30, 10);
            }

            _form1106.TopMost = true;
            _form1106.Show();
        }

        public void ShowStockBuyAble()
        {
            if (_form1202 != null && _form1202.Visible)
                _form1202.Close();

            _form1202 = new Form1202();
            _form1202.MdiParent = this;
            _form1202.StartPosition = FormStartPosition.Manual;
            _form1202.Location = new Point(_form1201.Location.X + _form1201.Size.Width, _form1201.Location.Y);
            _form1202.TopMost = true;
            _form1202.Show();
        }

        public void ShowStockSellAble()
        {
            if (_form1203 != null && _form1203.Visible)
                _form1203.Close();
            
            _form1203 = new Form1203();
            _form1203.MdiParent = this;
            _form1203.StartPosition = FormStartPosition.Manual;
            _form1203.Location = new Point(_form1201.Location.X + _form1201.Size.Width, _form1201.Location.Y);
            _form1203.TopMost = true;
            _form1203.Show();
        }

        public void ShowStockNoneTrade()
        {
            if (_form1303 != null && _form1303.Visible)
                _form1303.Close();

            _form1303 = new Form1303();
            _form1303.MdiParent = this;
            _form1303.StartPosition = FormStartPosition.Manual;
            _form1303.Location = new Point(_form1201.Location.X + _form1201.Size.Width, _form1201.Location.Y);
            _form1303.TopMost = true;
            _form1303.Show();
        }

        private void 주식계좌별매수가능금액수량ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TradeInit();

            _form1202 = new Form1202();
            _form1202.MdiParent = this;
            _form1202.Show();
        }

        private void 주식계좌별매도가능수량ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TradeInit();

            _form1203 = new Form1203();
            _form1203.MdiParent = this;
            _form1203.Show();
        }

        private void 주식예약주문ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TradeInit();

            _form1204 = new Form1204();
            _form1204.MdiParent = this;
            _form1204.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TradeInit();

            _form1205 = new Form1205();
            _form1205.MdiParent = this;
            _form1205.Show();
        }

        private void 금일계좌별주문체결내역ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TradeInit();

            _form1301 = new Form1301();
            _form1301.MdiParent = this;
            _form1301.Show();
        }

        private void 금일전일체결기준내역ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TradeInit();

            _form1302 = new Form1302();
            _form1302.MdiParent = this;
            _form1302.Show();
        }

        private void 계좌별미체결잔량ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TradeInit();

            _form1303 = new Form1303();
            _form1303.MdiParent = this;
            _form1303.Show();
        }

        private void 주식체결ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TradeInit();

            _form1304 = new Form1304();
            _form1304.MdiParent = this;
            _form1304.Show();
        }

        private void 주식주문종합화면ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
                childForm.Close();

            TradeInit();

            int xPos = 0;
            int yPos = 0;

            _form1201 = new Form1201();
            _form1201.MdiParent = this;
            _form1201.StartPosition = FormStartPosition.Manual;
            _form1201.Location = new Point(xPos, yPos);
            _form1201.Show();

            _form1402 = new Form1402();
            _form1402.MdiParent = this;
            _form1402.StartPosition = FormStartPosition.Manual;
            _form1402.Location = new Point(xPos, _form1201.Size.Height);
            _form1402.Show();

            _form1106 = new Form1106();
            _form1106.MdiParent = this;
            _form1106.StartPosition = FormStartPosition.Manual;
            _form1106.Location = new Point(xPos + _form1201.Size.Width, yPos);
            _form1106.Show();

            _form1301 = new Form1301();
            _form1301.MdiParent = this;
            _form1301.StartPosition = FormStartPosition.Manual;
            _form1301.Location = new Point(_form1201.Size.Width + _form1106.Size.Width, yPos);
            _form1301.Show();

            _form1304 = new Form1304();
            _form1304.MdiParent = this;
            _form1304.StartPosition = FormStartPosition.Manual;
            _form1304.Location = new Point(xPos, _form1106.Size.Height);
            _form1304.Show();

            _form1401 = new Form1401();
            _form1401.MdiParent = this;
            _form1401.StartPosition = FormStartPosition.Manual;
            _form1401.Location = new Point(_form1201.Size.Width + _form1106.Size.Width, _form1301.Size.Height);
            _form1401.Show();
        }

        private void 계좌별잔고평가현황ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TradeInit();

            _form1401 = new Form1401();
            _form1401.MdiParent = this;
            _form1401.Show();
        }

        private void 주식결제예정예수금가계산ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TradeInit();

            _form1402 = new Form1402();
            _form1402.MdiParent = this;
            _form1402.Show();
        }

        private void 나의전략ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _form6101 = new Form6101();
            _form6101.MdiParent = this;
            _form6101.SetScreenType("나의 전략");
            _form6101.Show();
        }

        private void 예제전략ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _form6101 = new Form6101();
            _form6101.MdiParent = this;
            _form6101.SetScreenType("예제 전략");
            _form6101.Show();
        }

        private void 전략검색결과ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _form6201 = new Form6201();
            _form6201.MdiParent = this;
            _form6201.Show();
        }

        private void 실시간감시ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _form6301 = new Form6301();
            _form6301.MdiParent = this;
            _form6301.Show();
        }

        private void 나의전략주문연동ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
                childForm.Close();

            this.TradeInit();

            int xPos = 0;
            int yPos = 0;
            int screenHeight = 320;

            xPos = 970;
            yPos = 0;
            _form1201 = new Form1201();
            _form1201.MdiParent = this;
            _form1201.StartPosition = FormStartPosition.Manual;
            _form1201.Location = new Point(xPos, yPos);
            _form1201.Show();

            yPos = _form1201.Height;
            _form1301 = new Form1301();
            _form1301.MdiParent = this;
            _form1301.StartPosition = FormStartPosition.Manual;
            _form1301.Location = new Point(xPos, yPos);
            _form1301.Show();
            _form1301.Height = screenHeight;

            yPos += _form1301.Height;
            _form1304 = new Form1304();
            _form1304.MdiParent = this;
            _form1304.StartPosition = FormStartPosition.Manual;
            _form1304.Location = new Point(xPos, yPos);
            _form1304.Show();
            _form1304.Height = screenHeight - 40;

            xPos += _form1201.Width;
            yPos = 0;
            _form1106 = new Form1106();
            _form1106.MdiParent = this;
            _form1106.StartPosition = FormStartPosition.Manual;
            _form1106.Location = new Point(xPos, yPos);
            _form1106.Show();

            xPos = 0;
            yPos = 0;
            _form6101 = new Form6101();
            _form6101.MdiParent = this;
            _form6101.SetScreenType("나의 전략");
            _form6101.StartPosition = FormStartPosition.Manual;
            _form6101.Location = new Point(xPos, yPos);
            _form6101.Show();
            _form6101.Height = screenHeight;

            yPos += _form6101.Height;
            _form6201 = new Form6201();
            _form6201.MdiParent = this;
            _form6201.StartPosition = FormStartPosition.Manual;
            _form6201.Location = new Point(xPos, yPos);
            _form6201.Show();
            _form6201.Height = screenHeight;

            yPos += _form6201.Height;
            _form6301 = new Form6301();
            _form6301.MdiParent = this;
            _form6301.StartPosition = FormStartPosition.Manual;
            _form6301.Location = new Point(xPos, yPos);
            _form6301.Show();
            _form6301.Height = screenHeight;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
                childForm.Close();

            this.TradeInit();

            int xPos = 0;
            int yPos = 0;
            int screenHeight = 320;

            xPos = 970;
            yPos = 0;
            _form1201 = new Form1201();
            _form1201.MdiParent = this;
            _form1201.StartPosition = FormStartPosition.Manual;
            _form1201.Location = new Point(xPos, yPos);
            _form1201.Show();

            yPos = _form1201.Height;
            _form1301 = new Form1301();
            _form1301.MdiParent = this;
            _form1301.StartPosition = FormStartPosition.Manual;
            _form1301.Location = new Point(xPos, yPos);
            _form1301.Show();
            _form1301.Height = screenHeight;

            yPos += _form1301.Height;
            _form1304 = new Form1304();
            _form1304.MdiParent = this;
            _form1304.StartPosition = FormStartPosition.Manual;
            _form1304.Location = new Point(xPos, yPos);
            _form1304.Show();
            _form1304.Height = screenHeight - 40;

            xPos += _form1201.Width;
            yPos = 0;
            _form1106 = new Form1106();
            _form1106.MdiParent = this;
            _form1106.StartPosition = FormStartPosition.Manual;
            _form1106.Location = new Point(xPos, yPos);
            _form1106.Show();

            xPos = 0;
            yPos = 0;
            _form6101 = new Form6101();
            _form6101.MdiParent = this;
            _form6101.SetScreenType("예제 전략");
            _form6101.StartPosition = FormStartPosition.Manual;
            _form6101.Location = new Point(xPos, yPos);
            _form6101.Show();
            _form6101.Height = screenHeight;

            yPos += _form6101.Height;
            _form6201 = new Form6201();
            _form6201.MdiParent = this;
            _form6201.StartPosition = FormStartPosition.Manual;
            _form6201.Location = new Point(xPos, yPos);
            _form6201.Show();
            _form6201.Height = screenHeight;

            yPos += _form6201.Height;
            _form6301 = new Form6301();
            _form6301.MdiParent = this;
            _form6301.StartPosition = FormStartPosition.Manual;
            _form6301.Location = new Point(xPos, yPos);
            _form6301.Show();
            _form6301.Height = screenHeight;
        }

        public void ShowSTGResultList(String id, String name)
        {
            _form6201 = new Form6201();
            _form6201.MdiParent = this;

            if (_form6201 != null)
            {
                _form6201.StartPosition = FormStartPosition.Manual;
                _form6201.Location = new Point(_form6101.Location.X, _form6101.Location.Y + _form6101.Size.Height);
            }

            _form6201.TopMost = true;
            _form6201.Show();
            _form6201.SetSTGInfo(id, name);
        }

        public void ShowSTGMonitor(String id, String name)
        {
            _form6301 = new Form6301();
            _form6301.MdiParent = this;

            if (_form6301 != null)
            {
                if (_form6201 != null)
                {
                    _form6301.StartPosition = FormStartPosition.Manual;
                    _form6301.Location = new Point(_form6201.Location.X, _form6201.Location.Y + _form6201.Size.Height);
                }
                else
                {
                    _form6301.StartPosition = FormStartPosition.Manual;
                    _form6301.Location = new Point(_form6101.Location.X, _form6101.Location.Y + _form6101.Size.Height);
                }
            }

            _form6301.TopMost = true;
            _form6301.Show();
            _form6301.SetSTGInfo(id, name);
        }
                
        public void ChangeSTG(String stgID, String stgName)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                if (childForm.Text.Length >= 5)
                {
                    String title = childForm.Text.Substring(1, 4);
                    if (title == "6201" || title == "6301")
                        ((FormMonitor)childForm).SetSTGInfo(stgID, stgName);
                }
            }
        }

        public void ShowStockOrder(object sender, int tabIndex)
        {
            this.TradeInit();

            _form1201 = new Form1201();
            _form1201.MdiParent = this;
            _form1201.StartPosition = FormStartPosition.Manual;

            if (sender.Equals(_form6201))
                _form1201.Location = new Point(_form6201.Location.X + _form6201.Size.Width, _form6201.Location.Y);
            else if (sender.Equals(_form6301))
                _form1201.Location = new Point(_form6201.Location.X + _form6201.Size.Width, _form6201.Location.Y);

            _form1201.TopMost = true;
            _form1201.Show();
            _form1201.ChangeTab(tabIndex);
        }

        public int GetRemainSB()
        {
            return _CpCybos.GetLimitRemainCount(CPUTILLib.LIMIT_TYPE.LT_SUBSCRIBE);
        }

        public void SendStockOrder(bool bBuy, String productCode, String quantity, String price, String trade, String condition)
        {
            this.TradeInit();

            _form1201 = new Form1201();
            _form1201.MdiParent = this;
            _form1201.SendStockOrder(bBuy, productCode, quantity, price, trade, condition);
        }
    }
}
