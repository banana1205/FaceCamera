namespace Server
{
    partial class WatchPanel1
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.clientWatch1 = new Server.ClientWatch();
            this.SuspendLayout();
            // 
            // clientWatch1
            // 
            this.clientWatch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientWatch1.Location = new System.Drawing.Point(0, 0);
            this.clientWatch1.Name = "clientWatch1";
            this.clientWatch1.Size = new System.Drawing.Size(395, 411);
            this.clientWatch1.TabIndex = 0;
            // 
            // WatchPanel1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clientWatch1);
            this.Name = "WatchPanel1";
            this.Size = new System.Drawing.Size(395, 411);
            this.Load += new System.EventHandler(this.WatchPanel1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ClientWatch clientWatch1;

    }
}
