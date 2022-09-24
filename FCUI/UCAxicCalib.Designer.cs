namespace FCUI
{
    partial class UCAxicCalib
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
            this.valueLabel = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.calibrationValueTextBox = new System.Windows.Forms.NumericUpDown();
            this.titleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.calibrationValueTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // valueLabel
            // 
            this.valueLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.valueLabel.BackColor = System.Drawing.Color.White;
            this.valueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.valueLabel.ForeColor = System.Drawing.Color.Black;
            this.valueLabel.Location = new System.Drawing.Point(102, 15);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(168, 27);
            this.valueLabel.TabIndex = 15;
            this.valueLabel.Text = "0";
            this.valueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // resetButton
            // 
            this.resetButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.resetButton.FlatAppearance.BorderSize = 0;
            this.resetButton.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.resetButton.Location = new System.Drawing.Point(32, 65);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(115, 31);
            this.resetButton.TabIndex = 14;
            this.resetButton.Text = "Calibrate";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // calibrationValueTextBox
            // 
            this.calibrationValueTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.calibrationValueTextBox.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.calibrationValueTextBox.Location = new System.Drawing.Point(153, 67);
            this.calibrationValueTextBox.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.calibrationValueTextBox.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.calibrationValueTextBox.Name = "calibrationValueTextBox";
            this.calibrationValueTextBox.Size = new System.Drawing.Size(117, 29);
            this.calibrationValueTextBox.TabIndex = 13;
            this.calibrationValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.titleLabel.Location = new System.Drawing.Point(3, 15);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(97, 27);
            this.titleLabel.TabIndex = 12;
            this.titleLabel.Text = "Axis";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCAxicCalib
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.valueLabel);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.calibrationValueTextBox);
            this.Controls.Add(this.titleLabel);
            this.Name = "UCAxicCalib";
            this.Size = new System.Drawing.Size(279, 111);
            ((System.ComponentModel.ISupportInitialize)(this.calibrationValueTextBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.NumericUpDown calibrationValueTextBox;
        private System.Windows.Forms.Label titleLabel;
    }
}
