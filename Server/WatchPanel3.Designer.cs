namespace Server
{
    partial class WatchPanel3
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.clientWatch2 = new Server.ClientWatch();
            this.clientWatch3 = new Server.ClientWatch();
            this.clientWatch1 = new Server.ClientWatch();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.clientWatch1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1178, 666);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.clientWatch2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.clientWatch3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(789, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(389, 666);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // clientWatch2
            // 
            this.clientWatch2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientWatch2.Location = new System.Drawing.Point(3, 3);
            this.clientWatch2.Name = "clientWatch2";
            this.clientWatch2.Size = new System.Drawing.Size(383, 327);
            this.clientWatch2.TabIndex = 2;
            // 
            // clientWatch3
            // 
            this.clientWatch3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientWatch3.Location = new System.Drawing.Point(3, 336);
            this.clientWatch3.Name = "clientWatch3";
            this.clientWatch3.Size = new System.Drawing.Size(383, 327);
            this.clientWatch3.TabIndex = 3;
            // 
            // clientWatch1
            // 
            this.clientWatch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientWatch1.Location = new System.Drawing.Point(3, 3);
            this.clientWatch1.Name = "clientWatch1";
            this.clientWatch1.Size = new System.Drawing.Size(783, 660);
            this.clientWatch1.TabIndex = 1;
            // 
            // WatchPanel3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "WatchPanel3";
            this.Size = new System.Drawing.Size(1178, 666);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ClientWatch clientWatch2;
        private ClientWatch clientWatch3;
        private ClientWatch clientWatch1;
    }
}
