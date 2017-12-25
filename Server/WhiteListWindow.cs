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
    public partial class WhiteListWindow : Form
    {
        private ServerDAL dal = new ServerDAL();
        public WhiteListWindow()
        {
            InitializeComponent();
        }
        public string PersonType = "PersonType_00";//0 访客 | 1 白名单 | 2 黑名单
        Color selectedColor = Color.FromArgb(200, 200, 200);

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WhiteListWindow_Load(object sender, EventArgs e)
        {
            switch (PersonType)
            {
                case "PersonType_00":
                    this.Text = "访客管理";
                    this.button_add.Visible = false;
                    this.button_outBlack.Visible = false;
                    this.button_outWhite.Visible = false;
                    this.button_delete.Location = new Point(254, 2);
                    this.button_joinWhite.Location = new Point(335, 2);
                    this.button_joinBlack.Location = new Point(416, 2);
                    break;
                case "PersonType_01":
                    this.Text = "白名单管理";
                    this.button_joinWhite.Visible = false;//加入白名单
                    this.button_outBlack.Visible = false;//移出黑名单
                    this.button_outWhite.Location = new Point(335, 2);//移出白名单
                    this.button_add.Location = new Point(173, 2);//新增
                    this.button_delete.Location = new Point(254, 2);//删除
                    this.button_joinBlack.Location = new Point(416, 2);//加入黑名单
                    break;
                case "PersonType_02":
                    this.Text = "黑名单管理";
                    this.button_joinWhite.Visible = false;//加入白名单
                    this.button_outWhite.Visible = false;//移出白名单
                    this.button_add.Visible = false;//新增
                    this.button_joinBlack.Visible = false;//加入黑名单
                    this.button_delete.Location = new Point(335, 2);//删除
                    this.button_outBlack.Location = new Point(416, 2);//移出黑名单
                    break;
            }

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
        /// 单元格选中，触发行选中 (可多选)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //判断当前复选框所在选中列的状态
            if (e.RowIndex == dataGridView1.CurrentCell.RowIndex)//当前行的索引是否是是当前选择的行的索引
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["CheckRow"].Value.PaseToBoolean())
                {
                    dataGridView1.Rows[e.RowIndex].Cells["CheckRow"].Value = false;
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells["CheckRow"].Value = true;
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = selectedColor;
                }
            }
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_search_Click(object sender, EventArgs e)
        {
            this.pager1.PageIndex = 1;
            LoadDataGridViewData();
        }

        /// <summary>
        /// 数据加载
        /// </summary>
        public void LoadDataGridViewData()
        {
            int pageIndex = this.pager1.PageIndex;//当前页
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            int pageSize = 50;//一页条数

            int pageCount = 0;//总页数
            int recordCount = 0;//总条数

            string Name = this.textBox_Name.Text;
            string IDCard = this.textBox_IDCard.Text;
            //List<string> searchValue = new List<string>();
            //searchValue.Add(Name);
            //searchValue.Add(IDCard);
            SearchValueInfo sInfo = new SearchValueInfo();
            sInfo.name = Name;
            sInfo.IDCard = IDCard;
            DataSet ds = dal.GetWhiteList(PersonType, pageIndex, pageSize, sInfo);
            if (!string.IsNullOrEmpty(ds.Tables[1].Rows[0][0].ToString()))
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

        /// <summary>
        /// 遍历选中的行，返回 身份证号 例：xxxx|xxxx|xxx
        /// </summary>
        /// <returns></returns>
        private string GetChecked_IDCard()
        {
            string checkedStr = string.Empty;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                PersonnelInfo pi = new PersonnelInfo();
                if (dataGridView1.Rows[i].Cells["CheckRow"].Value.PaseToBoolean())
                {
                    pi.IDCard = dataGridView1.Rows[i].Cells["IDCard"].Value.ToString();
                    checkedStr += "|" + pi.IDCard;
                }
            }
            if (!string.IsNullOrEmpty(checkedStr))
            {
                checkedStr = checkedStr.Substring(1);
            }
            return checkedStr;
        }

        #region ==btn==
        /// <summary>
        /// 新增白名单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_add_Click(object sender, EventArgs e)
        {
            ZKSIdReadBLL ZKSIdRead = new ZKSIdReadBLL();//身份证读卡
            int mport = ZKSIdRead.Start(true, false);//身份证读卡器
            if (mport > 0)
            {
                RegisterWhiteList_Win form = new RegisterWhiteList_Win();
                form.LoadDGVData += new LoadDGVDataDelegeta(LoadDataGridViewData);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("身份证读卡器未连接");
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_delete_Click(object sender, EventArgs e)
        {
            string checkedStr = GetChecked_IDCard();
            if (!string.IsNullOrEmpty(checkedStr))
            {
                if (MessageBox.Show("勾选的数据将被删除，是否继续？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int count = dal.DeletePersonnel(checkedStr);
                    if (count > 0)
                    {
                        MessageBox.Show("数据删除成功！");
                        LoadDataGridViewData();
                    }
                }
            }
            else
            {
                MessageBox.Show("请您至少选择一条数据！");
            }
        }

        /// <summary>
        /// 加入黑名单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_joinBlack_Click(object sender, EventArgs e)
        {
            string checkedStr = GetChecked_IDCard();
            if (!string.IsNullOrEmpty(checkedStr))
            {
                if (MessageBox.Show("勾选的数据将被加入黑名单，是否继续？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int count = dal.UpdataPersonType("PersonType_02", checkedStr);
                    if (count > 0)
                    {
                        MessageBox.Show("加入黑名单成功！");
                        LoadDataGridViewData();
                    }
                }
            }
            else
            {
                MessageBox.Show("请您至少选择一条数据！");
            }
        }

        /// <summary>
        /// 移出白名单 =》 成为访客
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_outWhite_Click(object sender, EventArgs e)
        {
            string checkedStr = GetChecked_IDCard();
            if (!string.IsNullOrEmpty(checkedStr))
            {
                if (MessageBox.Show("勾选的数据将被移出白名单，是否继续？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int count = dal.UpdataPersonType("PersonType_00", checkedStr);
                    if (count > 0)
                    {
                        MessageBox.Show("移出白名单成功！");
                        LoadDataGridViewData();
                    }
                }
            }
            else
            {
                MessageBox.Show("请您至少选择一条数据！");
            }
        }

        /// <summary>
        /// 加入白名单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_joinWhite_Click(object sender, EventArgs e)
        {
            string checkedStr = GetChecked_IDCard();
            if (!string.IsNullOrEmpty(checkedStr))
            {
                if (MessageBox.Show("勾选的数据将加入白名单，是否继续？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int count = dal.UpdataPersonType("PersonType_01", checkedStr);
                    if (count > 0)
                    {
                        MessageBox.Show("加入白名单成功！");
                        LoadDataGridViewData();
                    }
                }
            }
            else
            {
                MessageBox.Show("请您至少选择一条数据！");
            }
        }

        /// <summary>
        /// 移出黑名单 =》 成为访客
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_outBlack_Click(object sender, EventArgs e)
        {
            string checkedStr = GetChecked_IDCard();
            if (!string.IsNullOrEmpty(checkedStr))
            {
                if (MessageBox.Show("勾选的数据将被移出黑名单，是否继续？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int count = dal.UpdataPersonType("PersonType_00", checkedStr);
                    if (count > 0)
                    {
                        MessageBox.Show("移出黑名单成功！");
                        LoadDataGridViewData();
                    }
                }
            }
            else
            {
                MessageBox.Show("请您至少选择一条数据！");
            }
        }

        #endregion

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dataGridView1.CurrentCell.RowIndex)//当前行的索引是否是是当前选择的行的索引
            {
                string IDCard = dataGridView1.Rows[e.RowIndex].Cells["IDCard"].Value.PaseToString();
                string Name = dataGridView1.Rows[e.RowIndex].Cells["CNName"].Value.PaseToString();
                InOutRecordWindow IORWin = new InOutRecordWindow();
                IORWin.WL_IDCard = IDCard;
                IORWin.WL_Name = Name;
                IORWin.ShowDialog();
            }
        }






    }
}
