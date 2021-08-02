namespace DaishinPlusSampleForCSharp._1000__주식._1100__시세
{
    partial class Form1106
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1106));
            this.Label5 = new System.Windows.Forms.Label();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.LabelSell = new System.Windows.Forms.Label();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.Label2 = new System.Windows.Forms.Label();
            this.LabelBuy = new System.Windows.Forms.Label();
            this.ButtonSelectCode = new System.Windows.Forms.Button();
            this.Label4 = new System.Windows.Forms.Label();
            this.ButtonRQ = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.ButtonHelpSB = new System.Windows.Forms.Button();
            this.ButtonHelpRQ = new System.Windows.Forms.Button();
            this.GroupBoxRQ = new System.Windows.Forms.GroupBox();
            this.TextBoxCode = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.LabelTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.GroupBoxRQ.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.ForeColor = System.Drawing.Color.Red;
            this.Label5.Location = new System.Drawing.Point(10, 107);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(81, 12);
            this.Label5.TabIndex = 43;
            this.Label5.Text = "총 매수 잔량 :";
            // 
            // TextBoxName
            // 
            this.TextBoxName.BackColor = System.Drawing.Color.White;
            this.TextBoxName.Location = new System.Drawing.Point(77, 39);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.ReadOnly = true;
            this.TextBoxName.Size = new System.Drawing.Size(101, 21);
            this.TextBoxName.TabIndex = 5;
            // 
            // LabelSell
            // 
            this.LabelSell.AutoSize = true;
            this.LabelSell.ForeColor = System.Drawing.Color.Blue;
            this.LabelSell.Location = new System.Drawing.Point(93, 89);
            this.LabelSell.Name = "LabelSell";
            this.LabelSell.Size = new System.Drawing.Size(0, 12);
            this.LabelSell.TabIndex = 42;
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DataGridView1.Location = new System.Drawing.Point(-2, 124);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.RowHeadersVisible = false;
            this.DataGridView1.RowTemplate.Height = 23;
            this.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView1.Size = new System.Drawing.Size(300, 485);
            this.DataGridView1.TabIndex = 38;
            this.DataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick);
            this.DataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView1_CellFormatting);
            this.DataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            this.DataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridView1_DataBindingComplete);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(17, 44);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(41, 12);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "종목명";
            // 
            // LabelBuy
            // 
            this.LabelBuy.AutoSize = true;
            this.LabelBuy.ForeColor = System.Drawing.Color.Red;
            this.LabelBuy.Location = new System.Drawing.Point(93, 107);
            this.LabelBuy.Name = "LabelBuy";
            this.LabelBuy.Size = new System.Drawing.Size(0, 12);
            this.LabelBuy.TabIndex = 44;
            // 
            // ButtonSelectCode
            // 
            this.ButtonSelectCode.Location = new System.Drawing.Point(183, 11);
            this.ButtonSelectCode.Name = "ButtonSelectCode";
            this.ButtonSelectCode.Size = new System.Drawing.Size(53, 48);
            this.ButtonSelectCode.TabIndex = 3;
            this.ButtonSelectCode.Text = "종목\r\n선택";
            this.ButtonSelectCode.UseVisualStyleBackColor = true;
            this.ButtonSelectCode.Click += new System.EventHandler(this.ButtonSelectCode_Click);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(10, 71);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(41, 12);
            this.Label4.TabIndex = 36;
            this.Label4.Text = "시간 : ";
            // 
            // ButtonRQ
            // 
            this.ButtonRQ.Location = new System.Drawing.Point(243, 12);
            this.ButtonRQ.Name = "ButtonRQ";
            this.ButtonRQ.Size = new System.Drawing.Size(53, 48);
            this.ButtonRQ.TabIndex = 2;
            this.ButtonRQ.Text = "조회";
            this.ButtonRQ.UseVisualStyleBackColor = true;
            this.ButtonRQ.Click += new System.EventHandler(this.ButtonRQ_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.ForeColor = System.Drawing.Color.Blue;
            this.Label3.Location = new System.Drawing.Point(10, 89);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(81, 12);
            this.Label3.TabIndex = 41;
            this.Label3.Text = "총 매도 잔량 :";
            // 
            // ButtonHelpSB
            // 
            this.ButtonHelpSB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ButtonHelpSB.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ButtonHelpSB.Location = new System.Drawing.Point(229, 75);
            this.ButtonHelpSB.Name = "ButtonHelpSB";
            this.ButtonHelpSB.Size = new System.Drawing.Size(67, 40);
            this.ButtonHelpSB.TabIndex = 40;
            this.ButtonHelpSB.Text = "도움말\r\n(실시간)";
            this.ButtonHelpSB.UseVisualStyleBackColor = false;
            this.ButtonHelpSB.Click += new System.EventHandler(this.ButtonHelpSB_Click);
            // 
            // ButtonHelpRQ
            // 
            this.ButtonHelpRQ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ButtonHelpRQ.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ButtonHelpRQ.Location = new System.Drawing.Point(156, 75);
            this.ButtonHelpRQ.Name = "ButtonHelpRQ";
            this.ButtonHelpRQ.Size = new System.Drawing.Size(67, 40);
            this.ButtonHelpRQ.TabIndex = 39;
            this.ButtonHelpRQ.Text = "도움말\r\n(조회)";
            this.ButtonHelpRQ.UseVisualStyleBackColor = false;
            this.ButtonHelpRQ.Click += new System.EventHandler(this.ButtonHelpRQ_Click);
            // 
            // GroupBoxRQ
            // 
            this.GroupBoxRQ.Controls.Add(this.TextBoxName);
            this.GroupBoxRQ.Controls.Add(this.Label2);
            this.GroupBoxRQ.Controls.Add(this.ButtonSelectCode);
            this.GroupBoxRQ.Controls.Add(this.ButtonRQ);
            this.GroupBoxRQ.Controls.Add(this.TextBoxCode);
            this.GroupBoxRQ.Controls.Add(this.Label1);
            this.GroupBoxRQ.Location = new System.Drawing.Point(1, 2);
            this.GroupBoxRQ.Name = "GroupBoxRQ";
            this.GroupBoxRQ.Size = new System.Drawing.Size(301, 64);
            this.GroupBoxRQ.TabIndex = 37;
            this.GroupBoxRQ.TabStop = false;
            this.GroupBoxRQ.Text = "요청";
            // 
            // TextBoxCode
            // 
            this.TextBoxCode.Location = new System.Drawing.Point(77, 12);
            this.TextBoxCode.Name = "TextBoxCode";
            this.TextBoxCode.Size = new System.Drawing.Size(101, 21);
            this.TextBoxCode.TabIndex = 1;
            this.TextBoxCode.TextChanged += new System.EventHandler(this.TextBoxCode_TextChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(17, 17);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(53, 12);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "종목코드";
            // 
            // LabelTime
            // 
            this.LabelTime.AutoSize = true;
            this.LabelTime.Location = new System.Drawing.Point(48, 71);
            this.LabelTime.Name = "LabelTime";
            this.LabelTime.Size = new System.Drawing.Size(0, 12);
            this.LabelTime.TabIndex = 45;
            // 
            // Form1106
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 610);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.LabelSell);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.LabelBuy);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.ButtonHelpSB);
            this.Controls.Add(this.ButtonHelpRQ);
            this.Controls.Add(this.GroupBoxRQ);
            this.Controls.Add(this.LabelTime);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1106";
            this.Text = "[1106] 주식 호가 (CpDib.StrockJpBid2)";
            this.Load += new System.EventHandler(this.Form1106_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1106_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1106_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.GroupBoxRQ.ResumeLayout(false);
            this.GroupBoxRQ.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox TextBoxName;
        internal System.Windows.Forms.Label LabelSell;
        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label LabelBuy;
        internal System.Windows.Forms.Button ButtonSelectCode;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button ButtonRQ;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button ButtonHelpSB;
        internal System.Windows.Forms.Button ButtonHelpRQ;
        internal System.Windows.Forms.GroupBox GroupBoxRQ;
        internal System.Windows.Forms.TextBox TextBoxCode;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label LabelTime;
    }
}