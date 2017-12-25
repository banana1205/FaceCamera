namespace Server
{
    partial class WhiteListWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label_Name = new System.Windows.Forms.Label();
            this.button_search = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.label_IDCard = new System.Windows.Forms.Label();
            this.textBox_IDCard = new System.Windows.Forms.TextBox();
            this.panel_search = new System.Windows.Forms.Panel();
            this.panel_1_btn = new System.Windows.Forms.Panel();
            this.button_outBlack = new System.Windows.Forms.Button();
            this.button_joinBlack = new System.Windows.Forms.Button();
            this.button_joinWhite = new System.Windows.Forms.Button();
            this.button_outWhite = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pager1 = new Server.Pager();
            this.CheckRow = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FaceImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel_search.SuspendLayout();
            this.panel_1_btn.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 50;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckRow,
            this.RowNumber,
            this.CNName,
            this.IDCard,
            this.Gender,
            this.Nation,
            this.BirthDate,
            this.FaceImage,
            this.Address});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 125;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(984, 605);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(70, 24);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(100, 21);
            this.textBox_Name.TabIndex = 1;
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(23, 27);
            this.label_Name.Name = "label_Name";
            this.label_Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_Name.Size = new System.Drawing.Size(41, 12);
            this.label_Name.TabIndex = 2;
            this.label_Name.Text = "姓名：";
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(393, 14);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 30);
            this.button_search.TabIndex = 4;
            this.button_search.Text = "查询";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // button_delete
            // 
            this.button_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_delete.Location = new System.Drawing.Point(254, 2);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 28);
            this.button_delete.TabIndex = 5;
            this.button_delete.Text = "删除";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // label_IDCard
            // 
            this.label_IDCard.AutoSize = true;
            this.label_IDCard.Location = new System.Drawing.Point(176, 26);
            this.label_IDCard.Name = "label_IDCard";
            this.label_IDCard.Size = new System.Drawing.Size(65, 12);
            this.label_IDCard.TabIndex = 6;
            this.label_IDCard.Text = "身份证号：";
            // 
            // textBox_IDCard
            // 
            this.textBox_IDCard.Location = new System.Drawing.Point(247, 23);
            this.textBox_IDCard.Name = "textBox_IDCard";
            this.textBox_IDCard.Size = new System.Drawing.Size(140, 21);
            this.textBox_IDCard.TabIndex = 7;
            // 
            // panel_search
            // 
            this.panel_search.Controls.Add(this.panel_1_btn);
            this.panel_search.Controls.Add(this.button_search);
            this.panel_search.Controls.Add(this.textBox_Name);
            this.panel_search.Controls.Add(this.label_Name);
            this.panel_search.Controls.Add(this.textBox_IDCard);
            this.panel_search.Controls.Add(this.label_IDCard);
            this.panel_search.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_search.Location = new System.Drawing.Point(0, 0);
            this.panel_search.Name = "panel_search";
            this.panel_search.Size = new System.Drawing.Size(984, 56);
            this.panel_search.TabIndex = 10;
            // 
            // panel_1_btn
            // 
            this.panel_1_btn.Controls.Add(this.button_outBlack);
            this.panel_1_btn.Controls.Add(this.button_joinBlack);
            this.panel_1_btn.Controls.Add(this.button_delete);
            this.panel_1_btn.Controls.Add(this.button_joinWhite);
            this.panel_1_btn.Controls.Add(this.button_outWhite);
            this.panel_1_btn.Controls.Add(this.button_add);
            this.panel_1_btn.Location = new System.Drawing.Point(490, 10);
            this.panel_1_btn.Name = "panel_1_btn";
            this.panel_1_btn.Size = new System.Drawing.Size(494, 35);
            this.panel_1_btn.TabIndex = 12;
            // 
            // button_outBlack
            // 
            this.button_outBlack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_outBlack.Location = new System.Drawing.Point(11, 2);
            this.button_outBlack.Name = "button_outBlack";
            this.button_outBlack.Size = new System.Drawing.Size(75, 30);
            this.button_outBlack.TabIndex = 0;
            this.button_outBlack.Text = "移出黑名单";
            this.button_outBlack.UseVisualStyleBackColor = true;
            this.button_outBlack.Click += new System.EventHandler(this.button_outBlack_Click);
            // 
            // button_joinBlack
            // 
            this.button_joinBlack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_joinBlack.Location = new System.Drawing.Point(416, 2);
            this.button_joinBlack.Name = "button_joinBlack";
            this.button_joinBlack.Size = new System.Drawing.Size(75, 28);
            this.button_joinBlack.TabIndex = 11;
            this.button_joinBlack.Text = "加入黑名单";
            this.button_joinBlack.UseVisualStyleBackColor = true;
            this.button_joinBlack.Click += new System.EventHandler(this.button_joinBlack_Click);
            // 
            // button_joinWhite
            // 
            this.button_joinWhite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_joinWhite.Location = new System.Drawing.Point(92, 1);
            this.button_joinWhite.Name = "button_joinWhite";
            this.button_joinWhite.Size = new System.Drawing.Size(75, 30);
            this.button_joinWhite.TabIndex = 0;
            this.button_joinWhite.Text = "加入白名单";
            this.button_joinWhite.UseVisualStyleBackColor = true;
            this.button_joinWhite.Click += new System.EventHandler(this.button_joinWhite_Click);
            // 
            // button_outWhite
            // 
            this.button_outWhite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_outWhite.Location = new System.Drawing.Point(335, 2);
            this.button_outWhite.Name = "button_outWhite";
            this.button_outWhite.Size = new System.Drawing.Size(75, 28);
            this.button_outWhite.TabIndex = 10;
            this.button_outWhite.Text = "移出白名单";
            this.button_outWhite.UseVisualStyleBackColor = true;
            this.button_outWhite.Click += new System.EventHandler(this.button_outWhite_Click);
            // 
            // button_add
            // 
            this.button_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_add.Location = new System.Drawing.Point(173, 2);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 28);
            this.button_add.TabIndex = 9;
            this.button_add.Text = "新增";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 605);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pager1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 632);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(984, 29);
            this.panel2.TabIndex = 12;
            // 
            // pager1
            // 
            this.pager1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pager1.Location = new System.Drawing.Point(559, 0);
            this.pager1.Name = "pager1";
            this.pager1.PageIndex = 0;
            this.pager1.PageSize = 0;
            this.pager1.RecordCount = 0;
            this.pager1.Size = new System.Drawing.Size(425, 29);
            this.pager1.TabIndex = 8;
            this.pager1.OnPageChanged += new System.EventHandler(this.pager1_OnPageChanged);
            // 
            // CheckRow
            // 
            this.CheckRow.HeaderText = "";
            this.CheckRow.Name = "CheckRow";
            this.CheckRow.Width = 50;
            // 
            // RowNumber
            // 
            this.RowNumber.DataPropertyName = "RowNumber";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.RowNumber.DefaultCellStyle = dataGridViewCellStyle2;
            this.RowNumber.HeaderText = "序号";
            this.RowNumber.Name = "RowNumber";
            this.RowNumber.ReadOnly = true;
            this.RowNumber.Width = 60;
            // 
            // CNName
            // 
            this.CNName.DataPropertyName = "Name";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CNName.DefaultCellStyle = dataGridViewCellStyle3;
            this.CNName.HeaderText = "姓名";
            this.CNName.Name = "CNName";
            this.CNName.ReadOnly = true;
            this.CNName.Width = 90;
            // 
            // IDCard
            // 
            this.IDCard.DataPropertyName = "IDCard";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IDCard.DefaultCellStyle = dataGridViewCellStyle4;
            this.IDCard.HeaderText = "身份证号";
            this.IDCard.Name = "IDCard";
            this.IDCard.ReadOnly = true;
            this.IDCard.Width = 160;
            // 
            // Gender
            // 
            this.Gender.DataPropertyName = "Gender";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Gender.DefaultCellStyle = dataGridViewCellStyle5;
            this.Gender.HeaderText = "性别";
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            this.Gender.Width = 60;
            // 
            // Nation
            // 
            this.Nation.DataPropertyName = "Nation";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Nation.DefaultCellStyle = dataGridViewCellStyle6;
            this.Nation.HeaderText = "民族";
            this.Nation.Name = "Nation";
            this.Nation.ReadOnly = true;
            this.Nation.Width = 60;
            // 
            // BirthDate
            // 
            this.BirthDate.DataPropertyName = "BirthDate";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.BirthDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.BirthDate.HeaderText = "出生日期";
            this.BirthDate.Name = "BirthDate";
            this.BirthDate.ReadOnly = true;
            this.BirthDate.Width = 110;
            // 
            // FaceImage
            // 
            this.FaceImage.DataPropertyName = "FaceImage";
            this.FaceImage.HeaderText = "证件照";
            this.FaceImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.FaceImage.Name = "FaceImage";
            this.FaceImage.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "地址";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 270;
            // 
            // WhiteListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_search);
            this.Name = "WhiteListWindow";
            this.Text = "白名单";
            this.Load += new System.EventHandler(this.WhiteListWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel_search.ResumeLayout(false);
            this.panel_search.PerformLayout();
            this.panel_1_btn.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Label label_IDCard;
        private System.Windows.Forms.TextBox textBox_IDCard;
        private Pager pager1;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Panel panel_search;
        private System.Windows.Forms.Button button_outWhite;
        private System.Windows.Forms.Button button_joinBlack;
        private System.Windows.Forms.Panel panel_1_btn;
        private System.Windows.Forms.Button button_joinWhite;
        private System.Windows.Forms.Button button_outBlack;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nation;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthDate;
        private System.Windows.Forms.DataGridViewImageColumn FaceImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
    }
}