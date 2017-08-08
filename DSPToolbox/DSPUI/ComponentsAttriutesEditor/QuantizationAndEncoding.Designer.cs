namespace DSPUI.ComponentsAttriutesEditor
{
    partial class QuantizationAndEncoding
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
            this.CloseBTN = new System.Windows.Forms.Button();
            this.LevelCBX = new System.Windows.Forms.RadioButton();
            this.NumBitsCBX = new System.Windows.Forms.RadioButton();
            this.LevelTXBX = new System.Windows.Forms.TextBox();
            this.NumBitsTXBX = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseBTN
            // 
            this.CloseBTN.Location = new System.Drawing.Point(47, 71);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(75, 23);
            this.CloseBTN.TabIndex = 0;
            this.CloseBTN.Text = "Close";
            this.CloseBTN.UseVisualStyleBackColor = true;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // LevelCBX
            // 
            this.LevelCBX.AutoSize = true;
            this.LevelCBX.Checked = true;
            this.LevelCBX.Location = new System.Drawing.Point(6, 19);
            this.LevelCBX.Name = "LevelCBX";
            this.LevelCBX.Size = new System.Drawing.Size(51, 17);
            this.LevelCBX.TabIndex = 3;
            this.LevelCBX.TabStop = true;
            this.LevelCBX.Text = "Level";
            this.LevelCBX.UseVisualStyleBackColor = true;
            this.LevelCBX.CheckedChanged += new System.EventHandler(this.LevelCBX_CheckedChanged);
            // 
            // NumBitsCBX
            // 
            this.NumBitsCBX.AutoSize = true;
            this.NumBitsCBX.Location = new System.Drawing.Point(6, 42);
            this.NumBitsCBX.Name = "NumBitsCBX";
            this.NumBitsCBX.Size = new System.Drawing.Size(94, 17);
            this.NumBitsCBX.TabIndex = 3;
            this.NumBitsCBX.TabStop = true;
            this.NumBitsCBX.Text = "Number of Bits";
            this.NumBitsCBX.UseVisualStyleBackColor = true;
            this.NumBitsCBX.CheckedChanged += new System.EventHandler(this.NumBitsCBX_CheckedChanged);
            // 
            // LevelTXBX
            // 
            this.LevelTXBX.Location = new System.Drawing.Point(106, 16);
            this.LevelTXBX.Name = "LevelTXBX";
            this.LevelTXBX.Size = new System.Drawing.Size(51, 20);
            this.LevelTXBX.TabIndex = 4;
            this.LevelTXBX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LevelTXBX_KeyDown);
            // 
            // NumBitsTXBX
            // 
            this.NumBitsTXBX.Enabled = false;
            this.NumBitsTXBX.Location = new System.Drawing.Point(106, 39);
            this.NumBitsTXBX.Name = "NumBitsTXBX";
            this.NumBitsTXBX.Size = new System.Drawing.Size(51, 20);
            this.NumBitsTXBX.TabIndex = 4;
            this.NumBitsTXBX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumBitsTXBX_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LevelCBX);
            this.groupBox1.Controls.Add(this.NumBitsTXBX);
            this.groupBox1.Controls.Add(this.CloseBTN);
            this.groupBox1.Controls.Add(this.LevelTXBX);
            this.groupBox1.Controls.Add(this.NumBitsCBX);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // QuantizationAndEncoding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 124);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuantizationAndEncoding";
            this.Text = "Quan&Enc";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CloseBTN;
        private System.Windows.Forms.RadioButton LevelCBX;
        private System.Windows.Forms.RadioButton NumBitsCBX;
        private System.Windows.Forms.TextBox LevelTXBX;
        private System.Windows.Forms.TextBox NumBitsTXBX;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}