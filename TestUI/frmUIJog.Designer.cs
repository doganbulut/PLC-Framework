namespace TestUI
{
    partial class frmUIJog
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
            this.pnlJog = new System.Windows.Forms.Panel();
            this.pnlCalib = new System.Windows.Forms.Panel();
            this.pnlAxis = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlJog
            // 
            this.pnlJog.Location = new System.Drawing.Point(12, 12);
            this.pnlJog.Name = "pnlJog";
            this.pnlJog.Size = new System.Drawing.Size(316, 211);
            this.pnlJog.TabIndex = 0;
            // 
            // pnlCalib
            // 
            this.pnlCalib.Location = new System.Drawing.Point(334, 12);
            this.pnlCalib.Name = "pnlCalib";
            this.pnlCalib.Size = new System.Drawing.Size(292, 211);
            this.pnlCalib.TabIndex = 1;
            // 
            // pnlAxis
            // 
            this.pnlAxis.Location = new System.Drawing.Point(633, 13);
            this.pnlAxis.Name = "pnlAxis";
            this.pnlAxis.Size = new System.Drawing.Size(267, 210);
            this.pnlAxis.TabIndex = 2;
            // 
            // frmUIJog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 268);
            this.Controls.Add(this.pnlAxis);
            this.Controls.Add(this.pnlCalib);
            this.Controls.Add(this.pnlJog);
            this.Name = "frmUIJog";
            this.Text = "frmUIJog";
            this.Load += new System.EventHandler(this.frmUIJog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlJog;
        private System.Windows.Forms.Panel pnlCalib;
        private System.Windows.Forms.Panel pnlAxis;





    }
}