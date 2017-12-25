using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;

namespace Server
{
    public partial class InOutRecordWindow : Form
    {
        private ServerDAL dal = new ServerDAL();
        Color selectedColor = Color.FromArgb(200, 200, 200);
        public string WL_IDCard = string.Empty;//白名单传来的身份证号
        public string WL_Name = string.Empty;//白名单传来的姓名
        public InOutRecordWindow()
        {
            InitializeComponent();
        }

        private class ComboxData
        {
            public string text { get; set; }
            public string value { get; set; }
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InOutRecordWindow_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(WL_IDCard))
            {

                this.textBox_IDCard.ReadOnly = true;
                this.textBox_IDCard.Text = WL_IDCard;
                this.textBox_name.ReadOnly = true;
                this.textBox_name.Text = WL_Name;
            }

            List<ComboxData> cbDL = new List<ComboxData>();
            cbDL.Add(new ComboxData() { text = "全部", value = "" });
            cbDL.Add(new ComboxData() { text = "进", value = "InOutType_00" });
            cbDL.Add(new ComboxData() { text = "出", value = "InOutType_01" });
            this.comboBox1.DisplayMember = "text";
            this.comboBox1.ValueMember = "value";
            this.comboBox1.DataSource = cbDL;
            this.comboBox1.SelectedIndex = 0;

            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker2.Format = DateTimePickerFormat.Custom;

            dataGridView1.AutoGenerateColumns = false;//false后不会自动成列，只显示自定义绑定列
            dataGridView1.AllowUserToAddRows = false;//最后的空白行
            dataGridView1.RowHeadersVisible = false;//空白列
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//选中全行
            dataGridView1.MultiSelect = false;//禁止多选
            dataGridView1.DefaultCellStyle.SelectionBackColor = selectedColor;//选中行背景颜色
            dataGridView1.AllowUserToResizeRows = false;//禁止用户拖动行高

            
            //改变标题的高度;  
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView1.ColumnHeadersHeight = 50;
            //设置标题内容居中显示;  
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            LoadDataGridViewData();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_search_Click(object sender, EventArgs e)
        {
            LoadDataGridViewData();
        }

        /// <summary>
        /// 数据加载（附带页面条件）
        /// </summary>
        public void LoadDataGridViewData()
        {
            int pageIndex = this.pager1.PageIndex;//当前页
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            int pageSize = 100;//一页条数

            int pageCount = 0;//总页数
            int recordCount = 0;//总条数

            SearchValueInfo sInfo = new SearchValueInfo();
            sInfo.name = textBox_name.Text.Trim();//姓名
            sInfo.IDCard = textBox_IDCard.Text.Trim();//身份证
            sInfo.beginDate = dateTimePicker1.Value;//开始时间
            sInfo.endDate = dateTimePicker2.Value;//结束时间
            sInfo.inOutType = this.comboBox1.SelectedValue.PaseToString();//进/出
            DataSet ds = dal.GetInOutRecod(pageIndex, pageSize, sInfo);

            ds.Tables[0].Columns.Add("CompareGrade", Type.GetType("System.String"));
            DataTable CodeDt = dal.GetCode("CompareGrade");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                foreach (DataRow cdr in CodeDt.Rows)
                {
                    if (dr["CompareResult"].PaseToDecmial() * 100 >= cdr["CodeID"].PaseToDecmial())
                    {
                        dr["CompareGrade"] = cdr["CName"].PaseToString();
                        break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(ds.Tables[1].PaseToString()) && !string.IsNullOrEmpty(ds.Tables[1].Rows[0][0].ToString()))
            {
                recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                pageCount = recordCount / pageSize;
            }

            pager1.PageSize = pageSize;
            pager1.RecordCount = recordCount;
            pager1.Page();
            dataGridView1.DataSource = ds.Tables[0];
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.SelectedRows[0].Selected = false;
            }
        }

        /// <summary>
        /// 切换分页 触发 重新加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pager1_OnPageChanged(object sender, EventArgs e)
        {
            LoadDataGridViewData();
        }

    }
}
