using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using DaishinPlusSampleForCSharp.Common;
using CPUTILLib;

namespace DaishinPlusSampleForCSharp._1000__주식._1100__시세
{
    public partial class Form1102 : Form, FormRoot
    {
        private FormMain _parent;
        private CPSYSDIBLib.MarketEye _marketEye;
        private DSCBO1Lib.StockCur _stockCur;
        private DataTable _stockTable;

        public Form1102()
        {
            InitializeComponent();
        }
        
        private void Form1102_Load(object sender, EventArgs e)
        {
            _parent = (FormMain)this.ParentForm;

            _stockCur = new DSCBO1Lib.StockCur();
            _marketEye = new CPSYSDIBLib.MarketEye();

            _stockCur.Received += new DSCBO1Lib._IDibEvents_ReceivedEventHandler(_stockCur_Received);

            _stockTable = new DataTable();
            _stockTable.Columns.Add("종목코드");
            _stockTable.Columns.Add("종목명");
            _stockTable.Columns.Add("시간");
            _stockTable.Columns.Add("현재가");
            _stockTable.Columns.Add("전일대비");
            _stockTable.Columns.Add("시가");
            _stockTable.Columns.Add("고가");
            _stockTable.Columns.Add("저가");
            _stockTable.Columns.Add("거래량");
            _stockTable.Columns.Add("거래대금");

            DataGridView1.DataSource = _stockTable;
            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridView1.AllowUserToResizeRows = false;
            DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridView1.Refresh();

            TextBoxName.Text = _parent.stockName;
            TextBoxCode.Text = _parent.stockCode;
        }
  
        public void ChangedStockCode(string code, string name)
        {
            TextBoxName.Text = name;
            TextBoxCode.Text = code;
        }

        private void Unsubscribe()
        {
            for (int i = 0; i < _stockTable.Rows.Count; i++)
            {
                _stockCur.SetInputValue(0, _stockTable.Rows[i][0].ToString());
                _stockCur.Unsubscribe();
            }
        }

        private void TextBoxCode_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxCode.Text.Length >= 7)
            {
                TextBoxName.Text = _parent.FindStockName(TextBoxCode.Text.ToUpper());
                bool bExist = false;

                for (int i = 0; i < _stockTable.Rows.Count; i++)
                {
                    if (_stockTable.Rows[i]["종목코드"].ToString() == TextBoxCode.Text.ToString())
                    {
                        bExist = true;
                        break;
                    }
                }

                if (bExist == false)
                {
                    _stockTable.Rows.Add(TextBoxCode.Text.ToUpper(), TextBoxName.Text, "", "", "", "", "", "", "", "");
                    DataGridView1.Refresh();

                    Button5_Click(null, null);
                }
            }
        }

        private void ButtonSelectCode_Click(object sender, EventArgs e)
        {
            _parent.ShowStockSelector(this);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (_marketEye.GetDibStatus() == 1)
            {
                Trace.TraceInformation("DibRq 요청 수신대기 중 입니다. 수신이 완료된 후 다시 호출 하십시오.");
                return;
            }

            if (_stockTable.Rows.Count <= 0)
                return;

            LabelMsg1.Text = "";
            
            Unsubscribe();

            int [] items = new int[] {0, 1, 2, 3, 4, 5, 6, 7, 10, 11, 17};
            _marketEye.SetInputValue(0, items);

            string [] sCodes = new string[_stockTable.Rows.Count];

            for (int i = 0; i < _stockTable.Rows.Count; i++)
                sCodes[i] = _stockTable.Rows[i]["종목코드"].ToString();
            
            _marketEye.SetInputValue(1, sCodes);

            int result = -1;
            result = _marketEye.BlockRequest();

            LabelMsg1.Text = _marketEye.GetDibMsg1();

            if (result == 0)
            {
                for (int j = 0; j < Int32.Parse(_marketEye.GetHeaderValue(2).ToString()); j++)
                {
                    _stockTable.Rows[j]["종목코드"] = _marketEye.GetDataValue(0, j);
                    _stockTable.Rows[j]["종목명"] = _marketEye.GetDataValue(10, j);
                    _stockTable.Rows[j]["시간"] = ClassUtil.ConvertToDateTime(_marketEye.GetDataValue(1, j).ToString());
                    _stockTable.Rows[j]["현재가"] = _marketEye.GetDataValue(4, j);
                    _stockTable.Rows[j]["전일대비"] = _marketEye.GetDataValue(3, j);
                    _stockTable.Rows[j]["시가"] = _marketEye.GetDataValue(5, j);
                    _stockTable.Rows[j]["고가"] = _marketEye.GetDataValue(6, j);
                    _stockTable.Rows[j]["저가"] = _marketEye.GetDataValue(7, j);
                    _stockTable.Rows[j]["거래량"] = _marketEye.GetDataValue(8, j);
                    _stockTable.Rows[j]["거래대금"] = _marketEye.GetDataValue(9, j);

                    _stockCur.SetInputValue(0, _stockTable.Rows[j][0]);
                    _stockCur.Subscribe();
                }

                DataGridView1.Refresh();
            }
        }
        
        private void _stockCur_Received()
        {
            for (int i = 0; i < _stockTable.Rows.Count; i++)
            {
                if (_stockTable.Rows[i][0] == _stockCur.GetHeaderValue(0))
                {
                    _stockTable.Rows[i]["현재가"] = _stockCur.GetHeaderValue(13);
                    _stockTable.Rows[i]["전일대비"] = _stockCur.GetHeaderValue(2);
                    _stockTable.Rows[i]["시간"] = ClassUtil.ConvertToDateTime(_stockCur.GetHeaderValue(3).ToString());
                    _stockTable.Rows[i]["고가"] = _stockCur.GetHeaderValue(5);
                    _stockTable.Rows[i]["저가"] = _stockCur.GetHeaderValue(6);
                    _stockTable.Rows[i]["거래량"] = _stockCur.GetHeaderValue(9);

                    CPE_MARKET_KIND market = _parent.GetStockMarketKind(_stockTable.Rows[i][0].ToString());
                    if (market == CPE_MARKET_KIND.CPC_MARKET_KOSPI)
                        _stockTable.Rows[i]["거래대금"] = Convert.ToString(Convert.ToInt32(_stockCur.GetHeaderValue(10)) * 10000);
                    else if (market == CPE_MARKET_KIND.CPC_MARKET_KOSDAQ || market == CPE_MARKET_KIND.CPC_MARKET_FREEBOARD)
                        _stockTable.Rows[i]["거래대금"] = Convert.ToString(Convert.ToInt32(_stockCur.GetHeaderValue(10)) * 1000);
                    else
                        _stockTable.Rows[i]["거래대금"] = _stockCur.GetHeaderValue(10);
                
                    DataGridView1.Refresh();
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedRows.Count > 0)
            {
                if (_stockTable.Rows.Count > 0 && DataGridView1.SelectedRows[0].Index < _stockTable.Rows.Count)
                {
                    _stockTable.Rows.RemoveAt(DataGridView1.SelectedRows[0].Index);
                    DataGridView1.Refresh();
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            _parent.ShowHelp("1102");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            _parent.ShowHelp("11021");
        }

        private void Form1102_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.CloseStockSelector(this);
        }

        private void Form1102_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _parent.ChangedStockCode(_stockTable.Rows[e.RowIndex][0].ToString(), _stockTable.Rows[e.RowIndex][1].ToString());
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView1.ClearSelection();
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            else if (e.ColumnIndex == 1)
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            else if (e.ColumnIndex == 2)
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (e.ColumnIndex == 4 && e.Value.ToString() != "")
            {
                if (Int32.Parse(e.Value.ToString()) > 0)
                    e.CellStyle.ForeColor = Color.Red;
                else if (Int32.Parse(e.Value.ToString()) < 0)
                    e.CellStyle.ForeColor = Color.Blue;
                else
                    e.CellStyle.ForeColor = Color.Black;
            }
        }
    }
}
