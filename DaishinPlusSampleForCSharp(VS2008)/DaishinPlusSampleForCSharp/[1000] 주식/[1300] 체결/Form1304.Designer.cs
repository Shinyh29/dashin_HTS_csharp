namespace DaishinPlusSampleForCSharp._1000__주식._1300__체결
{
    partial class Form1304
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1304));
            this.ButtonHelp1 = new System.Windows.Forms.Button();
            this.CheckBoxTop = new System.Windows.Forms.CheckBox();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonHelp1
            // 
            this.ButtonHelp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ButtonHelp1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ButtonHelp1.Location = new System.Drawing.Point(228, 4);
            this.ButtonHelp1.Name = "ButtonHelp1";
            this.ButtonHelp1.Size = new System.Drawing.Size(58, 29);
            this.ButtonHelp1.TabIndex = 66;
            this.ButtonHelp1.Text = "도움말";
            this.ButtonHelp1.UseVisualStyleBackColor = false;
            this.ButtonHelp1.Click += new System.EventHandler(this.ButtonHelp1_Click);
            // 
            // CheckBoxTop
            // 
            this.CheckBoxTop.AutoSize = true;
            this.CheckBoxTop.Checked = true;
            this.CheckBoxTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxTop.Location = new System.Drawing.Point(7, 12);
            this.CheckBoxTop.Name = "CheckBoxTop";
            this.CheckBoxTop.Size = new System.Drawing.Size(202, 16);
            this.CheckBoxTop.TabIndex = 65;
            this.CheckBoxTop.Text = "최근 데이터 보기(실시간 수신시)";
            this.CheckBoxTop.UseVisualStyleBackColor = true;
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DataGridView1.Location = new System.Drawing.Point(0, 40);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.RowHeadersVisible = false;
            this.DataGridView1.RowTemplate.Height = 23;
            this.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DataGridView1.Size = new System.Drawing.Size(1241, 271);
            this.DataGridView1.TabIndex = 64;
            this.DataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView1_CellFormatting);
            // 
            // Form1304
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 314);
            this.Controls.Add(this.ButtonHelp1);
            this.Controls.Add(this.CheckBoxTop);
            this.Controls.Add(this.DataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1304";
            this.Text = "[1304] 주식 체결 실시간 (CpDib.CpConclusion)";
            this.Load += new System.EventHandler(this.Form1304_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1304_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button ButtonHelp1;
        internal System.Windows.Forms.CheckBox CheckBoxTop;
        internal System.Windows.Forms.DataGridView DataGridView1;
    }
}