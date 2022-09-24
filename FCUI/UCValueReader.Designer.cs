namespace FCUI
{
    partial class UCValueReader
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPLCKey = new System.Windows.Forms.Label();
            this.lblPLCValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPLCKey
            // 
            this.lblPLCKey.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPLCKey.Location = new System.Drawing.Point(0, 0);
            this.lblPLCKey.Name = "lblPLCKey";
            this.lblPLCKey.Size = new System.Drawing.Size(137, 13);
            this.lblPLCKey.TabIndex = 0;
            this.lblPLCKey.Text = "PLCValueKey";
            // 
            // lblPLCValue
            // 
            this.lblPLCValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPLCValue.Location = new System.Drawing.Point(0, 13);
            this.lblPLCValue.Name = "lblPLCValue";
            this.lblPLCValue.Size = new System.Drawing.Size(137, 16);
            this.lblPLCValue.TabIndex = 1;
            this.lblPLCValue.Text = "PLCValue";
            // 
            // UCValueReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPLCValue);
            this.Controls.Add(this.lblPLCKey);
            this.Name = "UCValueReader";
            this.Size = new System.Drawing.Size(137, 29);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPLCKey;
        private System.Windows.Forms.Label lblPLCValue;
    }
}
