namespace TestUI
{
    partial class frmLog
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
            this.btnPLCTest = new System.Windows.Forms.Button();
            this.btnDBLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPLCTest
            // 
            this.btnPLCTest.Location = new System.Drawing.Point(13, 13);
            this.btnPLCTest.Name = "btnPLCTest";
            this.btnPLCTest.Size = new System.Drawing.Size(75, 23);
            this.btnPLCTest.TabIndex = 0;
            this.btnPLCTest.Text = "PLC Log";
            this.btnPLCTest.UseVisualStyleBackColor = true;
            this.btnPLCTest.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDBLog
            // 
            this.btnDBLog.Location = new System.Drawing.Point(94, 12);
            this.btnDBLog.Name = "btnDBLog";
            this.btnDBLog.Size = new System.Drawing.Size(75, 23);
            this.btnDBLog.TabIndex = 1;
            this.btnDBLog.Text = "DB Log";
            this.btnDBLog.UseVisualStyleBackColor = true;
            this.btnDBLog.Click += new System.EventHandler(this.btnDBLog_Click);
            // 
            // frmLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnDBLog);
            this.Controls.Add(this.btnPLCTest);
            this.Name = "frmLog";
            this.Text = "frmLog";
            this.Load += new System.EventHandler(this.frmLog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPLCTest;
        private System.Windows.Forms.Button btnDBLog;
    }
}