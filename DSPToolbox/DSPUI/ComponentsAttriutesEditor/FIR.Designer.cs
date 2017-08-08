namespace DSPUI.ComponentsAttriutesEditor
{
    partial class FIR
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
            this.LowPassFilterRB = new System.Windows.Forms.RadioButton();
            this.HighPassFilterRB = new System.Windows.Forms.RadioButton();
            this.BandPassFilterRB = new System.Windows.Forms.RadioButton();
            this.BandStopFilterRB = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FSTXTBX = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CutOffFrequencyTXTBX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.F1TXTBX = new System.Windows.Forms.TextBox();
            this.F2TXTBX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.StopBandDeviationTXTBX = new System.Windows.Forms.TextBox();
            this.TransitionBandTXTBX = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CloseBTN = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LowPassFilterRB
            // 
            this.LowPassFilterRB.AutoSize = true;
            this.LowPassFilterRB.Location = new System.Drawing.Point(12, 17);
            this.LowPassFilterRB.Name = "LowPassFilterRB";
            this.LowPassFilterRB.Size = new System.Drawing.Size(96, 17);
            this.LowPassFilterRB.TabIndex = 0;
            this.LowPassFilterRB.TabStop = true;
            this.LowPassFilterRB.Text = "Low Pass Filter";
            this.LowPassFilterRB.UseVisualStyleBackColor = true;
            // 
            // HighPassFilterRB
            // 
            this.HighPassFilterRB.AutoSize = true;
            this.HighPassFilterRB.Location = new System.Drawing.Point(115, 17);
            this.HighPassFilterRB.Name = "HighPassFilterRB";
            this.HighPassFilterRB.Size = new System.Drawing.Size(98, 17);
            this.HighPassFilterRB.TabIndex = 1;
            this.HighPassFilterRB.TabStop = true;
            this.HighPassFilterRB.Text = "High Pass Filter";
            this.HighPassFilterRB.UseVisualStyleBackColor = true;
            // 
            // BandPassFilterRB
            // 
            this.BandPassFilterRB.AutoSize = true;
            this.BandPassFilterRB.Location = new System.Drawing.Point(12, 41);
            this.BandPassFilterRB.Name = "BandPassFilterRB";
            this.BandPassFilterRB.Size = new System.Drawing.Size(101, 17);
            this.BandPassFilterRB.TabIndex = 2;
            this.BandPassFilterRB.TabStop = true;
            this.BandPassFilterRB.Text = "Band Pass Filter";
            this.BandPassFilterRB.UseVisualStyleBackColor = true;
            // 
            // BandStopFilterRB
            // 
            this.BandStopFilterRB.AutoSize = true;
            this.BandStopFilterRB.Location = new System.Drawing.Point(115, 41);
            this.BandStopFilterRB.Name = "BandStopFilterRB";
            this.BandStopFilterRB.Size = new System.Drawing.Size(101, 17);
            this.BandStopFilterRB.TabIndex = 3;
            this.BandStopFilterRB.TabStop = true;
            this.BandStopFilterRB.Text = "Band Stop Filter";
            this.BandStopFilterRB.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filter Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sampling Frequency";
            // 
            // FSTXTBX
            // 
            this.FSTXTBX.Location = new System.Drawing.Point(141, 94);
            this.FSTXTBX.Name = "FSTXTBX";
            this.FSTXTBX.Size = new System.Drawing.Size(164, 20);
            this.FSTXTBX.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HighPassFilterRB);
            this.groupBox1.Controls.Add(this.LowPassFilterRB);
            this.groupBox1.Controls.Add(this.BandPassFilterRB);
            this.groupBox1.Controls.Add(this.BandStopFilterRB);
            this.groupBox1.Location = new System.Drawing.Point(85, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 68);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "CutOffFrequency";
            // 
            // CutOffFrequencyTXTBX
            // 
            this.CutOffFrequencyTXTBX.Location = new System.Drawing.Point(141, 120);
            this.CutOffFrequencyTXTBX.Name = "CutOffFrequencyTXTBX";
            this.CutOffFrequencyTXTBX.Size = new System.Drawing.Size(164, 20);
            this.CutOffFrequencyTXTBX.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "F1";
            // 
            // F1TXTBX
            // 
            this.F1TXTBX.Location = new System.Drawing.Point(141, 148);
            this.F1TXTBX.Name = "F1TXTBX";
            this.F1TXTBX.Size = new System.Drawing.Size(164, 20);
            this.F1TXTBX.TabIndex = 6;
            // 
            // F2TXTBX
            // 
            this.F2TXTBX.Location = new System.Drawing.Point(141, 175);
            this.F2TXTBX.Name = "F2TXTBX";
            this.F2TXTBX.Size = new System.Drawing.Size(164, 20);
            this.F2TXTBX.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(105, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "F2";
            // 
            // StopBandDeviationTXTBX
            // 
            this.StopBandDeviationTXTBX.Location = new System.Drawing.Point(141, 201);
            this.StopBandDeviationTXTBX.Name = "StopBandDeviationTXTBX";
            this.StopBandDeviationTXTBX.Size = new System.Drawing.Size(164, 20);
            this.StopBandDeviationTXTBX.TabIndex = 6;
            // 
            // TransitionBandTXTBX
            // 
            this.TransitionBandTXTBX.Location = new System.Drawing.Point(141, 228);
            this.TransitionBandTXTBX.Name = "TransitionBandTXTBX";
            this.TransitionBandTXTBX.Size = new System.Drawing.Size(164, 20);
            this.TransitionBandTXTBX.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "StopBandAttenuation";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 231);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "TransitionBand";
            // 
            // CloseBTN
            // 
            this.CloseBTN.Location = new System.Drawing.Point(123, 259);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(75, 23);
            this.CloseBTN.TabIndex = 9;
            this.CloseBTN.Text = "Close";
            this.CloseBTN.UseVisualStyleBackColor = true;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // FIR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 294);
            this.Controls.Add(this.CloseBTN);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TransitionBandTXTBX);
            this.Controls.Add(this.StopBandDeviationTXTBX);
            this.Controls.Add(this.F2TXTBX);
            this.Controls.Add(this.F1TXTBX);
            this.Controls.Add(this.CutOffFrequencyTXTBX);
            this.Controls.Add(this.FSTXTBX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FIR";
            this.Text = "FIR";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton LowPassFilterRB;
        private System.Windows.Forms.RadioButton HighPassFilterRB;
        private System.Windows.Forms.RadioButton BandPassFilterRB;
        private System.Windows.Forms.RadioButton BandStopFilterRB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FSTXTBX;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CutOffFrequencyTXTBX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox F1TXTBX;
        private System.Windows.Forms.TextBox F2TXTBX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox StopBandDeviationTXTBX;
        private System.Windows.Forms.TextBox TransitionBandTXTBX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button CloseBTN;
        private System.Windows.Forms.Label label6;
    }
}