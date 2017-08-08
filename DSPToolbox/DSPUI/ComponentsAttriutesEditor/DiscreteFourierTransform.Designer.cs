namespace DSPUI.ComponentsAttriutesEditor
{
    partial class DiscreteFourierTransform
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
            this.label1 = new System.Windows.Forms.Label();
            this.SamplingFreqTXBX = new System.Windows.Forms.TextBox();
            this.CloseBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sampling Frequency";
            // 
            // SamplingFreqTXBX
            // 
            this.SamplingFreqTXBX.Location = new System.Drawing.Point(121, 16);
            this.SamplingFreqTXBX.Name = "SamplingFreqTXBX";
            this.SamplingFreqTXBX.Size = new System.Drawing.Size(100, 20);
            this.SamplingFreqTXBX.TabIndex = 1;
            // 
            // CloseBTN
            // 
            this.CloseBTN.Location = new System.Drawing.Point(146, 45);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(75, 23);
            this.CloseBTN.TabIndex = 2;
            this.CloseBTN.Text = "Close";
            this.CloseBTN.UseVisualStyleBackColor = true;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // DiscreteFourierTransform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 80);
            this.Controls.Add(this.CloseBTN);
            this.Controls.Add(this.SamplingFreqTXBX);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiscreteFourierTransform";
            this.Text = "DFT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SamplingFreqTXBX;
        private System.Windows.Forms.Button CloseBTN;
    }
}