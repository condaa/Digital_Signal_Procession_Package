namespace DSPUI.ComponentsAttriutesEditor
{
    partial class MultiplySignalByConstant
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
            this.ConstantTXBX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CloseBTN
            // 
            this.CloseBTN.Location = new System.Drawing.Point(86, 41);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(75, 23);
            this.CloseBTN.TabIndex = 8;
            this.CloseBTN.Text = "Close";
            this.CloseBTN.UseVisualStyleBackColor = true;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // ConstantTXBX
            // 
            this.ConstantTXBX.Location = new System.Drawing.Point(98, 12);
            this.ConstantTXBX.Name = "ConstantTXBX";
            this.ConstantTXBX.Size = new System.Drawing.Size(63, 20);
            this.ConstantTXBX.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Constant Value";
            // 
            // MultiplySignalByConstant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(174, 75);
            this.Controls.Add(this.CloseBTN);
            this.Controls.Add(this.ConstantTXBX);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MultiplySignalByConstant";
            this.Text = "Mult";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseBTN;
        private System.Windows.Forms.TextBox ConstantTXBX;
        private System.Windows.Forms.Label label1;
    }
}