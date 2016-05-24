namespace SlimCamPreview
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
            this.videoPanel = new System.Windows.Forms.Panel();
            this.clickPanel = new SlimCamPreview.TransparentPanel();
            this.videoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoPanel
            // 
            this.videoPanel.Controls.Add(this.clickPanel);
            this.videoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPanel.Location = new System.Drawing.Point(0, 0);
            this.videoPanel.Name = "videoPanel";
            this.videoPanel.Size = new System.Drawing.Size(1269, 686);
            this.videoPanel.TabIndex = 0;
            // 
            // clickPanel
            // 
            this.clickPanel.BackColor = System.Drawing.Color.Transparent;
            this.clickPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clickPanel.Location = new System.Drawing.Point(0, 0);
            this.clickPanel.Name = "clickPanel";
            this.clickPanel.Size = new System.Drawing.Size(1269, 686);
            this.clickPanel.TabIndex = 0;
            this.clickPanel.DoubleClick += new System.EventHandler(this.clickPanel_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1269, 686);
            this.Controls.Add(this.videoPanel);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SlimCamPreview";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.videoPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel videoPanel;
        private TransparentPanel clickPanel;
    }
}

