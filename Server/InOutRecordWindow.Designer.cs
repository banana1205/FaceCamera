namespace Server
{
    partial class InOutRecordWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label_h = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox_IDCard = new System.Windows.Forms.TextBox();
            this.label_IDCard = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label_name = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InOutTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InOutTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompareGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThroughWayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SceneImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pager1 = new Server.Pager();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_search);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.label_h);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.textBox_IDCard);
            this.panel1.Controls.Add(this.label_IDCard);
            this.panel1.Controls.Add(this.textBox_name);
            this.panel1.Controls.Add(this.label_name);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 66);
            this.panel1.TabIndex = 0;
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(840, 13);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(60, 30);
            this.button_search.TabIndex = 9;
            this.button_search.Text = "查询";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(697, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "进/出：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(745, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(80, 20);
            this.comboBox1.TabIndex = 7;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(535, 21);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(150, 21);
            this.dateTimePicker2.TabIndex = 6;
            // 
            // label_h
            // 
            this.label_h.AutoSize = true;
            this.label_h.Location = new System.Drawing.Point(520, 26);
            this.label_h.Name = "label_h";
            this.label_h.Size = new System.Drawing.Size(11, 12);
            this.label_h.TabIndex = 5;
            this.label_h.Text = "-";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(365, 21);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(150, 21);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // textBox_IDCard
            // 
            this.textBox_IDCard.Location = new System.Drawing.Point(194, 21);
            this.textBox_IDCard.Name = "textBox_IDCard";
            this.textBox_IDCard.Size = new System.Drawing.Size(150, 21);
            this.textBox_IDCard.TabIndex = 3;
            // 
            // label_IDCard
            // 
            this.label_IDCard.AutoSize = true;
            this.label_IDCard.Location = new System.Drawing.Point(134, 30);
            this.label_IDCard.Name = "label_IDCard";
            this.label_IDCard.Size = new System.Drawing.Size(65, 12);
            this.label_IDCard.TabIndex = 2;
            this.label_IDCard.Text = "身份证号：";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(39, 21);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(80, 21);
            this.textBox_name.TabIndex = 1;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(3, 31);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(41, 12);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "姓名：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowNumber,
            this.CNName,
            this.InOutTypeName,
            this.InOutTime,
            this.CompareGrade,
            this.ThroughWayName,
            this.IDCard,
            this.SceneImage});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 100;
            this.dataGridView1.Size = new System.Drawing.Size(984, 558);
            this.dataGridView1.TabIndex = 1;
            // 
            // RowNumber
            // 
            this.RowNumber.DataPropertyName = "RowNumber";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.RowNumber.DefaultCellStyle = dataGridViewCellStyle1;
            this.RowNumber.HeaderText = "序号";
            this.RowNumber.Name = "RowNumber";
            this.RowNumber.ReadOnly = true;
            // 
            // CNName
            // 
            this.CNName.DataPropertyName = "Name";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CNName.DefaultCellStyle = dataGridViewCellStyle2;
            this.CNName.HeaderText = "姓名";
            this.CNName.Name = "CNName";
            this.CNName.ReadOnly = true;
            // 
            // InOutTypeName
            // 
            this.InOutTypeName.DataPropertyName = "InOutTypeName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.InOutTypeName.DefaultCellStyle = dataGridViewCellStyle3;
            this.InOutTypeName.HeaderText = "进/出";
            this.InOutTypeName.Name = "InOutTypeName";
            this.InOutTypeName.ReadOnly = true;
            // 
            // InOutTime
            // 
            this.InOutTime.DataPropertyName = "InOutTime";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.InOutTime.DefaultCellStyle = dataGridViewCellStyle4;
            this.InOutTime.HeaderText = "进出时间";
            this.InOutTime.Name = "InOutTime";
            this.InOutTime.ReadOnly = true;
            this.InOutTime.Width = 120;
            // 
            // CompareGrade
            // 
            this.CompareGrade.DataPropertyName = "CompareGrade";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CompareGrade.DefaultCellStyle = dataGridViewCellStyle5;
            this.CompareGrade.HeaderText = "比对结果";
            this.CompareGrade.Name = "CompareGrade";
            this.CompareGrade.ReadOnly = true;
            // 
            // ThroughWayName
            // 
            this.ThroughWayName.DataPropertyName = "ThroughWayName";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ThroughWayName.DefaultCellStyle = dataGridViewCellStyle6;
            this.ThroughWayName.HeaderText = "通过方式";
            this.ThroughWayName.Name = "ThroughWayName";
            this.ThroughWayName.ReadOnly = true;
            // 
            // IDCard
            // 
            this.IDCard.DataPropertyName = "IDCard";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IDCard.DefaultCellStyle = dataGridViewCellStyle7;
            this.IDCard.HeaderText = "身份证号";
            this.IDCard.Name = "IDCard";
            this.IDCard.ReadOnly = true;
            this.IDCard.Visible = false;
            // 
            // SceneImage
            // 
            this.SceneImage.DataPropertyName = "SceneImage";
            this.SceneImage.HeaderText = "现场照";
            this.SceneImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.SceneImage.Name = "SceneImage";
            this.SceneImage.ReadOnly = true;
            this.SceneImage.Width = 200;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 66);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pager1);
            this.splitContainer1.Size = new System.Drawing.Size(984, 595);
            this.splitContainer1.SplitterDistance = 558;
            this.splitContainer1.TabIndex = 3;
            // 
            // pager1
            // 
            this.pager1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pager1.Location = new System.Drawing.Point(511, 0);
            this.pager1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.pager1.Name = "pager1";
            this.pager1.PageIndex = 0;
            this.pager1.PageSize = 0;
            this.pager1.RecordCount = 0;
            this.pager1.Size = new System.Drawing.Size(473, 33);
            this.pager1.TabIndex = 2;
            this.pager1.OnPageChanged += new System.EventHandler(this.pager1_OnPageChanged);
            // 
            // InOutRecordWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "InOutRecordWindow";
            this.Text = "进出记录";
            this.Load += new System.EventHandler(this.InOutRecordWindow_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label_IDCard;
        private System.Windows.Forms.TextBox textBox_IDCard;
        private System.Windows.Forms.Label label_h;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Pager pager1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InOutTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InOutTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompareGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThroughWayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCard;
        private System.Windows.Forms.DataGridViewImageColumn SceneImage;
    }
}