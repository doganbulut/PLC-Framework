namespace FCUI
{
    partial class UCPlcAlarm
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
            this.pnlTool = new System.Windows.Forms.Panel();
            this.btnSet = new System.Windows.Forms.Button();
            this.grpView = new System.Windows.Forms.GroupBox();
            this.lstError = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAlarmDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAlarmDelDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAlarm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAlarmState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlTool.SuspendLayout();
            this.grpView.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTool
            // 
            this.pnlTool.Controls.Add(this.btnSet);
            this.pnlTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTool.Location = new System.Drawing.Point(0, 0);
            this.pnlTool.Name = "pnlTool";
            this.pnlTool.Size = new System.Drawing.Size(705, 32);
            this.pnlTool.TabIndex = 2;
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(3, 3);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(120, 23);
            this.btnSet.TabIndex = 0;
            this.btnSet.Text = "Onay";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // grpView
            // 
            this.grpView.Controls.Add(this.lstError);
            this.grpView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpView.Location = new System.Drawing.Point(0, 32);
            this.grpView.Name = "grpView";
            this.grpView.Size = new System.Drawing.Size(705, 286);
            this.grpView.TabIndex = 3;
            this.grpView.TabStop = false;
            this.grpView.Text = "Message";
            // 
            // lstError
            // 
            this.lstError.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colAlarmDate,
            this.colAlarmDelDate,
            this.colAlarm,
            this.colAlarmState});
            this.lstError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstError.FullRowSelect = true;
            this.lstError.GridLines = true;
            this.lstError.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstError.Location = new System.Drawing.Point(3, 16);
            this.lstError.MultiSelect = false;
            this.lstError.Name = "lstError";
            this.lstError.Size = new System.Drawing.Size(699, 267);
            this.lstError.TabIndex = 0;
            this.lstError.UseCompatibleStateImageBehavior = false;
            this.lstError.View = System.Windows.Forms.View.Details;
            this.lstError.SelectedIndexChanged += new System.EventHandler(this.lstError_SelectedIndexChanged);
            // 
            // colID
            // 
            this.colID.Text = "ID";
            // 
            // colAlarmDate
            // 
            this.colAlarmDate.Text = "Tarih";
            this.colAlarmDate.Width = 130;
            // 
            // colAlarmDelDate
            // 
            this.colAlarmDelDate.Text = "Tarih";
            this.colAlarmDelDate.Width = 121;
            // 
            // colAlarm
            // 
            this.colAlarm.Text = "Alarm";
            this.colAlarm.Width = 129;
            // 
            // colAlarmState
            // 
            this.colAlarmState.Text = "Durum";
            this.colAlarmState.Width = 151;
            // 
            // UCPlcAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpView);
            this.Controls.Add(this.pnlTool);
            this.Name = "UCPlcAlarm";
            this.Size = new System.Drawing.Size(705, 318);
            this.pnlTool.ResumeLayout(false);
            this.grpView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTool;
        private System.Windows.Forms.GroupBox grpView;
        private System.Windows.Forms.ListView lstError;
        private System.Windows.Forms.ColumnHeader colAlarmDate;
        private System.Windows.Forms.ColumnHeader colAlarmDelDate;
        private System.Windows.Forms.ColumnHeader colAlarm;
        private System.Windows.Forms.ColumnHeader colAlarmState;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.Button btnSet;
    }
}
