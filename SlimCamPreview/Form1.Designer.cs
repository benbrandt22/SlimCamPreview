﻿namespace SlimCamPreview
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
            this.components = new System.ComponentModel.Container();
            this.videoPanel = new System.Windows.Forms.Panel();
            this.RightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miChooseCamera = new System.Windows.Forms.ToolStripMenuItem();
            this.miWindowBorderVisible = new System.Windows.Forms.ToolStripMenuItem();
            this.clickPanel = new SlimCamPreview.TransparentPanel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miKeepOnTop = new System.Windows.Forms.ToolStripMenuItem();
            this.videoPanel.SuspendLayout();
            this.RightClickMenu.SuspendLayout();
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
            // RightClickMenu
            // 
            this.RightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miChooseCamera,
            this.toolStripSeparator1,
            this.miWindowBorderVisible,
            this.miKeepOnTop});
            this.RightClickMenu.Name = "RightClickMenu";
            this.RightClickMenu.Size = new System.Drawing.Size(194, 98);
            this.RightClickMenu.Opening += new System.ComponentModel.CancelEventHandler(this.RightClickMenu_Opening);
            // 
            // miChooseCamera
            // 
            this.miChooseCamera.Name = "miChooseCamera";
            this.miChooseCamera.Size = new System.Drawing.Size(193, 22);
            this.miChooseCamera.Text = "Choose Camera";
            this.miChooseCamera.DropDownOpening += new System.EventHandler(this.miChooseCamera_DropDownOpening);
            // 
            // miWindowBorderVisible
            // 
            this.miWindowBorderVisible.Checked = true;
            this.miWindowBorderVisible.CheckOnClick = true;
            this.miWindowBorderVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miWindowBorderVisible.Name = "miWindowBorderVisible";
            this.miWindowBorderVisible.Size = new System.Drawing.Size(193, 22);
            this.miWindowBorderVisible.Text = "Window Border Visible";
            this.miWindowBorderVisible.Click += new System.EventHandler(this.miWindowBorderVisible_Click);
            // 
            // clickPanel
            // 
            this.clickPanel.BackColor = System.Drawing.Color.Transparent;
            this.clickPanel.ContextMenuStrip = this.RightClickMenu;
            this.clickPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clickPanel.Location = new System.Drawing.Point(0, 0);
            this.clickPanel.Name = "clickPanel";
            this.clickPanel.Size = new System.Drawing.Size(1269, 686);
            this.clickPanel.TabIndex = 0;
            this.clickPanel.DoubleClick += new System.EventHandler(this.clickPanel_DoubleClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // miKeepOnTop
            // 
            this.miKeepOnTop.CheckOnClick = true;
            this.miKeepOnTop.Name = "miKeepOnTop";
            this.miKeepOnTop.Size = new System.Drawing.Size(193, 22);
            this.miKeepOnTop.Text = "Keep On Top";
            this.miKeepOnTop.Click += new System.EventHandler(this.miKeepOnTop_Click);
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
            this.RightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel videoPanel;
        private TransparentPanel clickPanel;
        private System.Windows.Forms.ContextMenuStrip RightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem miChooseCamera;
        private System.Windows.Forms.ToolStripMenuItem miWindowBorderVisible;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miKeepOnTop;
    }
}

