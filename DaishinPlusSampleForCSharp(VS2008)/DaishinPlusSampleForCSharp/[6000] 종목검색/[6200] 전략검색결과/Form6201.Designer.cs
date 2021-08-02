namespace DaishinPlusSampleForCSharp._6000__종목검색._6200__전략검색결과
{
    partial class Form6201
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6201));
            this.TextBoxDateTime = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.TextBoxCount = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.LabelContinue = new System.Windows.Forms.Label();
            this.LabelMsg2 = new System.Windows.Forms.Label();
            this.LabelMsg1 = new System.Windows.Forms.Label();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.ButtonHelp = new System.Windows.Forms.Button();
            this.ButtonQuery = new System.Windows.Forms.Button();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBoxDateTime
            // 
            this.TextBoxDateTime.Location = new System.Drawing.Point(435, 6);
            this.TextBoxDateTime.Name = "TextBoxDateTime";
            this.TextBoxDateTime.Size = new System.Drawing.Size(98, 21);
            this.TextBoxDateTime.TabIndex = 53;
            this.TextBoxDateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(376, 11);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(57, 12);
            this.Label3.TabIndex = 52;
            this.Label3.Text = "검색 일시";
            // 
            // TextBoxCount
            // 
            this.TextBoxCount.Location = new System.Drawing.Point(331, 6);
            this.TextBoxCount.Name = "TextBoxCount";
            this.TextBoxCount.Size = new System.Drawing.Size(39, 21);
            this.TextBoxCount.TabIndex = 51;
            this.TextBoxCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(272, 11);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(57, 12);
            this.Label2.TabIndex = 50;
            this.Label2.Text = "종목 개수";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.LabelContinue);
            this.GroupBox1.Controls.Add(this.LabelMsg2);
            this.GroupBox1.Controls.Add(this.LabelMsg1);
            this.GroupBox1.ForeColor = System.Drawing.Color.Blue;
            this.GroupBox1.Location = new System.Drawing.Point(3, 34);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(743, 41);
            this.GroupBox1.TabIndex = 46;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "조회 상태";
            // 
            // LabelContinue
            // 
            this.LabelContinue.AutoSize = true;
            this.LabelContinue.ForeColor = System.Drawing.Color.Blue;
            this.LabelContinue.Location = new System.Drawing.Point(512, 18);
            this.LabelContinue.Name = "LabelContinue";
            this.LabelContinue.Size = new System.Drawing.Size(0, 12);
            this.LabelContinue.TabIndex = 25;
            // 
            // LabelMsg2
            // 
            this.LabelMsg2.AutoSize = true;
            this.LabelMsg2.ForeColor = System.Drawing.Color.Blue;
            this.LabelMsg2.Location = new System.Drawing.Point(262, 18);
            this.LabelMsg2.Name = "LabelMsg2";
            this.LabelMsg2.Size = new System.Drawing.Size(0, 12);
            this.LabelMsg2.TabIndex = 24;
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
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DataGridView1.Location = new System.Drawing.Point(0, 81);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.RowHeadersVisible = false;
            this.DataGridView1.RowTemplate.Height = 23;
            this.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DataGridView1.Size = new System.Drawing.Size(748, 324);
            this.DataGridView1.TabIndex = 49;
            this.DataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView1_CellFormatting);
            this.DataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            this.DataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridView1_DataBindingComplete);
            // 
            // ButtonHelp
            // 
            this.ButtonHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ButtonHelp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ButtonHelp.Location = new System.Drawing.Point(671, 2);
            this.ButtonHelp.Name = "ButtonHelp";
            this.ButtonHelp.Size = new System.Drawing.Size(70, 32);
            this.ButtonHelp.TabIndex = 48;
            this.ButtonHelp.Text = "도움말\r\n";
            this.ButtonHelp.UseVisualStyleBackColor = false;
            this.ButtonHelp.Click += new System.EventHandler(this.ButtonHelp_Click);
            // 
            // ButtonQuery
            // 
            this.ButtonQuery.Location = new System.Drawing.Point(591, 3);
            this.ButtonQuery.Name = "ButtonQuery";
            this.ButtonQuery.Size = new System.Drawing.Size(77, 30);
            this.ButtonQuery.TabIndex = 47;
            this.ButtonQuery.Text = "조회";
            this.ButtonQuery.UseVisualStyleBackColor = true;
            this.ButtonQuery.Click += new System.EventHandler(this.ButtonQuery_Click);
            // 
            // TextBoxName
            // 
            this.TextBoxName.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TextBoxName.Location = new System.Drawing.Point(46, 7);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(219, 21);
            this.TextBoxName.TabIndex = 54;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(5, 11);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(41, 12);
            this.Label1.TabIndex = 45;
            this.Label1.Text = "전략명";
            // 
            // Form6201
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 405);
            this.Controls.Add(this.TextBoxDateTime);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.TextBoxCount);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.ButtonHelp);
            this.Controls.Add(this.ButtonQuery);
            this.Controls.Add(this.TextBoxName);
            this.Controls.Add(this.Label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form6201";
            this.Text = "[6201] 전략 검색결과(CpSysDib.CssStgFind)";
            this.Load += new System.EventHandler(this.Form6201_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form6201_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form6201_KeyDown);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox TextBoxDateTime;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox TextBoxCount;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label LabelContinue;
        internal System.Windows.Forms.Label LabelMsg2;
        internal System.Windows.Forms.Label LabelMsg1;
        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.Button ButtonHelp;
        internal System.Windows.Forms.Button ButtonQuery;
        internal System.Windows.Forms.TextBox TextBoxName;
        internal System.Windows.Forms.Label Label1;
    }
}