namespace DaishinPlusSampleForCSharp._1000__주식._1200__주문
{
    partial class Form1202
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1202));
            this.TextBoxCode = new System.Windows.Forms.TextBox();
            this.TextBoxAccountNo2 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.ButtonSelectCode = new System.Windows.Forms.Button();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.LabelMsg1 = new System.Windows.Forms.Label();
            this.ComboBoxAccountKind = new System.Windows.Forms.ComboBox();
            this.TextBoxAccountNo1 = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.ComboBoxQueryKind = new System.Windows.Forms.ComboBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.CheckBoxCharge = new System.Windows.Forms.CheckBox();
            this.ButtonHelp1 = new System.Windows.Forms.Button();
            this.ButtonQuery = new System.Windows.Forms.Button();
            this.DataGridView2 = new System.Windows.Forms.DataGridView();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ButtonBuyPrice = new System.Windows.Forms.Button();
            this.TextBoxPrice = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.ComboBoxTrade = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBoxCode
            // 
            this.TextBoxCode.Location = new System.Drawing.Point(75, 18);
            this.TextBoxCode.Name = "TextBoxCode";
            this.TextBoxCode.Size = new System.Drawing.Size(124, 21);
            this.TextBoxCode.TabIndex = 1;
            this.TextBoxCode.TextChanged += new System.EventHandler(this.TextBoxCode_TextChanged);
            // 
            // TextBoxAccountNo2
            // 
            this.TextBoxAccountNo2.BackColor = System.Drawing.Color.White;
            this.TextBoxAccountNo2.Enabled = false;
            this.TextBoxAccountNo2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TextBoxAccountNo2.Location = new System.Drawing.Point(57, 41);
            this.TextBoxAccountNo2.Name = "TextBoxAccountNo2";
            this.TextBoxAccountNo2.ReadOnly = true;
            this.TextBoxAccountNo2.Size = new System.Drawing.Size(58, 21);
            this.TextBoxAccountNo2.TabIndex = 2;
            this.TextBoxAccountNo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(15, 23);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(53, 12);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "종목코드";
            // 
            // TextBoxName
            // 
            this.TextBoxName.BackColor = System.Drawing.Color.White;
            this.TextBoxName.Location = new System.Drawing.Point(75, 45);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.ReadOnly = true;
            this.TextBoxName.Size = new System.Drawing.Size(124, 21);
            this.TextBoxName.TabIndex = 5;
            // 
            // ButtonSelectCode
            // 
            this.ButtonSelectCode.Location = new System.Drawing.Point(209, 17);
            this.ButtonSelectCode.Name = "ButtonSelectCode";
            this.ButtonSelectCode.Size = new System.Drawing.Size(53, 48);
            this.ButtonSelectCode.TabIndex = 3;
            this.ButtonSelectCode.Text = "종목\r\n선택";
            this.ButtonSelectCode.UseVisualStyleBackColor = true;
            this.ButtonSelectCode.Click += new System.EventHandler(this.ButtonSelectCode_Click);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.LabelMsg1);
            this.GroupBox3.ForeColor = System.Drawing.Color.Blue;
            this.GroupBox3.Location = new System.Drawing.Point(6, 85);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(885, 41);
            this.GroupBox3.TabIndex = 54;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "조회 상태";
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
            // ComboBoxAccountKind
            // 
            this.ComboBoxAccountKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxAccountKind.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ComboBoxAccountKind.FormattingEnabled = true;
            this.ComboBoxAccountKind.Location = new System.Drawing.Point(124, 42);
            this.ComboBoxAccountKind.Name = "ComboBoxAccountKind";
            this.ComboBoxAccountKind.Size = new System.Drawing.Size(38, 20);
            this.ComboBoxAccountKind.TabIndex = 3;
            this.ComboBoxAccountKind.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAccountKind_SelectedIndexChanged);
            // 
            // TextBoxAccountNo1
            // 
            this.TextBoxAccountNo1.BackColor = System.Drawing.Color.White;
            this.TextBoxAccountNo1.Enabled = false;
            this.TextBoxAccountNo1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TextBoxAccountNo1.Location = new System.Drawing.Point(11, 41);
            this.TextBoxAccountNo1.Name = "TextBoxAccountNo1";
            this.TextBoxAccountNo1.ReadOnly = true;
            this.TextBoxAccountNo1.Size = new System.Drawing.Size(32, 21);
            this.TextBoxAccountNo1.TabIndex = 1;
            this.TextBoxAccountNo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(24, 21);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(77, 12);
            this.Label3.TabIndex = 6;
            this.Label3.Text = "종합계좌번호";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label5.Location = new System.Drawing.Point(6, 216);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(83, 12);
            this.Label5.TabIndex = 69;
            this.Label5.Text = "주문가능수량";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label4.Location = new System.Drawing.Point(6, 133);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(83, 12);
            this.Label4.TabIndex = 67;
            this.Label4.Text = "주문가능금액";
            // 
            // ComboBoxQueryKind
            // 
            this.ComboBoxQueryKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxQueryKind.FormattingEnabled = true;
            this.ComboBoxQueryKind.Items.AddRange(new object[] {
            "금액 조회",
            "수량 조회"});
            this.ComboBoxQueryKind.Location = new System.Drawing.Point(649, 31);
            this.ComboBoxQueryKind.Name = "ComboBoxQueryKind";
            this.ComboBoxQueryKind.Size = new System.Drawing.Size(91, 20);
            this.ComboBoxQueryKind.TabIndex = 66;
            this.ComboBoxQueryKind.SelectedIndexChanged += new System.EventHandler(this.ComboBoxQueryKind_SelectedIndexChanged);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(133, 21);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(29, 12);
            this.Label7.TabIndex = 14;
            this.Label7.Text = "구분";
            // 
            // CheckBoxCharge
            // 
            this.CheckBoxCharge.AutoSize = true;
            this.CheckBoxCharge.Location = new System.Drawing.Point(687, 133);
            this.CheckBoxCharge.Name = "CheckBoxCharge";
            this.CheckBoxCharge.Size = new System.Drawing.Size(200, 16);
            this.CheckBoxCharge.TabIndex = 65;
            this.CheckBoxCharge.Text = "미수발생 증거금 100% 징수 여부";
            this.CheckBoxCharge.UseVisualStyleBackColor = true;
            // 
            // ButtonHelp1
            // 
            this.ButtonHelp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ButtonHelp1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ButtonHelp1.Location = new System.Drawing.Point(836, 19);
            this.ButtonHelp1.Name = "ButtonHelp1";
            this.ButtonHelp1.Size = new System.Drawing.Size(58, 43);
            this.ButtonHelp1.TabIndex = 64;
            this.ButtonHelp1.Text = "도움말";
            this.ButtonHelp1.UseVisualStyleBackColor = false;
            this.ButtonHelp1.Click += new System.EventHandler(this.ButtonHelp1_Click);
            // 
            // ButtonQuery
            // 
            this.ButtonQuery.Location = new System.Drawing.Point(752, 19);
            this.ButtonQuery.Name = "ButtonQuery";
            this.ButtonQuery.Size = new System.Drawing.Size(72, 43);
            this.ButtonQuery.TabIndex = 63;
            this.ButtonQuery.Text = "조회";
            this.ButtonQuery.UseVisualStyleBackColor = true;
            this.ButtonQuery.Click += new System.EventHandler(this.ButtonQuery_Click);
            // 
            // DataGridView2
            // 
            this.DataGridView2.AllowUserToAddRows = false;
            this.DataGridView2.AllowUserToDeleteRows = false;
            this.DataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DataGridView2.Location = new System.Drawing.Point(1, 235);
            this.DataGridView2.Name = "DataGridView2";
            this.DataGridView2.ReadOnly = true;
            this.DataGridView2.RowHeadersVisible = false;
            this.DataGridView2.RowTemplate.Height = 23;
            this.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DataGridView2.Size = new System.Drawing.Size(896, 46);
            this.DataGridView2.TabIndex = 68;
            this.DataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView2_CellDoubleClick);
            this.DataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView2_CellClick);
            this.DataGridView2.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridView2_DataBindingComplete);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.TextBoxCode);
            this.GroupBox2.Controls.Add(this.Label1);
            this.GroupBox2.Controls.Add(this.TextBoxName);
            this.GroupBox2.Controls.Add(this.ButtonSelectCode);
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Location = new System.Drawing.Point(185, 3);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(275, 76);
            this.GroupBox2.TabIndex = 62;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "종목 정보";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(15, 50);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(41, 12);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "종목명";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(44, 45);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(11, 12);
            this.Label10.TabIndex = 19;
            this.Label10.Text = "-";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label10);
            this.GroupBox1.Controls.Add(this.TextBoxAccountNo2);
            this.GroupBox1.Controls.Add(this.ComboBoxAccountKind);
            this.GroupBox1.Controls.Add(this.TextBoxAccountNo1);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Location = new System.Drawing.Point(6, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(173, 76);
            this.GroupBox1.TabIndex = 61;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "계좌 정보";
            // 
            // ButtonBuyPrice
            // 
            this.ButtonBuyPrice.ForeColor = System.Drawing.Color.Black;
            this.ButtonBuyPrice.Location = new System.Drawing.Point(584, 40);
            this.ButtonBuyPrice.Name = "ButtonBuyPrice";
            this.ButtonBuyPrice.Size = new System.Drawing.Size(55, 34);
            this.ButtonBuyPrice.TabIndex = 60;
            this.ButtonBuyPrice.Text = "호가";
            this.ButtonBuyPrice.UseVisualStyleBackColor = true;
            this.ButtonBuyPrice.Click += new System.EventHandler(this.ButtonBuyPrice_Click);
            // 
            // TextBoxPrice
            // 
            this.TextBoxPrice.Location = new System.Drawing.Point(502, 47);
            this.TextBoxPrice.Name = "TextBoxPrice";
            this.TextBoxPrice.Size = new System.Drawing.Size(77, 21);
            this.TextBoxPrice.TabIndex = 59;
            this.TextBoxPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(466, 52);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(29, 12);
            this.Label6.TabIndex = 58;
            this.Label6.Text = "단가";
            // 
            // ComboBoxTrade
            // 
            this.ComboBoxTrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxTrade.FormattingEnabled = true;
            this.ComboBoxTrade.Items.AddRange(new object[] {
            "01 : 지정가",
            "03 : 시장가",
            "05 : 조건부지정가",
            "12 : 최유리지정가",
            "13 : 최우선지정가"});
            this.ComboBoxTrade.Location = new System.Drawing.Point(503, 15);
            this.ComboBoxTrade.Name = "ComboBoxTrade";
            this.ComboBoxTrade.Size = new System.Drawing.Size(136, 20);
            this.ComboBoxTrade.TabIndex = 57;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(466, 19);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(29, 12);
            this.Label8.TabIndex = 56;
            this.Label8.Text = "매매";
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DataGridView1.Location = new System.Drawing.Point(1, 155);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.RowHeadersVisible = false;
            this.DataGridView1.RowTemplate.Height = 23;
            this.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DataGridView1.Size = new System.Drawing.Size(896, 46);
            this.DataGridView1.TabIndex = 55;
            this.DataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridView1_DataBindingComplete);
            // 
            // Form1202
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 284);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.ComboBoxQueryKind);
            this.Controls.Add(this.CheckBoxCharge);
            this.Controls.Add(this.ButtonHelp1);
            this.Controls.Add(this.ButtonQuery);
            this.Controls.Add(this.DataGridView2);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.ButtonBuyPrice);
            this.Controls.Add(this.TextBoxPrice);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.ComboBoxTrade);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.DataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1202";
            this.Text = "[1202] 주식 계좌별 매수 가능금액/수량 (CpTrade.CpTdNew5331A)";
            this.Load += new System.EventHandler(this.Form1202_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1202_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1202_KeyDown);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox TextBoxCode;
        internal System.Windows.Forms.TextBox TextBoxAccountNo2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox TextBoxName;
        internal System.Windows.Forms.Button ButtonSelectCode;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Label LabelMsg1;
        internal System.Windows.Forms.ComboBox ComboBoxAccountKind;
        internal System.Windows.Forms.TextBox TextBoxAccountNo1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox ComboBoxQueryKind;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.CheckBox CheckBoxCharge;
        internal System.Windows.Forms.Button ButtonHelp1;
        internal System.Windows.Forms.Button ButtonQuery;
        internal System.Windows.Forms.DataGridView DataGridView2;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button ButtonBuyPrice;
        internal System.Windows.Forms.TextBox TextBoxPrice;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.ComboBox ComboBoxTrade;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.DataGridView DataGridView1;
    }
}