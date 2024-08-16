namespace ArduinoLEDControl
{
    partial class Form1
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
            this.btnSystemOn = new System.Windows.Forms.Button();
            this.btnSystemOff = new System.Windows.Forms.Button();
            this.txtData = new System.Windows.Forms.TextBox();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.comboBoxSerialPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSystemOn
            // 
            this.btnSystemOn.Location = new System.Drawing.Point(12, 53);
            this.btnSystemOn.Name = "btnSystemOn";
            this.btnSystemOn.Size = new System.Drawing.Size(100, 30);
            this.btnSystemOn.TabIndex = 0;
            this.btnSystemOn.Text = "System On";
            this.btnSystemOn.UseVisualStyleBackColor = true;
            this.btnSystemOn.Click += new System.EventHandler(this.btnSystemOn_Click);
            // 
            // btnSystemOff
            // 
            this.btnSystemOff.Location = new System.Drawing.Point(415, 53);
            this.btnSystemOff.Name = "btnSystemOff";
            this.btnSystemOff.Size = new System.Drawing.Size(100, 30);
            this.btnSystemOff.TabIndex = 1;
            this.btnSystemOff.Text = "System Off";
            this.btnSystemOff.UseVisualStyleBackColor = true;
            this.btnSystemOff.Click += new System.EventHandler(this.btnSystemOff_Click);
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(12, 98);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData.Size = new System.Drawing.Size(503, 276);
            this.txtData.TabIndex = 2;
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Location = new System.Drawing.Point(151, 389);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(191, 24);
            this.btnExportToExcel.TabIndex = 3;
            this.btnExportToExcel.Text = "Export Data to Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // comboBoxSerialPorts
            // 
            this.comboBoxSerialPorts.FormattingEnabled = true;
            this.comboBoxSerialPorts.Location = new System.Drawing.Point(221, 18);
            this.comboBoxSerialPorts.Name = "comboBoxSerialPorts";
            this.comboBoxSerialPorts.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSerialPorts.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select COM:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(527, 421);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxSerialPorts);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.btnSystemOff);
            this.Controls.Add(this.btnSystemOn);
            this.Name = "Form1";
            this.Text = "Arduino LED Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSystemOn;
        private System.Windows.Forms.Button btnSystemOff;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.ComboBox comboBoxSerialPorts;
        private System.Windows.Forms.Label label1;
    }
}
