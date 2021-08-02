namespace DaishinPlusSampleForCSharp._1000__주식._1200__주문
{
    partial class Form1203
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1203));
            this.Label10 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.TextBoxAccountNo2 = new System.Windows.Forms.TextBox();
            this.ComboBoxAccountKind = new System.Windows.Forms.ComboBox();
            this.TextBoxAccountNo1 = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.LabelContinue = new System.Windows.Forms.Label();
            this.LabelMsg1 = new System.Windows.Forms.Label();
            this.ComboBoxQueryKind = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.ButtonSelectCode = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.TextBoxCode = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.ButtonQuery = new System.Windows.Forms.Button();
            this.ButtonHelp1 = new System.Windows.Forms.Button();
            this.ButtonNext = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.GroupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
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
            this.GroupBox1.Location = new System.Drawing.Point(5, 2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(173, 76);
            this.GroupBox1.TabIndex = 59;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "계좌 정보";
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
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(133, 21);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(29, 12);
            this.Label7.TabIndex = 14;
            this.Label7.Text = "구분";
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DataGridView1.Location = new System.Drawing.Point(0, 129);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.RowHeadersVisible = false;
            this.DataGridView1.RowTemplate.Height = 23;
            this.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DataGridView1.Size = new System.Drawing.Size(832, 266);
            this.DataGridView1.TabIndex = 58;
            this.DataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick);
            this.DataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            this.DataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridView1_DataBindingComplete);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.LabelContinue);
            this.GroupBox3.Controls.Add(this.LabelMsg1);
            this.GroupBox3.ForeColor = System.Drawing.Color.Blue;
            this.GroupBox3.Location = new System.Drawing.Point(5, 84);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(822, 41);
            this.GroupBox3.TabIndex = 57;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "조회 상태";
            // 
            // LabelContinue
            // 
            this.LabelContinue.AutoSize = true;
            this.LabelContinue.ForeColor = System.Drawing.Color.Blue;
            this.LabelContinue.Location = new System.Drawing.Point(442, 19);
            this.LabelContinue.Name = "LabelContinue";
            this.LabelContinue.Size = new System.Drawing.Size(0, 12);
            this.LabelContinue.TabIndex = 26;
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
            // ComboBoxQueryKind
            // 
            this.ComboBoxQueryKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxQueryKind.FormattingEnabled = true;
            this.ComboBoxQueryKind.Items.AddRange(new object[] {
            "종목 조회",
            "전체 조회"});
            this.ComboBoxQueryKind.Location = new System.Drawing.Point(480, 31);
            this.ComboBoxQueryKind.Name = "ComboBoxQueryKind";
            this.ComboBoxQueryKind.Size = new System.Drawing.Size(93, 20);
            this.ComboBoxQueryKind.TabIndex = 63;
            this.ComboBoxQueryKind.SelectedIndexChanged += new System.EventHandler(this.ComboBoxQueryKind_SelectedIndexChanged);
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
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.TextBoxCode);
            this.GroupBox2.Controls.Add(this.Label1);
            this.GroupBox2.Controls.Add(this.TextBoxName);
            this.GroupBox2.Controls.Add(this.ButtonSelectCode);
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Location = new System.Drawing.Point(184, 2);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(275, 76);
            this.GroupBox2.TabIndex = 60;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "종목 정보";
            // 
            // TextBoxCode
            // 
            this.TextBoxCode.Location = new System.Drawing.Point(75, 18);
            this.TextBoxCode.Name = "TextBoxCode";
            this.TextBoxCode.Size = new System.Drawing.Size(124, 21);
            this.TextBoxCode.TabIndex = 1;
            this.TextBoxCode.TextChanged += new System.EventHandler(this.TextBoxCode_TextChanged);
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
            // ButtonQuery
            // 
            this.ButtonQuery.Location = new System.Drawing.Point(586, 19);
            this.ButtonQuery.Name = "ButtonQuery";
            this.ButtonQuery.Size = new System.Drawing.Size(75, 43);
            this.ButtonQuery.TabIndex = 61;
            this.ButtonQuery.Text = "조회";
            this.ButtonQuery.UseVisualStyleBackColor = true;
            this.ButtonQuery.Click += new System.EventHandler(this.ButtonQuery_Click);
            // 
            // ButtonHelp1
            // 
            this.ButtonHelp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ButtonHelp1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ButtonHelp1.Location = new System.Drawing.Point(756, 19);
            this.ButtonHelp1.Name = "ButtonHelp1";
            this.ButtonHelp1.Size = new System.Drawing.Size(58, 43);
            this.ButtonHelp1.TabIndex = 62;
            this.ButtonHelp1.Text = "도움말";
            this.ButtonHelp1.UseVisualStyleBackColor = false;
            this.ButtonHelp1.Click += new System.EventHandler(this.ButtonHelp1_Click);
            // 
            // ButtonNext
            // 
            this.ButtonNext.Location = new System.Drawing.Point(666, 19);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(75, 43);
            this.ButtonNext.TabIndex = 64;
            this.ButtonNext.Text = "다음\r\n";
            this.ButtonNext.UseVisualStyleBackColor = true;
            this.ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // Form1203
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 397);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.ComboBoxQueryKind);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.ButtonQuery);
            this.Controls.Add(this.ButtonHelp1);
            this.Controls.Add(this.ButtonNext);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1203";
            this.Text = "[1203] 주식 계좌별 매도 가능수량 (CpTrade.CpTdNew5331B)";
            this.Load += new System.EventHandler(this.Form1203_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1203_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1203_KeyDown);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox TextBoxAccountNo2;
        internal System.Windows.Forms.ComboBox ComboBoxAccountKind;
        internal System.Windows.Forms.TextBox TextBoxAccountNo1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Label LabelContinue;
        internal System.Windows.Forms.Label LabelMsg1;
        internal System.Windows.Forms.ComboBox ComboBoxQueryKind;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button ButtonSelectCode;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox TextBoxCode;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox TextBoxName;
        internal System.Windows.Forms.Button ButtonQuery;
        internal System.Windows.Forms.Button ButtonHelp1;
        internal System.Windows.Forms.Button ButtonNext;
    }
}