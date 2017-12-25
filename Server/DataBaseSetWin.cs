using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Server
{
    public partial class DataBaseSetWin : Form
    {
        public DataBaseSetWin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 测试连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_testConnection_Click(object sender, EventArgs e)
        {
            string server = tb_Server.Text;
            if (string.IsNullOrEmpty(server))
            {
                MessageBox.Show("数据库连接成功");
            }
            string database = tb_DataBase.Text;
            string uid = tb_uid.Text;
            string pwd = tb_pwd.Text;
            string ConnectionString = string.Format(@"server={0};database={1};uid={2};pwd={3}", server, database, uid, pwd);
            //创建连接对象
            SqlConnection mySqlConnection = new SqlConnection(ConnectionString);
            try
            {
                mySqlConnection.Open();
                MessageBox.Show("数据库连接成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //关闭数据库连接
                mySqlConnection.Close();
            }
        }

        private void DataBaseSetWin_Load(object sender, EventArgs e)
        {
            tb_Server.Text = ServerConfig.DataServer;
            tb_DataBase.Text = ServerConfig.DataBase;
            tb_uid.Text = ServerConfig.DataUser;
            tb_pwd.Text = ServerConfig.DataPwd;
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 应用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_use_Click(object sender, EventArgs e)
        {
            MessageBox.Show("。。。");
        }
    }
}
