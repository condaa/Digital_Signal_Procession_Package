namespace DSPUI
{
    partial class DSPToolbox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DSPToolbox));
            this.MainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CanvasPBX = new System.Windows.Forms.PictureBox();
            this.ToolsPNL = new System.Windows.Forms.Panel();
            this.RunBTN = new System.Windows.Forms.Button();
            this.MainLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CanvasPBX)).BeginInit();
            this.ToolsPNL.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLayoutPanel
            // 
            this.MainLayoutPanel.ColumnCount = 2;
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.445101F));
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.5549F));
            this.MainLayoutPanel.Controls.Add(this.CanvasPBX, 1, 0);
            this.MainLayoutPanel.Controls.Add(this.ToolsPNL, 0, 0);
            this.MainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainLayoutPanel.Name = "MainLayoutPanel";
            this.MainLayoutPanel.RowCount = 1;
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainLayoutPanel.Size = new System.Drawing.Size(954, 553);
            this.MainLayoutPanel.TabIndex = 0;
            // 
            // CanvasPBX
            // 
            this.CanvasPBX.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CanvasPBX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CanvasPBX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CanvasPBX.Location = new System.Drawing.Point(100, 10);
            this.CanvasPBX.Margin = new System.Windows.Forms.Padding(10, 10, 5, 10);
            this.CanvasPBX.Name = "CanvasPBX";
            this.CanvasPBX.Size = new System.Drawing.Size(849, 533);
            this.CanvasPBX.TabIndex = 0;
            this.CanvasPBX.TabStop = false;
            this.CanvasPBX.Paint += new System.Windows.Forms.PaintEventHandler(this.CanvasPBX_Paint);
            this.CanvasPBX.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CanvasPBX_MouseClick);
            this.CanvasPBX.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CanvasPBX_MouseDoubleClick);
            this.CanvasPBX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CanvasPBX_MouseDown);
            this.CanvasPBX.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CanvasPBX_MouseMove);
            this.CanvasPBX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CanvasPBX_MouseUp);
            // 
            // ToolsPNL
            // 
            this.ToolsPNL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ToolsPNL.Controls.Add(this.RunBTN);
            this.ToolsPNL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolsPNL.Location = new System.Drawing.Point(10, 10);
            this.ToolsPNL.Margin = new System.Windows.Forms.Padding(10, 10, 5, 10);
            this.ToolsPNL.Name = "ToolsPNL";
            this.ToolsPNL.Size = new System.Drawing.Size(75, 533);
            this.ToolsPNL.TabIndex = 0;
            // 
            // RunBTN
            // 
            this.RunBTN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RunBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.RunBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RunBTN.Location = new System.Drawing.Point(3, 501);
            this.RunBTN.Margin = new System.Windows.Forms.Padding(0);
            this.RunBTN.Name = "RunBTN";
            this.RunBTN.Size = new System.Drawing.Size(67, 27);
            this.RunBTN.TabIndex = 1;
            this.RunBTN.Text = "Run";
            this.RunBTN.UseVisualStyleBackColor = false;
            this.RunBTN.Click += new System.EventHandler(this.RunBTN_Click);
            // 
            // DSPToolbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 553);
            this.Controls.Add(this.MainLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DSPToolbox";
            this.Text = "DSP Toolbox";
            this.MainLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CanvasPBX)).EndInit();
            this.ToolsPNL.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainLayoutPanel;
        private System.Windows.Forms.Panel ToolsPNL;
        private System.Windows.Forms.Button RunBTN;
        private System.Windows.Forms.PictureBox CanvasPBX;
    }
}

