namespace Server
{
    partial class Pager
    {
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 组件设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent() {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_First = new System.Windows.Forms.ToolStripButton();
            this.btn_Previous = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txt_CurrentIndex = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lbl_PageCount = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Next = new System.Windows.Forms.ToolStripButton();
            this.btn_Last = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lbl_RecordCount = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_First,
            this.btn_Previous,
            this.toolStripSeparator1,
            this.txt_CurrentIndex,
            this.toolStripLabel1,
            this.lbl_PageCount,
            this.toolStripSeparator3,
            this.btn_Next,
            this.btn_Last,
            this.toolStripSeparator2,
            this.lbl_RecordCount});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(425, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // btn_First
            // 
            this.btn_First.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_First.Image = global::Server.Properties.Resources.MoveFirst;
            this.btn_First.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_First.Name = "btn_First";
            this.btn_First.Size = new System.Drawing.Size(23, 22);
            this.btn_First.Tag = "First";
            // 
            // btn_Previous
            // 
            this.btn_Previous.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Previous.Image = global::Server.Properties.Resources.MovePrevious;
            this.btn_Previous.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Previous.Name = "btn_Previous";
            this.btn_Previous.Size = new System.Drawing.Size(23, 22);
            this.btn_Previous.Tag = "Previous";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // txt_CurrentIndex
            // 
            this.txt_CurrentIndex.Name = "txt_CurrentIndex";
            this.txt_CurrentIndex.Size = new System.Drawing.Size(50, 25);
            this.txt_CurrentIndex.Text = "1";
            this.txt_CurrentIndex.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_CurrentIndex_KeyUp);
            this.txt_CurrentIndex.TextChanged += new System.EventHandler(this.txt_CurrentIndex_TextChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(13, 22);
            this.toolStripLabel1.Text = "/";
            // 
            // lbl_PageCount
            // 
            this.lbl_PageCount.Name = "lbl_PageCount";
            this.lbl_PageCount.Size = new System.Drawing.Size(72, 22);
            this.lbl_PageCount.Text = "pageCount";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_Next
            // 
            this.btn_Next.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Next.Image = global::Server.Properties.Resources.MoveNext;
            this.btn_Next.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(23, 22);
            this.btn_Next.Tag = "Next";
            // 
            // btn_Last
            // 
            this.btn_Last.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Last.Image = global::Server.Properties.Resources.MoveLast;
            this.btn_Last.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Last.Name = "btn_Last";
            this.btn_Last.Size = new System.Drawing.Size(23, 22);
            this.btn_Last.Tag = "Last";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // lbl_RecordCount
            // 
            this.lbl_RecordCount.Name = "lbl_RecordCount";
            this.lbl_RecordCount.Size = new System.Drawing.Size(105, 22);
            this.lbl_RecordCount.Text = "共recordCount条";
            // 
            // Pager
            // 
            this.Controls.Add(this.toolStrip1);
            this.Name = "Pager";
            this.Size = new System.Drawing.Size(425, 26);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btn_First;
		private System.Windows.Forms.ToolStripButton btn_Previous;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripTextBox txt_CurrentIndex;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripLabel lbl_PageCount;
		private System.Windows.Forms.ToolStripButton btn_Next;
		private System.Windows.Forms.ToolStripButton btn_Last;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripLabel lbl_RecordCount;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;



	}
}
