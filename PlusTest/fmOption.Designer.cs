namespace PlusTest
{
    partial class fmOption
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
            this.m_HogaView = new System.Windows.Forms.DataGridView();
            this.m_cbCode = new System.Windows.Forms.ComboBox();
            this.m_infoGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.m_HogaView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_infoGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // m_HogaView
            // 
            this.m_HogaView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_HogaView.Location = new System.Drawing.Point(7, 91);
            this.m_HogaView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_HogaView.Name = "m_HogaView";
            this.m_HogaView.RowTemplate.Height = 23;
            this.m_HogaView.Size = new System.Drawing.Size(416, 278);
            this.m_HogaView.TabIndex = 0;
            // 
            // m_cbCode
            // 
            this.m_cbCode.FormattingEnabled = true;
            this.m_cbCode.Location = new System.Drawing.Point(7, 11);
            this.m_cbCode.Name = "m_cbCode";
            this.m_cbCode.Size = new System.Drawing.Size(280, 23);
            this.m_cbCode.TabIndex = 1;
            this.m_cbCode.SelectedIndexChanged += new System.EventHandler(this.m_cbCode_SelectedIndexChanged);
            // 
            // m_infoGrid
            // 
            this.m_infoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_infoGrid.Location = new System.Drawing.Point(7, 39);
            this.m_infoGrid.Name = "m_infoGrid";
            this.m_infoGrid.RowTemplate.Height = 23;
            this.m_infoGrid.Size = new System.Drawing.Size(416, 47);
            this.m_infoGrid.TabIndex = 2;
            // 
            // fmOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 381);
            this.Controls.Add(this.m_infoGrid);
            this.Controls.Add(this.m_cbCode);
            this.Controls.Add(this.m_HogaView);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "fmOption";
            this.Text = "옵션현재가";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmOption_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_HogaView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_infoGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView m_HogaView;
        private System.Windows.Forms.ComboBox m_cbCode;
        private System.Windows.Forms.DataGridView m_infoGrid;
    }
}

