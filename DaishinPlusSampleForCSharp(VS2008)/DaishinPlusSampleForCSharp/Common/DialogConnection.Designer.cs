namespace DaishinPlusSampleForCSharp.Common
{
    partial class DialogConnection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogConnection));
            this.ButtonCancle = new System.Windows.Forms.Button();
            this.ButtonCreon = new System.Windows.Forms.Button();
            this.ButtonCybos = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonCancle
            // 
            this.ButtonCancle.Location = new System.Drawing.Point(166, 73);
            this.ButtonCancle.Name = "ButtonCancle";
            this.ButtonCancle.Size = new System.Drawing.Size(87, 62);
            this.ButtonCancle.TabIndex = 7;
            this.ButtonCancle.Text = "취 소";
            this.ButtonCancle.UseVisualStyleBackColor = true;
            this.ButtonCancle.Click += new System.EventHandler(this.ButtonCancle_Click);
            // 
            // ButtonCreon
            // 
            this.ButtonCreon.ForeColor = System.Drawing.Color.Red;
            this.ButtonCreon.Location = new System.Drawing.Point(10, 108);
            this.ButtonCreon.Name = "ButtonCreon";
            this.ButtonCreon.Size = new System.Drawing.Size(136, 44);
            this.ButtonCreon.TabIndex = 6;
            this.ButtonCreon.Text = "크레온 플러스 접속";
            this.ButtonCreon.UseVisualStyleBackColor = true;
            this.ButtonCreon.Click += new System.EventHandler(this.ButtonCreon_Click);
            // 
            // ButtonCybos
            // 
            this.ButtonCybos.ForeColor = System.Drawing.Color.Blue;
            this.ButtonCybos.Location = new System.Drawing.Point(10, 58);
            this.ButtonCybos.Name = "ButtonCybos";
            this.ButtonCybos.Size = new System.Drawing.Size(136, 44);
            this.ButtonCybos.TabIndex = 5;
            this.ButtonCybos.Text = "사이보스 플러스 접속";
            this.ButtonCybos.UseVisualStyleBackColor = true;
            this.ButtonCybos.Click += new System.EventHandler(this.ButtonCybos_Click);
            // 
            // Label1
            // 
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(11, 7);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(250, 48);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "대신증권 플러스에 접속되어 있지 않습니다.\r\n\r\n접속하시겠습니까?\r\n";
            // 
            // DialogConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 158);
            this.Controls.Add(this.ButtonCancle);
            this.Controls.Add(this.ButtonCreon);
            this.Controls.Add(this.ButtonCybos);
            this.Controls.Add(this.Label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DialogConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "대신 플러스 접속";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button ButtonCancle;
        internal System.Windows.Forms.Button ButtonCreon;
        internal System.Windows.Forms.Button ButtonCybos;
        internal System.Windows.Forms.Label Label1;
    }
}