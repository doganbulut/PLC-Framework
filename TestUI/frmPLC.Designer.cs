namespace TestUI
{
    partial class frmPLC
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
            this.lblConInfo = new System.Windows.Forms.Label();
            this.txtBoolPLC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBoolResult = new System.Windows.Forms.Label();
            this.txtBoolValue = new System.Windows.Forms.TextBox();
            this.btnBoolWrite = new System.Windows.Forms.Button();
            this.btnReadBool = new System.Windows.Forms.Button();
            this.lstPLCError = new System.Windows.Forms.ListBox();
            this.lstPLCNoitification = new System.Windows.Forms.ListBox();
            this.btnCreateBoolEvent = new System.Windows.Forms.Button();
            this.lstBoolChange = new System.Windows.Forms.ListBox();
            this.btnStopChange = new System.Windows.Forms.Button();
            this.lstValueError = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ucValueReader1 = new FCUI.UCValueReader();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblConInfo
            // 
            this.lblConInfo.AutoSize = true;
            this.lblConInfo.Location = new System.Drawing.Point(1, 2);
            this.lblConInfo.Name = "lblConInfo";
            this.lblConInfo.Size = new System.Drawing.Size(35, 13);
            this.lblConInfo.TabIndex = 0;
            this.lblConInfo.Text = "label1";
            // 
            // txtBoolPLC
            // 
            this.txtBoolPLC.Location = new System.Drawing.Point(4, 42);
            this.txtBoolPLC.Name = "txtBoolPLC";
            this.txtBoolPLC.Size = new System.Drawing.Size(100, 20);
            this.txtBoolPLC.TabIndex = 1;
            this.txtBoolPLC.Text = ".bManualKontrol";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bool";
            // 
            // lblBoolResult
            // 
            this.lblBoolResult.AutoSize = true;
            this.lblBoolResult.Location = new System.Drawing.Point(4, 69);
            this.lblBoolResult.Name = "lblBoolResult";
            this.lblBoolResult.Size = new System.Drawing.Size(68, 13);
            this.lblBoolResult.TabIndex = 3;
            this.lblBoolResult.Text = "lblBoolResult";
            // 
            // txtBoolValue
            // 
            this.txtBoolValue.Location = new System.Drawing.Point(7, 87);
            this.txtBoolValue.Name = "txtBoolValue";
            this.txtBoolValue.Size = new System.Drawing.Size(146, 20);
            this.txtBoolValue.TabIndex = 4;
            // 
            // btnBoolWrite
            // 
            this.btnBoolWrite.Location = new System.Drawing.Point(7, 113);
            this.btnBoolWrite.Name = "btnBoolWrite";
            this.btnBoolWrite.Size = new System.Drawing.Size(145, 23);
            this.btnBoolWrite.TabIndex = 5;
            this.btnBoolWrite.Text = "Write";
            this.btnBoolWrite.UseVisualStyleBackColor = true;
            this.btnBoolWrite.Click += new System.EventHandler(this.btnBoolWrite_Click);
            // 
            // btnReadBool
            // 
            this.btnReadBool.Location = new System.Drawing.Point(110, 39);
            this.btnReadBool.Name = "btnReadBool";
            this.btnReadBool.Size = new System.Drawing.Size(42, 23);
            this.btnReadBool.TabIndex = 6;
            this.btnReadBool.Text = "Read";
            this.btnReadBool.UseVisualStyleBackColor = true;
            this.btnReadBool.Click += new System.EventHandler(this.btnReadBool_Click);
            // 
            // lstPLCError
            // 
            this.lstPLCError.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstPLCError.FormattingEnabled = true;
            this.lstPLCError.Location = new System.Drawing.Point(0, 323);
            this.lstPLCError.Name = "lstPLCError";
            this.lstPLCError.Size = new System.Drawing.Size(817, 69);
            this.lstPLCError.TabIndex = 7;
            // 
            // lstPLCNoitification
            // 
            this.lstPLCNoitification.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstPLCNoitification.FormattingEnabled = true;
            this.lstPLCNoitification.Location = new System.Drawing.Point(0, 228);
            this.lstPLCNoitification.Name = "lstPLCNoitification";
            this.lstPLCNoitification.Size = new System.Drawing.Size(817, 95);
            this.lstPLCNoitification.TabIndex = 8;
            // 
            // btnCreateBoolEvent
            // 
            this.btnCreateBoolEvent.Location = new System.Drawing.Point(352, 39);
            this.btnCreateBoolEvent.Name = "btnCreateBoolEvent";
            this.btnCreateBoolEvent.Size = new System.Drawing.Size(43, 23);
            this.btnCreateBoolEvent.TabIndex = 9;
            this.btnCreateBoolEvent.Text = "Start";
            this.btnCreateBoolEvent.UseVisualStyleBackColor = true;
            this.btnCreateBoolEvent.Click += new System.EventHandler(this.btnCreateBoolEvent_Click);
            // 
            // lstBoolChange
            // 
            this.lstBoolChange.FormattingEnabled = true;
            this.lstBoolChange.Location = new System.Drawing.Point(226, 39);
            this.lstBoolChange.Name = "lstBoolChange";
            this.lstBoolChange.Size = new System.Drawing.Size(120, 95);
            this.lstBoolChange.TabIndex = 10;
            // 
            // btnStopChange
            // 
            this.btnStopChange.Location = new System.Drawing.Point(353, 69);
            this.btnStopChange.Name = "btnStopChange";
            this.btnStopChange.Size = new System.Drawing.Size(42, 23);
            this.btnStopChange.TabIndex = 11;
            this.btnStopChange.Text = "Stop";
            this.btnStopChange.UseVisualStyleBackColor = true;
            this.btnStopChange.Click += new System.EventHandler(this.btnStopChange_Click);
            // 
            // lstValueError
            // 
            this.lstValueError.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstValueError.FormattingEnabled = true;
            this.lstValueError.Location = new System.Drawing.Point(0, 159);
            this.lstValueError.Name = "lstValueError";
            this.lstValueError.Size = new System.Drawing.Size(817, 69);
            this.lstValueError.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(363, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ucValueReader1
            // 
            this.ucValueReader1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucValueReader1.Location = new System.Drawing.Point(464, 23);
            this.ucValueReader1.Name = "ucValueReader1";
            this.ucValueReader1.PlcController = null;
            this.ucValueReader1.PlcKey = null;
            this.ucValueReader1.Size = new System.Drawing.Size(150, 39);
            this.ucValueReader1.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(464, 68);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmPLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 392);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ucValueReader1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstValueError);
            this.Controls.Add(this.btnStopChange);
            this.Controls.Add(this.lstBoolChange);
            this.Controls.Add(this.btnCreateBoolEvent);
            this.Controls.Add(this.lstPLCNoitification);
            this.Controls.Add(this.lstPLCError);
            this.Controls.Add(this.btnReadBool);
            this.Controls.Add(this.btnBoolWrite);
            this.Controls.Add(this.txtBoolValue);
            this.Controls.Add(this.lblBoolResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoolPLC);
            this.Controls.Add(this.lblConInfo);
            this.Name = "frmPLC";
            this.Text = "frmPLC";
            this.Load += new System.EventHandler(this.frmPLC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConInfo;
        private System.Windows.Forms.TextBox txtBoolPLC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBoolResult;
        private System.Windows.Forms.TextBox txtBoolValue;
        private System.Windows.Forms.Button btnBoolWrite;
        private System.Windows.Forms.Button btnReadBool;
        private System.Windows.Forms.ListBox lstPLCError;
        private System.Windows.Forms.ListBox lstPLCNoitification;
        private System.Windows.Forms.Button btnCreateBoolEvent;
        private System.Windows.Forms.ListBox lstBoolChange;
        private System.Windows.Forms.Button btnStopChange;
        private System.Windows.Forms.ListBox lstValueError;
        private System.Windows.Forms.Button button1;
        private FCUI.UCValueReader ucValueReader1;
        private System.Windows.Forms.Button button2;
    }
}