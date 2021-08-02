namespace DaishinPlusSampleForCSharp._1000__주식._1100__시세
{
    partial class Form1104
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1104));
            this.CheckBoxTop = new System.Windows.Forms.CheckBox();
            this.LabelContinue = new System.Windows.Forms.Label();
            this.LabelMsg2 = new System.Windows.Forms.Label();
            this.LabelBuy = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.LabelSell = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.LabelMsg1 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.Button1 = new System.Windows.Forms.Button();
            this.ButtonNext = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.ComboBoxMethod = new System.Windows.Forms.ComboBox();
            this.ButtonQuery = new System.Windows.Forms.Button();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Button2 = new System.Windows.Forms.Button();
            this.GroupBoxRQ = new System.Windows.Forms.GroupBox();
            this.TextBoxCode = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.GroupBoxRQ.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckBoxTop
            // 
            this.CheckBoxTop.AutoSize = true;
            this.CheckBoxTop.Checked = true;
            this.CheckBoxTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxTop.Location = new System.Drawing.Point(583, 121);
            this.CheckBoxTop.Name = "CheckBoxTop";
            this.CheckBoxTop.Size = new System.Drawing.Size(202, 16);
            this.CheckBoxTop.TabIndex = 40;
            this.CheckBoxTop.Text = "최근 데이터 보기(실시간 수신시)";
            this.CheckBoxTop.UseVisualStyleBackColor = true;
            // 
            // LabelContinue
            // 
            this.LabelContinue.AutoSize = true;
            this.LabelContinue.ForeColor = System.Drawing.Color.Blue;
            this.LabelContinue.Location = new System.Drawing.Point(610, 18);
            this.LabelContinue.Name = "LabelContinue";
            this.LabelContinue.Size = new System.Drawing.Size(0, 12);
            this.LabelContinue.TabIndex = 25;
            // 
            // LabelMsg2
            // 
            this.LabelMsg2.AutoSize = true;
            this.LabelMsg2.ForeColor = System.Drawing.Color.Blue;
            this.LabelMsg2.Location = new System.Drawing.Point(360, 18);
            this.LabelMsg2.Name = "LabelMsg2";
            this.LabelMsg2.Size = new System.Drawing.Size(0, 12);
            this.LabelMsg2.TabIndex = 24;
            // 
            // LabelBuy
            // 
            this.LabelBuy.AutoSize = true;
            this.LabelBuy.ForeColor = System.Drawing.Color.Red;
            this.LabelBuy.Location = new System.Drawing.Point(347, 120);
            this.LabelBuy.Name = "LabelBuy";
            this.LabelBuy.Size = new System.Drawing.Size(0, 12);
            this.LabelBuy.TabIndex = 39;
            this.LabelBuy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.ForeColor = System.Drawing.Color.Red;
            this.Label5.Location = new System.Drawing.Point(233, 121);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(105, 12);
            this.Label5.TabIndex = 38;
            this.Label5.Text = "누적 매수 체결량 :";
            // 
            // LabelSell
            // 
            this.LabelSell.AutoSize = true;
            this.LabelSell.ForeColor = System.Drawing.Color.Blue;
            this.LabelSell.Location = new System.Drawing.Point(122, 120);
            this.LabelSell.Name = "LabelSell";
            this.LabelSell.Size = new System.Drawing.Size(0, 12);
            this.LabelSell.TabIndex = 37;
            this.LabelSell.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.Color.Blue;
            this.Label1.Location = new System.Drawing.Point(8, 121);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(105, 12);
            this.Label1.TabIndex = 36;
            this.Label1.Text = "누적 매도 체결량 :";
            // 
            // LabelMsg1
            // 
            this.LabelMsg1.AutoSize = true;
            this.LabelMsg1.ForeColor = System.Drawing.Color.Blue;
            this.LabelMsg1.Location = new System.Drawing.Point(17, 18);
            this.LabelMsg1.Name = "LabelMsg1";
            this.LabelMsg1.Size = new System.Drawing.Size(0, 12);
            this.LabelMsg1.TabIndex = 23;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.LabelContinue);
            this.GroupBox1.Controls.Add(this.LabelMsg2);
            this.GroupBox1.Controls.Add(this.LabelMsg1);
            this.GroupBox1.ForeColor = System.Drawing.Color.Blue;
            this.GroupBox1.Location = new System.Drawing.Point(3, 68);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(787, 41);
            this.GroupBox1.TabIndex = 35;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "조회 상태";
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DataGridView1.Location = new System.Drawing.Point(0, 142);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.RowHeadersVisible = false;
            this.DataGridView1.RowTemplate.Height = 23;
            this.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DataGridView1.Size = new System.Drawing.Size(792, 369);
            this.DataGridView1.TabIndex = 34;
            this.DataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView1_CellFormatting);
            this.DataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridView1_DataBindingComplete);
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Button1.Location = new System.Drawing.Point(712, 15);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(69, 47);
            this.Button1.TabIndex = 33;
            this.Button1.Text = "도움말\r\n";
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ButtonNext
            // 
            this.ButtonNext.Location = new System.Drawing.Point(594, 11);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(65, 48);
            this.ButtonNext.TabIndex = 29;
            this.ButtonNext.Text = "다음";
            this.ButtonNext.UseVisualStyleBackColor = true;
            this.ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(293, 29);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(81, 12);
            this.Label2.TabIndex = 28;
            this.Label2.Text = "체결 비교방식";
            // 
            // ComboBoxMethod
            // 
            this.ComboBoxMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxMethod.FormattingEnabled = true;
            this.ComboBoxMethod.Items.AddRange(new object[] {
            "체결가 비교방식",
            "호가 비교방식"});
            this.ComboBoxMethod.Location = new System.Drawing.Point(382, 25);
            this.ComboBoxMethod.Name = "ComboBoxMethod";
            this.ComboBoxMethod.Size = new System.Drawing.Size(121, 20);
            this.ComboBoxMethod.TabIndex = 27;
            this.ComboBoxMethod.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMethod_SelectedIndexChanged);
            // 
            // ButtonQuery
            // 
            this.ButtonQuery.Location = new System.Drawing.Point(523, 11);
            this.ButtonQuery.Name = "ButtonQuery";
            this.ButtonQuery.Size = new System.Drawing.Size(65, 48);
            this.ButtonQuery.TabIndex = 6;
            this.ButtonQuery.Text = "조회";
            this.ButtonQuery.UseVisualStyleBackColor = true;
            this.ButtonQuery.Click += new System.EventHandler(this.ButtonQuery_Click);
            // 
            // TextBoxName
            // 
            this.TextBoxName.BackColor = System.Drawing.Color.White;
            this.TextBoxName.Location = new System.Drawing.Point(76, 39);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.ReadOnly = true;
            this.TextBoxName.Size = new System.Drawing.Size(148, 21);
            this.TextBoxName.TabIndex = 26;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(16, 44);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(41, 12);
            this.Label3.TabIndex = 25;
            this.Label3.Text = "종목명";
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(232, 11);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(53, 48);
            this.Button2.TabIndex = 24;
            this.Button2.Text = "종목\r\n선택";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // GroupBoxRQ
            // 
            this.GroupBoxRQ.Controls.Add(this.ButtonNext);
            this.GroupBoxRQ.Controls.Add(this.Label2);
            this.GroupBoxRQ.Controls.Add(this.ComboBoxMethod);
            this.GroupBoxRQ.Controls.Add(this.ButtonQuery);
            this.GroupBoxRQ.Controls.Add(this.TextBoxName);
            this.GroupBoxRQ.Controls.Add(this.Label3);
            this.GroupBoxRQ.Controls.Add(this.Button2);
            this.GroupBoxRQ.Controls.Add(this.TextBoxCode);
            this.GroupBoxRQ.Controls.Add(this.Label4);
            this.GroupBoxRQ.Location = new System.Drawing.Point(3, 2);
            this.GroupBoxRQ.Name = "GroupBoxRQ";
            this.GroupBoxRQ.Size = new System.Drawing.Size(671, 63);
            this.GroupBoxRQ.TabIndex = 32;
            this.GroupBoxRQ.TabStop = false;
            this.GroupBoxRQ.Text = "요청";
            // 
            // TextBoxCode
            // 
            this.TextBoxCode.Location = new System.Drawing.Point(76, 12);
            this.TextBoxCode.Name = "TextBoxCode";
            this.TextBoxCode.Size = new System.Drawing.Size(148, 21);
            this.TextBoxCode.TabIndex = 23;
            this.TextBoxCode.TextChanged += new System.EventHandler(this.TextBoxCode_TextChanged);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(16, 17);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(53, 12);
            this.Label4.TabIndex = 22;
            this.Label4.Text = "종목코드";
            // 
            // Form1104
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 513);
            this.Controls.Add(this.CheckBoxTop);
            this.Controls.Add(this.LabelBuy);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.LabelSell);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.GroupBoxRQ);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1104";
            this.Text = "[1104] 주식 시간대별 체결 (CpDib.StockBid)";
            this.Load += new System.EventHandler(this.Form1104_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1104_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1104_KeyDown);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.GroupBoxRQ.ResumeLayout(false);
            this.GroupBoxRQ.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox CheckBoxTop;
        internal System.Windows.Forms.Label LabelContinue;
        internal System.Windows.Forms.Label LabelMsg2;
        internal System.Windows.Forms.Label LabelBuy;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label LabelSell;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label LabelMsg1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Button ButtonNext;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox ComboBoxMethod;
        internal System.Windows.Forms.Button ButtonQuery;
        internal System.Windows.Forms.TextBox TextBoxName;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.GroupBox GroupBoxRQ;
        internal System.Windows.Forms.TextBox TextBoxCode;
        internal System.Windows.Forms.Label Label4;
    }
}