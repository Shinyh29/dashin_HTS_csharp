namespace DaishinPlusSampleForCSharp._1000__주식._1100__시세
{
    partial class Form1102
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1102));
            this.Button4 = new System.Windows.Forms.Button();
            this.GroupBoxRQ = new System.Windows.Forms.GroupBox();
            this.Button5 = new System.Windows.Forms.Button();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.ButtonSelectCode = new System.Windows.Forms.Button();
            this.TextBoxCode = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.LabelMsg1 = new System.Windows.Forms.Label();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.GroupBoxRQ.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Button4
            // 
            this.Button4.Location = new System.Drawing.Point(411, 22);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(132, 49);
            this.Button4.TabIndex = 25;
            this.Button4.Text = "그리드 선택종목 삭제";
            this.Button4.UseVisualStyleBackColor = true;
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // GroupBoxRQ
            // 
            this.GroupBoxRQ.Controls.Add(this.Button5);
            this.GroupBoxRQ.Controls.Add(this.TextBoxName);
            this.GroupBoxRQ.Controls.Add(this.Label2);
            this.GroupBoxRQ.Controls.Add(this.ButtonSelectCode);
            this.GroupBoxRQ.Controls.Add(this.TextBoxCode);
            this.GroupBoxRQ.Controls.Add(this.Label1);
            this.GroupBoxRQ.Location = new System.Drawing.Point(12, 10);
            this.GroupBoxRQ.Name = "GroupBoxRQ";
            this.GroupBoxRQ.Size = new System.Drawing.Size(393, 67);
            this.GroupBoxRQ.TabIndex = 22;
            this.GroupBoxRQ.TabStop = false;
            this.GroupBoxRQ.Text = "요청";
            // 
            // Button5
            // 
            this.Button5.Location = new System.Drawing.Point(303, 13);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(73, 49);
            this.Button5.TabIndex = 8;
            this.Button5.Text = "관심종목\r\n조회";
            this.Button5.UseVisualStyleBackColor = true;
            this.Button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // TextBoxName
            // 
            this.TextBoxName.BackColor = System.Drawing.Color.White;
            this.TextBoxName.Location = new System.Drawing.Point(78, 41);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.ReadOnly = true;
            this.TextBoxName.Size = new System.Drawing.Size(148, 21);
            this.TextBoxName.TabIndex = 10;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(18, 46);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(41, 12);
            this.Label2.TabIndex = 9;
            this.Label2.Text = "종목명";
            // 
            // ButtonSelectCode
            // 
            this.ButtonSelectCode.Location = new System.Drawing.Point(234, 13);
            this.ButtonSelectCode.Name = "ButtonSelectCode";
            this.ButtonSelectCode.Size = new System.Drawing.Size(53, 48);
            this.ButtonSelectCode.TabIndex = 8;
            this.ButtonSelectCode.Text = "종목\r\n선택";
            this.ButtonSelectCode.UseVisualStyleBackColor = true;
            this.ButtonSelectCode.Click += new System.EventHandler(this.ButtonSelectCode_Click);
            // 
            // TextBoxCode
            // 
            this.TextBoxCode.Location = new System.Drawing.Point(78, 14);
            this.TextBoxCode.Name = "TextBoxCode";
            this.TextBoxCode.Size = new System.Drawing.Size(148, 21);
            this.TextBoxCode.TabIndex = 7;
            this.TextBoxCode.TextChanged += new System.EventHandler(this.TextBoxCode_TextChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(18, 19);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(53, 12);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "종목코드";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.LabelMsg1);
            this.GroupBox1.ForeColor = System.Drawing.Color.Blue;
            this.GroupBox1.Location = new System.Drawing.Point(12, 81);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(683, 41);
            this.GroupBox1.TabIndex = 26;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "조회 상태";
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
            // Button2
            // 
            this.Button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Button2.Location = new System.Drawing.Point(593, 42);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(99, 39);
            this.Button2.TabIndex = 24;
            this.Button2.Text = "도움말\r\n(실시간)";
            this.Button2.UseVisualStyleBackColor = false;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Button1.Location = new System.Drawing.Point(593, 2);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(99, 38);
            this.Button1.TabIndex = 23;
            this.Button1.Text = "도움말\r\n(관심종목 조회)";
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DataGridView1.Location = new System.Drawing.Point(0, 128);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.RowHeadersVisible = false;
            this.DataGridView1.RowTemplate.Height = 23;
            this.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView1.Size = new System.Drawing.Size(695, 397);
            this.DataGridView1.TabIndex = 21;
            this.DataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView1_CellFormatting);
            this.DataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            this.DataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridView1_DataBindingComplete);
            // 
            // Form1102
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 526);
            this.Controls.Add(this.Button4);
            this.Controls.Add(this.GroupBoxRQ);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.DataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1102";
            this.Text = "[1102] 관심종목 (CpSysDib.MarketEye)";
            this.Load += new System.EventHandler(this.Form1102_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1102_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1102_KeyDown);
            this.GroupBoxRQ.ResumeLayout(false);
            this.GroupBoxRQ.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button Button4;
        internal System.Windows.Forms.GroupBox GroupBoxRQ;
        internal System.Windows.Forms.Button Button5;
        internal System.Windows.Forms.TextBox TextBoxName;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button ButtonSelectCode;
        internal System.Windows.Forms.TextBox TextBoxCode;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label LabelMsg1;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.DataGridView DataGridView1;
    }
}