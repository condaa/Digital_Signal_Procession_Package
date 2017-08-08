namespace DSPUI.ComponentsAttriutesEditor
{
    partial class Shifter
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
            this.ShiftingValueTXBX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CloseBTN
            // 
            this.CloseBTN.Location = new System.Drawing.Point(85, 50);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(75, 23);
            this.CloseBTN.TabIndex = 5;
            this.CloseBTN.Text = "Close";
            this.CloseBTN.UseVisualStyleBackColor = true;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // ShiftingValueTXBX
            // 
            this.ShiftingValueTXBX.Location = new System.Drawing.Point(60, 21);
            this.ShiftingValueTXBX.Name = "ShiftingValueTXBX";
            this.ShiftingValueTXBX.Size = new System.Drawing.Size(100, 20);
            this.ShiftingValueTXBX.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Shift by";
            // 
            // Shifter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(172, 89);
            this.Controls.Add(this.CloseBTN);
            this.Controls.Add(this.ShiftingValueTXBX);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Shifter";
            this.Text = "Shifter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseBTN;
        private System.Windows.Forms.TextBox ShiftingValueTXBX;
        private System.Windows.Forms.Label label1;
    }
}