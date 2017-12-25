namespace Server
{
    partial class WatchPanel4
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
            this.clientWatch4 = new Server.ClientWatch();
            this.clientWatch3 = new Server.ClientWatch();
            this.clientWatch2 = new Server.ClientWatch();
            this.clientWatch1 = new Server.ClientWatch();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.clientWatch4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.clientWatch3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.clientWatch2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.clientWatch1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1092, 765);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // clientWatch4
            // 
            this.clientWatch4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientWatch4.Location = new System.Drawing.Point(549, 385);
            this.clientWatch4.Name = "clientWatch4";
            this.clientWatch4.Size = new System.Drawing.Size(540, 377);
            this.clientWatch4.TabIndex = 7;
            // 
            // clientWatch3
            // 
            this.clientWatch3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientWatch3.Location = new System.Drawing.Point(3, 385);
            this.clientWatch3.Name = "clientWatch3";
            this.clientWatch3.Size = new System.Drawing.Size(540, 377);
            this.clientWatch3.TabIndex = 6;
            // 
            // clientWatch2
            // 
            this.clientWatch2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientWatch2.Location = new System.Drawing.Point(549, 3);
            this.clientWatch2.Name = "clientWatch2";
            this.clientWatch2.Size = new System.Drawing.Size(540, 376);
            this.clientWatch2.TabIndex = 5;
            // 
            // clientWatch1
            // 
            this.clientWatch1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientWatch1.Location = new System.Drawing.Point(3, 3);
            this.clientWatch1.Name = "clientWatch1";
            this.clientWatch1.Size = new System.Drawing.Size(540, 376);
            this.clientWatch1.TabIndex = 8;
            // 
            // WatchPanel4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "WatchPanel4";
            this.Size = new System.Drawing.Size(1092, 765);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ClientWatch clientWatch4;
        private ClientWatch clientWatch3;
        private ClientWatch clientWatch2;
        private ClientWatch clientWatch1;
    }
}
