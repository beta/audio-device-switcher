namespace Audio_Device_Switcher {
    partial class frmPanel {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPanel));
            this.panelBottom = new System.Windows.Forms.Panel();
            this.linkAudioDevice = new System.Windows.Forms.LinkLabel();
            this.panelDivider2 = new System.Windows.Forms.Panel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.audioDeviceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.panelList = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrentDevice = new System.Windows.Forms.Label();
            this.panelDivider1 = new System.Windows.Forms.Panel();
            this.panelBottom.SuspendLayout();
            this.notifyIconMenuStrip.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.panelBottom.Controls.Add(this.linkAudioDevice);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 316);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(284, 44);
            this.panelBottom.TabIndex = 0;
            // 
            // linkAudioDevice
            // 
            this.linkAudioDevice.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(208)))));
            this.linkAudioDevice.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkAudioDevice.AutoSize = true;
            this.linkAudioDevice.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkAudioDevice.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(208)))));
            this.linkAudioDevice.Location = new System.Drawing.Point(107, 13);
            this.linkAudioDevice.Name = "linkAudioDevice";
            this.linkAudioDevice.Size = new System.Drawing.Size(71, 17);
            this.linkAudioDevice.TabIndex = 0;
            this.linkAudioDevice.TabStop = true;
            this.linkAudioDevice.Text = "播放设备(&P)";
            this.linkAudioDevice.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(208)))));
            this.linkAudioDevice.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAudioDevice_LinkClicked);
            // 
            // panelDivider2
            // 
            this.panelDivider2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.panelDivider2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDivider2.Location = new System.Drawing.Point(0, 315);
            this.panelDivider2.Name = "panelDivider2";
            this.panelDivider2.Size = new System.Drawing.Size(284, 1);
            this.panelDivider2.TabIndex = 1;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyIconMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Audio Device Switcher";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // notifyIconMenuStrip
            // 
            this.notifyIconMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.audioDeviceMenuItem,
            this.toolStripSeparator1,
            this.aboutMenuItem,
            this.exitMenuItem});
            this.notifyIconMenuStrip.Name = "contextMenuStrip1";
            this.notifyIconMenuStrip.Size = new System.Drawing.Size(140, 76);
            // 
            // audioDeviceMenuItem
            // 
            this.audioDeviceMenuItem.Name = "audioDeviceMenuItem";
            this.audioDeviceMenuItem.Size = new System.Drawing.Size(139, 22);
            this.audioDeviceMenuItem.Text = "播放设备(&P)";
            this.audioDeviceMenuItem.Click += new System.EventHandler(this.audioDeviceMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(136, 6);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(139, 22);
            this.aboutMenuItem.Text = "关于(&A)";
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(139, 22);
            this.exitMenuItem.Text = "退出(&X)";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.panelList);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(0, 48);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(284, 267);
            this.panelMiddle.TabIndex = 2;
            // 
            // panelList
            // 
            this.panelList.AutoScroll = true;
            this.panelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelList.Location = new System.Drawing.Point(0, 0);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(284, 267);
            this.panelList.TabIndex = 0;
            this.panelList.SizeChanged += new System.EventHandler(this.panelList_SizeChanged);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.picLogo);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.lblCurrentDevice);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(284, 48);
            this.panelTop.TabIndex = 4;
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(16, 6);
            this.picLogo.MaximumSize = new System.Drawing.Size(36, 36);
            this.picLogo.MinimumSize = new System.Drawing.Size(36, 36);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(36, 36);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 2;
            this.picLogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(208)))));
            this.label1.Location = new System.Drawing.Point(54, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "当前的默认音频设备";
            // 
            // lblCurrentDevice
            // 
            this.lblCurrentDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentDevice.AutoEllipsis = true;
            this.lblCurrentDevice.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentDevice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(208)))));
            this.lblCurrentDevice.Location = new System.Drawing.Point(54, 7);
            this.lblCurrentDevice.Name = "lblCurrentDevice";
            this.lblCurrentDevice.Size = new System.Drawing.Size(214, 17);
            this.lblCurrentDevice.TabIndex = 0;
            // 
            // panelDivider1
            // 
            this.panelDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
            this.panelDivider1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDivider1.Location = new System.Drawing.Point(0, 48);
            this.panelDivider1.Name = "panelDivider1";
            this.panelDivider1.Size = new System.Drawing.Size(284, 1);
            this.panelDivider1.TabIndex = 5;
            // 
            // frmPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 360);
            this.ControlBox = false;
            this.Controls.Add(this.panelDivider1);
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelDivider2);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPanel";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Deactivate += new System.EventHandler(this.frmPanel_Deactivate);
            this.Load += new System.EventHandler(this.frmPanel_Load);
            this.Shown += new System.EventHandler(this.frmPanel_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPanel_KeyDown);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.notifyIconMenuStrip.ResumeLayout(false);
            this.panelMiddle.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelDivider2;
        private System.Windows.Forms.LinkLabel linkAudioDevice;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyIconMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem audioDeviceMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.Panel panelMiddle;
        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelDivider1;
        private System.Windows.Forms.Label lblCurrentDevice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picLogo;
    }
}

