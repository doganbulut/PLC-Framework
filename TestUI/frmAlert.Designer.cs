namespace TestUI
{
    partial class frmAlert
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.PlcAlarm = new FCUI.UCPlcAlarm();
            this.ucAlertControl1 = new FCUI.UCAlertControl();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 327);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(208, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Message";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(214, 217);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add mEssage";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(711, 36);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // PlcAlarm
            // 
            this.PlcAlarm.AlarmsPlcController = null;
            this.PlcAlarm.Location = new System.Drawing.Point(0, 0);
            this.PlcAlarm.Name = "PlcAlarm";
            this.PlcAlarm.Size = new System.Drawing.Size(705, 318);
            this.PlcAlarm.TabIndex = 3;
            // 
            // ucAlertControl1
            // 
            this.ucAlertControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucAlertControl1.HideAlarm = false;
            this.ucAlertControl1.Location = new System.Drawing.Point(0, 353);
            this.ucAlertControl1.Name = "ucAlertControl1";
            this.ucAlertControl1.Size = new System.Drawing.Size(863, 115);
            this.ucAlertControl1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(711, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 468);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.PlcAlarm);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ucAlertControl1);
            this.Name = "frmAlert";
            this.Text = "frmAlert";
            this.Load += new System.EventHandler(this.frmAlert_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FCUI.UCAlertControl ucAlertControl1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAdd;
        private FCUI.UCPlcAlarm PlcAlarm;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button button1;
    }
}