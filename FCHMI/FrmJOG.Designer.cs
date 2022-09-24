namespace FCHMI
{
    partial class FrmJOG
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
            this.ucAxisJog1 = new FCUI.UCAxisJog();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ucAxisJog1
            // 
            this.ucAxisJog1.Axis = null;
            this.ucAxisJog1.langcode = null;
            this.ucAxisJog1.Location = new System.Drawing.Point(70, 59);
            this.ucAxisJog1.Name = "ucAxisJog1";
            this.ucAxisJog1.PlcController = null;
            this.ucAxisJog1.Size = new System.Drawing.Size(299, 115);
            this.ucAxisJog1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(169, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Elle Kontrol";
            // 
            // FrmJOG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucAxisJog1);
            this.Name = "FrmJOG";
            this.Text = "FrmJOG";
            this.Load += new System.EventHandler(this.FrmJOG_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FCUI.UCAxisJog ucAxisJog1;
        private System.Windows.Forms.Label label1;
    }
}