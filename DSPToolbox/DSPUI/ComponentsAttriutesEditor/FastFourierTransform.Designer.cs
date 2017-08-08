namespace DSPUI.ComponentsAttriutesEditor
{
    partial class FastFourierTransform
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
            this.SamplingFreqTXBX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CloseBTN
            // 
            this.CloseBTN.Location = new System.Drawing.Point(146, 48);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(75, 23);
            this.CloseBTN.TabIndex = 5;
            this.CloseBTN.Text = "Close";
            this.CloseBTN.UseVisualStyleBackColor = true;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // SamplingFreqTXBX
            // 
            this.SamplingFreqTXBX.Location = new System.Drawing.Point(121, 16);
            this.SamplingFreqTXBX.Name = "SamplingFreqTXBX";
            this.SamplingFreqTXBX.Size = new System.Drawing.Size(100, 20);
            this.SamplingFreqTXBX.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sampling Frequency";
            // 
            // FastFourierTransform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 83);
            this.Controls.Add(this.CloseBTN);
            this.Controls.Add(this.SamplingFreqTXBX);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FastFourierTransform";
            this.Text = "FFT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseBTN;
        private System.Windows.Forms.TextBox SamplingFreqTXBX;
        private System.Windows.Forms.Label label1;
    }
}