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
    public delegate void LoadDGVDataDelegeta();
    public partial class RegisterWhiteList_Win : Form
    {
        public LoadDGVDataDelegeta LoadDGVData;
        public RegisterWhiteList_Win()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterWhiteList_Load(object sender, EventArgs e)
        {
            Create_WhiteList_Dt();
            this.timer1.Start();
        }

        private ZKSIdReadBLL ZKSIdRead = new ZKSIdReadBLL();//身份证读卡
        private ServerBLL bll = new ServerBLL();
        private List<PersonnelInfo> PInfoList = new List<PersonnelInfo>();

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Save_Click(object sender, EventArgs e)
        {
            ServerDAL dal = new ServerDAL();
            int count = 0;
            for (int i = 0; i < PInfoList.Count; i++)
            {
                count += dal.RegisterPersonnelInfo(PInfoList[i]);
            }
            if (count > 0)
            {
                MessageBox.Show(string.Format("成功保存{0}条", count));
                if (LoadDGVData != null)
                {
                    LoadDGVData();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }
        private DataTable wlDt = new DataTable();
        private void timer1_Tick(object sender, EventArgs e)
        {
            //bll.RegisterWhiteList();

            PersonnelInfo PInfo = new PersonnelInfo();
            if (ZKSIdRead.ReadCard(ref PInfo))
            {
                PInfo.PersonType = "PersonType_00";//0 访客 | 1 白名单 | 2 黑名单
                PInfoList.Add(PInfo);
                DataRow dr = wlDt.NewRow();
                dr["Name"] = PInfo.Name;
                dr["IDCard"] = PInfo.IDCard;
                dr["FaceImage"] = PInfo.FaceImage;
                dr["Address"] = PInfo.Address;
                dr["Gender"] = PInfo.Gender;
                dr["Nation"] = PInfo.Nation;
                dr["BirthDate"] = PInfo.BirthDate;
                wlDt.Rows.Add(dr);
                dataGridView_List.DataSource = wlDt;
                this.label_count.Text = string.Format("共{0}条", PInfoList.Count);
            }
        }

        private void Create_WhiteList_Dt()
        {
            wlDt = new DataTable();
            DataColumn Name = new DataColumn("Name", Type.GetType("System.String"));
            DataColumn IDCard = new DataColumn("IDCard", Type.GetType("System.String"));
            DataColumn FaceImage = new DataColumn("FaceImage", Type.GetType("System.Byte[]"));
            DataColumn Address = new DataColumn("Address", Type.GetType("System.String"));
            DataColumn Gender = new DataColumn("Gender", Type.GetType("System.String"));
            DataColumn Nation = new DataColumn("Nation", Type.GetType("System.String"));
            DataColumn BirthDate = new DataColumn("BirthDate", Type.GetType("System.DateTime"));
            wlDt.Columns.Add(Name);
            wlDt.Columns.Add(IDCard);
            wlDt.Columns.Add(FaceImage);
            wlDt.Columns.Add(Address);
            wlDt.Columns.Add(Gender);
            wlDt.Columns.Add(Nation);
            wlDt.Columns.Add(BirthDate);

        }

        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterWhiteList_Win_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

    }
}
