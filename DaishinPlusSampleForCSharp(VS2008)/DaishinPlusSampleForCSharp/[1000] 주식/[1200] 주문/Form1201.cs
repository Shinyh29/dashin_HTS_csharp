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
    public partial class Form1201 : Form, FormRoot, FormOrder
    {
        private FormMain _parent;

        CPTRADELib.CpTd0311 _CpTd0311;
        CPTRADELib.CpTd0303 _CpTd0303;
        CPTRADELib.CpTd0314 _CpTd0314;

        public Form1201()
        {
            InitializeComponent();
        }

        public void ChangedStockCode(string code, string name)
        {
            TextBoxName.Text = name;
            TextBoxCode.Text = code;
        }

        private void Form1201_Load(object sender, EventArgs e)
        {
            _parent = (FormMain)this.ParentForm;

            _CpTd0311 = new CPTRADELib.CpTd0311();
            _CpTd0303 = new CPTRADELib.CpTd0303();
            _CpTd0314 = new CPTRADELib.CpTd0314();

            TextBoxName.Text = _parent.stockName;
            TextBoxCode.Text = _parent.stockCode;

            TextBoxBuyCount.Text = "0";
            TextBoxBuyPrice.Text = "0";

            TextBoxSellCount.Text = "0";
            TextBoxSellPrice.Text = "0";

            TextBoxModifyCount.Text = "0";
            TextBoxModifyPrice.Text = "0";

            TextBoxCancelCount.Text = "0";

            ComboBoxBuyCondition.SelectedIndex = 0;
            ComboBoxBuyTrade.SelectedIndex = 0;

            ComboBoxSellCondition.SelectedIndex = 0;
            ComboBoxSellTrade.SelectedIndex = 0;

            ComboBoxModifyCondition.SelectedIndex = 0;
            ComboBoxModifyTrade.SelectedIndex = 0;

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

        private void Form1201_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void Form1201_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.CloseStockSelector(this);
        }

        private void ButtonSelectCode_Click(object sender, EventArgs e)
        {
            _parent.ShowStockSelector(this);
        }

        private void TextBoxCode_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxCode.Text.Length >= 7)
                TextBoxName.Text = _parent.FindStockName(TextBoxCode.Text.ToUpper());
        }

        private void ComboBoxAccountKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            _parent.ChangedAccountKind(ComboBoxAccountKind.SelectedText);
        }

        public void ChangedStockQuote(string price)
        {
            if (TabControl1.SelectedIndex == 0)
                TextBoxBuyPrice.Text = price;
            else if (TabControl1.SelectedIndex == 1)
                TextBoxSellPrice.Text = price;
            else if (TabControl1.SelectedIndex == 2)
                TextBoxModifyPrice.Text = price;
        }

        public void ChangedStockCount(string count)
        {
            if (TabControl1.SelectedIndex == 0)
                TextBoxBuyCount.Text = count;
            else if (TabControl1.SelectedIndex == 1)
                TextBoxSellCount.Text = count;
            else if (TabControl1.SelectedIndex == 2)
                TextBoxModifyCount.Text = count;
            else if (TabControl1.SelectedIndex == 3)
                TextBoxCancelCount.Text = count;
        }

        public void ChangedStockNoneTradeNo(string no, string count)
        {
            if (TabControl1.SelectedIndex == 2)
            {
                TextBoxOriginNo.Text = no;
                TextBoxModifyCount.Text = count;
            }
            else if (TabControl1.SelectedIndex == 3)
            {
                TextBoxCancelOriginNo.Text = no;
                TextBoxCancelCount.Text = count;
            }
        }

        private void ButtonBuyDown_Click(object sender, EventArgs e)
        {
            TextBoxBuyCount.Text = (Int32.Parse(TextBoxBuyCount.Text) - 1).ToString();

            if (Int32.Parse(TextBoxBuyCount.Text) <= 0)
                TextBoxBuyCount.Text = "0";
        }

        private void ButtonBuyUp_Click(object sender, EventArgs e)
        {
            TextBoxBuyCount.Text = (Int32.Parse(TextBoxBuyCount.Text) + 1).ToString();
        }

        private void ButtonBuyAble_Click(object sender, EventArgs e)
        {
            _parent.ShowStockBuyAble();
        }

        private void ButtonBuyPrice_Click(object sender, EventArgs e)
        {
            _parent.ShowStockQuote(this);
        }

        private void ButtonOrderBuy_Click(object sender, EventArgs e)
        {
            if (_CpTd0311.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                return;
            }

            LabelMsg1.Text = "";

            _CpTd0311.SetInputValue(0, "2");                                                             // 1:매도, 2:매수
            _CpTd0311.SetInputValue(1, TextBoxAccountNo1.Text + TextBoxAccountNo2.Text);                 // 계좌번호
            _CpTd0311.SetInputValue(2, ComboBoxAccountKind.SelectedItem);                                // 상품구분코드
            _CpTd0311.SetInputValue(3, TextBoxCode.Text.ToUpper());                                      // 종목코드
            _CpTd0311.SetInputValue(4, TextBoxBuyCount.Text);                                            // 매수수량
            _CpTd0311.SetInputValue(7, ComboBoxBuyCondition.SelectedItem.ToString().Substring(0, 1));    // 주문조건구분코드(0:없음,1:IOC, 2:FOK)

            string trade = ComboBoxBuyTrade.SelectedItem.ToString().Substring(0, 2);
            _CpTd0311.SetInputValue(5, TextBoxBuyPrice.Text);                                            // 매수단가
            _CpTd0311.SetInputValue(8, trade);                                                           // 주문호가구분코드(01:보통)

            _CpTd0311.BlockRequest();

            LabelMsg1.Text = _CpTd0311.GetDibMsg1();
        }

        private void ButtonHelp1_Click(object sender, EventArgs e)
        {
            _parent.ShowHelp("12011");
        }

        private void ButtonSellDown_Click(object sender, EventArgs e)
        {
            TextBoxSellCount.Text = (Int32.Parse(TextBoxSellCount.Text) - 1).ToString();

            if (Int32.Parse(TextBoxSellCount.Text) <= 0)
                TextBoxSellCount.Text = "0";
        }

        private void ButtonSellUp_Click(object sender, EventArgs e)
        {
            TextBoxSellCount.Text = (Int32.Parse(TextBoxSellCount.Text) + 1).ToString();
        }

        private void ButtonSellAble_Click(object sender, EventArgs e)
        {
            _parent.ShowStockSellAble();
        }

        private void ButtonSellPrice_Click(object sender, EventArgs e)
        {
            _parent.ShowStockQuote(this);
        }

        private void ButtonOrderSell_Click(object sender, EventArgs e)
        {
            if (_CpTd0311.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                return;
            }

            LabelMsg1.Text = "";

            _CpTd0311.SetInputValue(0, "1");                                                             // 1:매도, 2:매수
            _CpTd0311.SetInputValue(1, TextBoxAccountNo1.Text + TextBoxAccountNo2.Text);                 // 계좌번호
            _CpTd0311.SetInputValue(2, ComboBoxAccountKind.SelectedItem);                                // 상품구분코드
            _CpTd0311.SetInputValue(3, TextBoxCode.Text.ToUpper());                                      // 종목코드
            _CpTd0311.SetInputValue(4, TextBoxSellCount.Text);                                           // 매도 수량
            _CpTd0311.SetInputValue(7, ComboBoxSellCondition.SelectedItem.ToString().Substring(0, 1));   // 주문조건구분코드(0:없음,1:IOC, 2:FOK)
            
            string trade = ComboBoxSellTrade.SelectedItem.ToString().Substring(0, 2);
            _CpTd0311.SetInputValue(5, TextBoxSellPrice.Text);                                           // 매도단가
            
            _CpTd0311.SetInputValue(8, trade);                                                           // 주문호가구분코드(01:보통)

            _CpTd0311.BlockRequest();

            LabelMsg1.Text = _CpTd0311.GetDibMsg1();
        }

        private void ButtonHelpSell_Click(object sender, EventArgs e)
        {
            _parent.ShowHelp("12011");
        }

        private void ButtonModifyNoneTrade_Click(object sender, EventArgs e)
        {
            _parent.ShowStockNoneTrade();
        }

        private void ButtonModifyDown_Click(object sender, EventArgs e)
        {
            TextBoxModifyCount.Text = (Int32.Parse(TextBoxModifyCount.Text) - 1).ToString();

            if (Int32.Parse(TextBoxModifyCount.Text) <= 0)
                TextBoxModifyCount.Text = "0";
        }

        private void ButtonModifyUp_Click(object sender, EventArgs e)
        {
            TextBoxModifyCount.Text = (Int32.Parse(TextBoxModifyCount.Text) + 1).ToString();
        }

        private void ButtonModifyPrice_Click(object sender, EventArgs e)
        {
            _parent.ShowStockQuote(this);
        }

        private void ButtonOrderModify_Click(object sender, EventArgs e)
        {
            if (_CpTd0303.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                return;
            }

            if (TextBoxOriginNo.Text == "")
            {
                MessageBox.Show("원주문번호를 입력하세요");
                return;
            }

            LabelMsg1.Text = "";

            _CpTd0303.SetInputValue(1, TextBoxOriginNo.Text);
            _CpTd0303.SetInputValue(2, TextBoxAccountNo1.Text + TextBoxAccountNo2.Text);
            _CpTd0303.SetInputValue(3, ComboBoxAccountKind.SelectedItem);
            _CpTd0303.SetInputValue(4, TextBoxCode.Text.ToUpper());
            _CpTd0303.SetInputValue(5, TextBoxModifyCount.Text);
            _CpTd0303.SetInputValue(8, ComboBoxModifyCondition.SelectedItem.ToString().Substring(0, 1));
            _CpTd0303.SetInputValue(6, TextBoxModifyPrice.Text);
            string trade = ComboBoxModifyTrade.SelectedItem.ToString().Substring(0, 2);
            _CpTd0303.SetInputValue(9, trade);

            _CpTd0303.BlockRequest();

            LabelMsg1.Text = _CpTd0303.GetDibMsg1();
        }

        private void ButtonHelpModify_Click(object sender, EventArgs e)
        {
            _parent.ShowHelp("12013");
        }

        private void ButtonCancelNoneTrade_Click(object sender, EventArgs e)
        {
            _parent.ShowStockNoneTrade();
        }

        private void ButtonCancelDown_Click(object sender, EventArgs e)
        {
            TextBoxCancelCount.Text = (Int32.Parse(TextBoxCancelCount.Text) - 1).ToString();

            if (Int32.Parse(TextBoxCancelCount.Text) < 0)
                TextBoxCancelCount.Text = "0";
        }

        private void ButtonCancelUp_Click(object sender, EventArgs e)
        {
            TextBoxCancelCount.Text = (Int32.Parse(TextBoxCancelCount.Text) + 1).ToString();
        }

        private void ButtonOrderCancel_Click(object sender, EventArgs e)
        {
            if (_CpTd0314.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                return;
            }

            if (TextBoxCancelOriginNo.Text == "")
            {
                MessageBox.Show("원주문번호를 입력하세요");
                return;
            }

            LabelMsg1.Text = "";

            _CpTd0314.SetInputValue(1, TextBoxCancelOriginNo.Text);
            _CpTd0314.SetInputValue(2, TextBoxAccountNo1.Text + TextBoxAccountNo2.Text);
            _CpTd0314.SetInputValue(3, ComboBoxAccountKind.SelectedItem);
            _CpTd0314.SetInputValue(4, TextBoxCode.Text.ToUpper());
            _CpTd0314.SetInputValue(5, TextBoxCancelCount.Text);

            _CpTd0314.BlockRequest();

            LabelMsg1.Text = _CpTd0314.GetDibMsg1();
        }

        private void ButtonHelpCancel_Click(object sender, EventArgs e)
        {
            _parent.ShowHelp("12014");
        }

        public void ChangeTab(int index)
        {
            TabControl1.SelectedIndex = index;
        }
                
        public void SendStockOrder(bool bBuy, String productCode, String quantity, String price, String trade, String condition)
        {
            _parent = (FormMain)this.ParentForm;

            if (_CpTd0311 == null)
                _CpTd0311 = new CPTRADELib.CpTd0311();

            _CpTd0311.SetInputValue(1, _parent.accountNo);                                               // 계좌번호
            _CpTd0311.SetInputValue(2, _parent.accountGoodsStock);                                       // 상품구분코드
            _CpTd0311.SetInputValue(3, productCode);                                                     // 종목코드
            _CpTd0311.SetInputValue(4, quantity);                                                        // 매수수량
            _CpTd0311.SetInputValue(7, condition);                                                       // 주문조건구분코드(0:없음,1:IOC, 2:FOK)
            _CpTd0311.SetInputValue(5, price);                                                           // 매수단가
            _CpTd0311.SetInputValue(8, trade);                                                           // 주문호가구분코드(01:보통)

            if (bBuy)
                _CpTd0311.SetInputValue(0, "2");                                                         // 1:매도, 2:매수
            else
                _CpTd0311.SetInputValue(0, "1");                                                         // 1:매도, 2:매수

            _CpTd0311.BlockRequest();
        }
    }
}
