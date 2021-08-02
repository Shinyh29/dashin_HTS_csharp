namespace DaishinPlusSampleForCSharp._1000__주식._1200__주문
{
    partial class Form1205
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1205));
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.TextBoxAccountNo2 = new System.Windows.Forms.TextBox();
            this.LabelContinue = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.LabelMsg1 = new System.Windows.Forms.Label();
            this.ComboBoxAccountKind = new System.Windows.Forms.ComboBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.TextBoxAccountNo1 = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.ButtonNext = new System.Windows.Forms.Button();
            this.ButtonHelp1 = new System.Windows.Forms.Button();
            this.ButtonQuery = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.GroupBox3.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DataGridView1.Location = new System.Drawing.Point(1, 82);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.RowHeadersVisible = false;
            this.DataGridView1.RowTemplate.Height = 23;
            this.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView1.Size = new System.Drawing.Size(903, 266);
            this.DataGridView1.TabIndex = 65;
            this.DataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick);
            this.DataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView1_CellFormatting);
            this.DataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            this.DataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridView1_DataBindingComplete);
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
            // LabelContinue
            // 
            this.LabelContinue.AutoSize = true;
            this.LabelContinue.ForeColor = System.Drawing.Color.Blue;
            this.LabelContinue.Location = new System.Drawing.Point(17, 40);
            this.LabelContinue.Name = "LabelContinue";
            this.LabelContinue.Size = new System.Drawing.Size(0, 12);
            this.LabelContinue.TabIndex = 26;
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
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.LabelContinue);
            this.GroupBox3.Controls.Add(this.LabelMsg1);
            this.GroupBox3.ForeColor = System.Drawing.Color.Blue;
            this.GroupBox3.Location = new System.Drawing.Point(361, 8);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(448, 62);
            this.GroupBox3.TabIndex = 64;
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
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label10);
            this.GroupBox1.Controls.Add(this.TextBoxAccountNo2);
            this.GroupBox1.Controls.Add(this.ComboBoxAccountKind);
            this.GroupBox1.Controls.Add(this.TextBoxAccountNo1);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Location = new System.Drawing.Point(6, 2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(173, 76);
            this.GroupBox1.TabIndex = 66;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "계좌 정보";
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
            // ButtonNext
            // 
            this.ButtonNext.Location = new System.Drawing.Point(277, 21);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(75, 43);
            this.ButtonNext.TabIndex = 69;
            this.ButtonNext.Text = "다음\r\n";
            this.ButtonNext.UseVisualStyleBackColor = true;
            this.ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // ButtonHelp1
            // 
            this.ButtonHelp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ButtonHelp1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ButtonHelp1.Location = new System.Drawing.Point(835, 16);
            this.ButtonHelp1.Name = "ButtonHelp1";
            this.ButtonHelp1.Size = new System.Drawing.Size(58, 43);
            this.ButtonHelp1.TabIndex = 68;
            this.ButtonHelp1.Text = "도움말";
            this.ButtonHelp1.UseVisualStyleBackColor = false;
            this.ButtonHelp1.Click += new System.EventHandler(this.ButtonHelp1_Click);
            // 
            // ButtonQuery
            // 
            this.ButtonQuery.Location = new System.Drawing.Point(197, 21);
            this.ButtonQuery.Name = "ButtonQuery";
            this.ButtonQuery.Size = new System.Drawing.Size(75, 43);
            this.ButtonQuery.TabIndex = 67;
            this.ButtonQuery.Text = "조회";
            this.ButtonQuery.UseVisualStyleBackColor = true;
            this.ButtonQuery.Click += new System.EventHandler(this.ButtonQuery_Click);
            // 
            // Form1205
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 350);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.ButtonNext);
            this.Controls.Add(this.ButtonHelp1);
            this.Controls.Add(this.ButtonQuery);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1205";
            this.Text = "[1205] 주식 예약주문현황 (CpTrade.CpTd9065)";
            this.Load += new System.EventHandler(this.Form1205_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1205_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1205_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.TextBox TextBoxAccountNo2;
        internal System.Windows.Forms.Label LabelContinue;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Label LabelMsg1;
        internal System.Windows.Forms.ComboBox ComboBoxAccountKind;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox TextBoxAccountNo1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Button ButtonNext;
        internal System.Windows.Forms.Button ButtonHelp1;
        internal System.Windows.Forms.Button ButtonQuery;
    }
}