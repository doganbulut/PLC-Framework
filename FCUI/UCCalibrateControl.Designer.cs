namespace FCUI
{
    partial class UCCalibrateControl
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
            this.pnlAxis = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlJpg = new System.Windows.Forms.Panel();
            this.btnActive = new System.Windows.Forms.Button();
            this.pnlJpg.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAxis
            // 
            this.pnlAxis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAxis.Location = new System.Drawing.Point(0, 80);
            this.pnlAxis.Name = "pnlAxis";
            this.pnlAxis.Size = new System.Drawing.Size(749, 260);
            this.pnlAxis.TabIndex = 3;
            // 
            // pnlJpg
            // 
            this.pnlJpg.Controls.Add(this.btnActive);
            this.pnlJpg.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlJpg.Location = new System.Drawing.Point(0, 0);
            this.pnlJpg.Name = "pnlJpg";
            this.pnlJpg.Size = new System.Drawing.Size(749, 80);
            this.pnlJpg.TabIndex = 2;
            // 
            // btnActive
            // 
            this.btnActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnActive.Location = new System.Drawing.Point(18, 19);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(111, 33);
            this.btnActive.TabIndex = 12;
            this.btnActive.Text = "Aktif";
            this.btnActive.UseVisualStyleBackColor = true;
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
            // 
            // UCCalibrateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlAxis);
            this.Controls.Add(this.pnlJpg);
            this.Name = "UCCalibrateControl";
            this.Size = new System.Drawing.Size(749, 340);
            this.Load += new System.EventHandler(this.UCCalibrateControl_Load);
            this.pnlJpg.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlAxis;
        private System.Windows.Forms.Panel pnlJpg;
        private System.Windows.Forms.Button btnActive;
    }
}
