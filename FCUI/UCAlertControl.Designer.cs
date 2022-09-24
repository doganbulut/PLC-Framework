namespace FCUI
{
    partial class UCAlertControl
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
            this.tblLayAlert = new System.Windows.Forms.TableLayoutPanel();
            this.btnHide = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.tblLayAlert.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblLayAlert
            // 
            this.tblLayAlert.ColumnCount = 2;
            this.tblLayAlert.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayAlert.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tblLayAlert.Controls.Add(this.btnHide, 1, 0);
            this.tblLayAlert.Controls.Add(this.txtMessage, 0, 0);
            this.tblLayAlert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayAlert.Location = new System.Drawing.Point(0, 0);
            this.tblLayAlert.Name = "tblLayAlert";
            this.tblLayAlert.RowCount = 1;
            this.tblLayAlert.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayAlert.Size = new System.Drawing.Size(762, 194);
            this.tblLayAlert.TabIndex = 0;
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(715, 3);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(44, 36);
            this.btnHide.TabIndex = 0;
            this.btnHide.Text = "-";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Location = new System.Drawing.Point(3, 3);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage.Size = new System.Drawing.Size(706, 188);
            this.txtMessage.TabIndex = 1;
            // 
            // UCAlertControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblLayAlert);
            this.Name = "UCAlertControl";
            this.Size = new System.Drawing.Size(762, 194);
            this.tblLayAlert.ResumeLayout(false);
            this.tblLayAlert.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblLayAlert;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.TextBox txtMessage;
    }
}
