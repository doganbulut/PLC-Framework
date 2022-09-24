namespace FCHMI
{
    partial class FrmCalib
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
            this.ucAxicCalib1 = new FCUI.UCAxicCalib();
            this.SuspendLayout();
            // 
            // ucAxicCalib1
            // 
            this.ucAxicCalib1.Active = false;
            this.ucAxicCalib1.Axis = null;
            this.ucAxicCalib1.langcode = null;
            this.ucAxicCalib1.Location = new System.Drawing.Point(57, 12);
            this.ucAxicCalib1.Name = "ucAxicCalib1";
            this.ucAxicCalib1.PlcController = null;
            this.ucAxicCalib1.Size = new System.Drawing.Size(279, 111);
            this.ucAxicCalib1.TabIndex = 0;
            // 
            // FrmCalib
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 300);
            this.Controls.Add(this.ucAxicCalib1);
            this.Name = "FrmCalib";
            this.Text = "FrmCalib";
            this.Load += new System.EventHandler(this.FrmCalib_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FCUI.UCAxicCalib ucAxicCalib1;
    }
}