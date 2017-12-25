namespace Server
{
    partial class ServerMainWin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.布局ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.下发数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.白名单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.黑名单管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.访客管理ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.进出记录ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.系统设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.广告管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据同步ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.白名单ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.黑名单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.访客ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.进出记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.广告管理ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.watcherPanel = new Server.WatchPanel4();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.布局ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.系统设置ToolStripMenuItem,
            this.数据同步ToolStripMenuItem,
            this.白名单ToolStripMenuItem1,
            this.黑名单ToolStripMenuItem,
            this.访客ToolStripMenuItem,
            this.进出记录ToolStripMenuItem,
            this.广告管理ToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 29);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 布局ToolStripMenuItem
            // 
            this.布局ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.布局ToolStripMenuItem.Name = "布局ToolStripMenuItem";
            this.布局ToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.布局ToolStripMenuItem.Text = "布局";
            this.布局ToolStripMenuItem.Visible = false;
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(89, 26);
            this.toolStripMenuItem2.Text = "1";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(89, 26);
            this.toolStripMenuItem3.Text = "2";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(89, 26);
            this.toolStripMenuItem4.Text = "3";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(89, 26);
            this.toolStripMenuItem5.Text = "4";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.下发数据ToolStripMenuItem,
            this.白名单ToolStripMenuItem,
            this.黑名单管理ToolStripMenuItem,
            this.访客管理ToolStripMenuItem1,
            this.进出记录ToolStripMenuItem1});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(86, 25);
            this.toolStripMenuItem1.Text = "数据维护";
            this.toolStripMenuItem1.Visible = false;
            // 
            // 下发数据ToolStripMenuItem
            // 
            this.下发数据ToolStripMenuItem.Name = "下发数据ToolStripMenuItem";
            this.下发数据ToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.下发数据ToolStripMenuItem.Text = "数据同步";
            this.下发数据ToolStripMenuItem.Click += new System.EventHandler(this.数据同步ToolStripMenuItem_Click);
            // 
            // 白名单ToolStripMenuItem
            // 
            this.白名单ToolStripMenuItem.Name = "白名单ToolStripMenuItem";
            this.白名单ToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.白名单ToolStripMenuItem.Text = "白名单管理";
            this.白名单ToolStripMenuItem.Click += new System.EventHandler(this.白名单ToolStripMenuItem_Click);
            // 
            // 黑名单管理ToolStripMenuItem
            // 
            this.黑名单管理ToolStripMenuItem.Name = "黑名单管理ToolStripMenuItem";
            this.黑名单管理ToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.黑名单管理ToolStripMenuItem.Text = "黑名单管理";
            this.黑名单管理ToolStripMenuItem.Click += new System.EventHandler(this.黑名单管理ToolStripMenuItem_Click);
            // 
            // 访客管理ToolStripMenuItem1
            // 
            this.访客管理ToolStripMenuItem1.Name = "访客管理ToolStripMenuItem1";
            this.访客管理ToolStripMenuItem1.Size = new System.Drawing.Size(160, 26);
            this.访客管理ToolStripMenuItem1.Text = "访客管理";
            this.访客管理ToolStripMenuItem1.Click += new System.EventHandler(this.访客管理ToolStripMenuItem1_Click);
            // 
            // 进出记录ToolStripMenuItem1
            // 
            this.进出记录ToolStripMenuItem1.Name = "进出记录ToolStripMenuItem1";
            this.进出记录ToolStripMenuItem1.Size = new System.Drawing.Size(160, 26);
            this.进出记录ToolStripMenuItem1.Text = "进出记录";
            this.进出记录ToolStripMenuItem1.Click += new System.EventHandler(this.进出记录ToolStripMenuItem1_Click);
            // 
            // 系统设置ToolStripMenuItem
            // 
            this.系统设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据库连接ToolStripMenuItem,
            this.广告管理ToolStripMenuItem});
            this.系统设置ToolStripMenuItem.Name = "系统设置ToolStripMenuItem";
            this.系统设置ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.系统设置ToolStripMenuItem.Text = "系统设置";
            this.系统设置ToolStripMenuItem.Visible = false;
            // 
            // 数据库连接ToolStripMenuItem
            // 
            this.数据库连接ToolStripMenuItem.Name = "数据库连接ToolStripMenuItem";
            this.数据库连接ToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.数据库连接ToolStripMenuItem.Text = "数据库连接";
            this.数据库连接ToolStripMenuItem.Click += new System.EventHandler(this.数据库连接ToolStripMenuItem_Click);
            // 
            // 广告管理ToolStripMenuItem
            // 
            this.广告管理ToolStripMenuItem.Name = "广告管理ToolStripMenuItem";
            this.广告管理ToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.广告管理ToolStripMenuItem.Text = "广告管理";
            this.广告管理ToolStripMenuItem.Click += new System.EventHandler(this.广告管理ToolStripMenuItem_Click);
            // 
            // 数据同步ToolStripMenuItem
            // 
            this.数据同步ToolStripMenuItem.Name = "数据同步ToolStripMenuItem";
            this.数据同步ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.数据同步ToolStripMenuItem.Text = "数据同步";
            this.数据同步ToolStripMenuItem.Click += new System.EventHandler(this.数据同步ToolStripMenuItem_Click_1);
            // 
            // 白名单ToolStripMenuItem1
            // 
            this.白名单ToolStripMenuItem1.Name = "白名单ToolStripMenuItem1";
            this.白名单ToolStripMenuItem1.Size = new System.Drawing.Size(70, 25);
            this.白名单ToolStripMenuItem1.Text = "白名单";
            this.白名单ToolStripMenuItem1.Click += new System.EventHandler(this.白名单ToolStripMenuItem1_Click);
            // 
            // 黑名单ToolStripMenuItem
            // 
            this.黑名单ToolStripMenuItem.Name = "黑名单ToolStripMenuItem";
            this.黑名单ToolStripMenuItem.Size = new System.Drawing.Size(70, 25);
            this.黑名单ToolStripMenuItem.Text = "黑名单";
            this.黑名单ToolStripMenuItem.Click += new System.EventHandler(this.黑名单ToolStripMenuItem_Click);
            // 
            // 访客ToolStripMenuItem
            // 
            this.访客ToolStripMenuItem.Name = "访客ToolStripMenuItem";
            this.访客ToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.访客ToolStripMenuItem.Text = "访客";
            this.访客ToolStripMenuItem.Click += new System.EventHandler(this.访客ToolStripMenuItem_Click);
            // 
            // 进出记录ToolStripMenuItem
            // 
            this.进出记录ToolStripMenuItem.Name = "进出记录ToolStripMenuItem";
            this.进出记录ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.进出记录ToolStripMenuItem.Text = "进出记录";
            this.进出记录ToolStripMenuItem.Click += new System.EventHandler(this.进出记录ToolStripMenuItem_Click);
            // 
            // 广告管理ToolStripMenuItem1
            // 
            this.广告管理ToolStripMenuItem1.Name = "广告管理ToolStripMenuItem1";
            this.广告管理ToolStripMenuItem1.Size = new System.Drawing.Size(86, 25);
            this.广告管理ToolStripMenuItem1.Text = "广告管理";
            this.广告管理ToolStripMenuItem1.Click += new System.EventHandler(this.广告管理ToolStripMenuItem1_Click);
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // watcherPanel
            // 
            this.watcherPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.watcherPanel.Location = new System.Drawing.Point(0, 29);
            this.watcherPanel.Name = "watcherPanel";
            this.watcherPanel.Size = new System.Drawing.Size(1008, 700);
            this.watcherPanel.TabIndex = 3;
            // 
            // ServerMainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.watcherPanel);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ServerMainWin";
            this.Text = "服务端";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ServerMainWin_FormClosed);
            this.Load += new System.EventHandler(this.ServerMainWin_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 布局ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 下发数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 白名单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 黑名单管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 访客管理ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 进出记录ToolStripMenuItem1;
        private WatchPanel4 watcherPanel;
        private System.Windows.Forms.ToolStripMenuItem 系统设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据库连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 广告管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据同步ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 白名单ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 黑名单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 访客ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 进出记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 广告管理ToolStripMenuItem1;
    }
}

