namespace FCERP
{
    partial class frmErp
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstPomp1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstPomp2 = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstPomp3 = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstPomp1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Size = new System.Drawing.Size(648, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pompa(1)";
            // 
            // lstPomp1
            // 
            this.lstPomp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPomp1.FormattingEnabled = true;
            this.lstPomp1.ItemHeight = 20;
            this.lstPomp1.Items.AddRange(new object[] {
            "Akış Başladı : 01-02-2016 11:02:56",
            "Miktar : 28750 Litre",
            "Akış Durdu : 01-02-2016 11.15.15"});
            this.lstPomp1.Location = new System.Drawing.Point(5, 24);
            this.lstPomp1.Name = "lstPomp1";
            this.lstPomp1.Size = new System.Drawing.Size(638, 96);
            this.lstPomp1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstPomp2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 125);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(648, 125);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pompa(2)";
            // 
            // lstPomp2
            // 
            this.lstPomp2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPomp2.FormattingEnabled = true;
            this.lstPomp2.ItemHeight = 20;
            this.lstPomp2.Items.AddRange(new object[] {
            "Akış Başladı : 01-02-2016 13:02:45",
            "Miktar : 488750 Litre",
            "Akış Durdu : 01-02-2016 13.56.00"});
            this.lstPomp2.Location = new System.Drawing.Point(5, 24);
            this.lstPomp2.Name = "lstPomp2";
            this.lstPomp2.Size = new System.Drawing.Size(638, 96);
            this.lstPomp2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstPomp3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 250);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox3.Size = new System.Drawing.Size(648, 125);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pompa(3)";
            // 
            // lstPomp3
            // 
            this.lstPomp3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPomp3.FormattingEnabled = true;
            this.lstPomp3.ItemHeight = 20;
            this.lstPomp3.Items.AddRange(new object[] {
            "Akış Başladı : 01-02-2016 10:54:45",
            "Miktar : 95800 Litre",
            "Akış Durdu : 01-02-2016 11:50:50"});
            this.lstPomp3.Location = new System.Drawing.Point(5, 24);
            this.lstPomp3.Name = "lstPomp3";
            this.lstPomp3.Size = new System.Drawing.Size(638, 96);
            this.lstPomp3.TabIndex = 0;
            // 
            // frmErp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 531);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmErp";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstPomp1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstPomp2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstPomp3;
    }
}

