namespace DSPUI.ComponentsAttriutesEditor
{
    partial class Normalizer
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
            this.MaxValueTXBX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MinValueTXBX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CloseBTN
            // 
            this.CloseBTN.Location = new System.Drawing.Point(78, 64);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(75, 23);
            this.CloseBTN.TabIndex = 8;
            this.CloseBTN.Text = "Close";
            this.CloseBTN.UseVisualStyleBackColor = true;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // MaxValueTXBX
            // 
            this.MaxValueTXBX.Location = new System.Drawing.Point(53, 38);
            this.MaxValueTXBX.Name = "MaxValueTXBX";
            this.MaxValueTXBX.Size = new System.Drawing.Size(100, 20);
            this.MaxValueTXBX.TabIndex = 7;
            this.MaxValueTXBX.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Max";
            // 
            // MinValueTXBX
            // 
            this.MinValueTXBX.Location = new System.Drawing.Point(53, 12);
            this.MinValueTXBX.Name = "MinValueTXBX";
            this.MinValueTXBX.Size = new System.Drawing.Size(100, 20);
            this.MinValueTXBX.TabIndex = 10;
            this.MinValueTXBX.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Min";
            // 
            // Normalizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 99);
            this.Controls.Add(this.MinValueTXBX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CloseBTN);
            this.Controls.Add(this.MaxValueTXBX);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Normalizer";
            this.Text = "Normalizer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseBTN;
        private System.Windows.Forms.TextBox MaxValueTXBX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MinValueTXBX;
        private System.Windows.Forms.Label label2;
    }
}