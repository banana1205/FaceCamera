using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Server
{
    public delegate void SendAdvertisementD(List<ADItem> ADItem);
    public partial class ADManageWin : Form
    {
        public SendAdvertisementD SendAdvertisement;
        private ServerDAL dal = new ServerDAL();
        public ADManageWin()
        {
            InitializeComponent();
        }
        private string path = System.Environment.CurrentDirectory + @"\Resources\ADImage\";

        private void ADManageWin_Load(object sender, EventArgs e)
        {
            DataTable Ldt = dal.GetADList(0);
            foreach (DataRow dr in Ldt.Rows)
            {
                System.IO.FileInfo file = new System.IO.FileInfo(path + dr["FileName_New"]);
                if (file.Exists)//文件是否存在，存在则执行删除  
                {
                    ADItem aditem = new ADItem();
                    aditem.filePath = path + dr["FileName_New"];
                    aditem.fileName_New = dr["FileName_New"].ToString();
                    aditem.isChecked = false;
                    this.flowLayoutPanel1.Controls.Add(aditem);
                }
            }
            DataTable Rdt = dal.GetADList(1);
            foreach (DataRow dr in Rdt.Rows)
            {
                System.IO.FileInfo file = new System.IO.FileInfo(path + dr["FileName_New"]);
                if (file.Exists)//文件是否存在，存在则执行删除  
                {
                    ADItem aditem = new ADItem();
                    aditem.filePath = path + dr["FileName_New"];
                    aditem.fileName_New = dr["FileName_New"].ToString();
                    aditem.isChecked = false;
                    this.flowLayoutPanel2.Controls.Add(aditem);
                }
            }


        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //为对话框设置标题
            ofd.Title = "请选择上传的图片";
            //设置筛选的图片格式
            ofd.Filter = "图片格式|*.jpg;*.png";
            //设置是否允许多选
            ofd.Multiselect = true;
            //如果你点了“确定”按钮
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                for (int fi = 0; fi < ofd.FileNames.Length; fi++)
                {
                    //Image imge = Image.FromFile(ofd.FileNames[fi].ToString());
                    string filePath = ofd.FileNames[fi].ToString();
                    //找到文件名比如“1.jpg”前面的那个“\”的位置
                    int position = filePath.LastIndexOf("\\");
                    //从完整路径中截取出来文件名“1.jpg”
                    string fileName = filePath.Substring(position + 1);
                    position = fileName.LastIndexOf(".");
                    string suffix = fileName.Substring(position);//后缀
                    //读取选择的文件，返回一个流
                    //using (Stream stream = ofd.OpenFile())
                    using (Stream stream = new FileStream(filePath, FileMode.Open))
                    {
                        //创建一个流，用来写入得到的文件流（注意：创建一个名为“Images”的文件夹，如果是用相对路径，必须在这个程序的Degug目录下创建
                        //如果是绝对路径，放在那里都行，我用的是相对路径）
                        string fileName_New = DateTime.Now.ToString("yyyyMMdd HHmmss") + "-" + fi + suffix;
                        using (FileStream fs = new FileStream(path + fileName_New, FileMode.CreateNew))
                        {
                            //将得到的文件流复制到写入流中
                            stream.CopyTo(fs);
                            //将写入流中的数据写入到文件中
                            fs.Flush();
                        }
                        ADItem aditem = new ADItem();
                        aditem.filePath = path + fileName_New; //获得文件的完整路径（包括名字后后缀）
                        aditem.fileName_New = fileName_New;
                        aditem.isChecked = false;
                        this.flowLayoutPanel1.Controls.Add(aditem);
                        dal.InsertAD(fileName, fileName_New);
                    }
                }
            }
        }

        /// <summary>
        /// 右移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_moveR_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.flowLayoutPanel1.Controls.Count; i++)
            {
                bool isChecked = ((Server.ADItem)(this.flowLayoutPanel1.Controls[i])).isChecked;
                if (isChecked)
                {
                    this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel1.Controls[i]);
                    i--;
                }
            }
        }

        /// <summary>
        /// 左移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_moveL_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.flowLayoutPanel2.Controls.Count; i++)
            {
                bool isChecked = ((Server.ADItem)(this.flowLayoutPanel2.Controls[i])).isChecked;
                if (isChecked)
                {
                    this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2.Controls[i]);
                    i--;
                }
            }
        }

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_delete_Click(object sender, EventArgs e)
        {
            List<ADItem> aditemList = new List<ADItem>();
            string aditems = string.Empty;
            for (int i = 0; i < this.flowLayoutPanel1.Controls.Count; i++)
            {
                bool isChecked = ((Server.ADItem)(this.flowLayoutPanel1.Controls[i])).isChecked;
                if (isChecked)
                {
                    aditemList.Add((Server.ADItem)(this.flowLayoutPanel1.Controls[i]));
                    aditems += "|" + ((Server.ADItem)(this.flowLayoutPanel1.Controls[i])).fileName_New;
                }
            }
            if (aditemList.Count > 0)
            {
                if (MessageBox.Show("勾选的数据将被删除，是否继续？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (ADItem item in aditemList)
                    {
                        this.flowLayoutPanel1.Controls.Remove(item);
                        System.IO.FileInfo file = new System.IO.FileInfo(item.filePath);
                        if (file.Exists)//文件是否存在，存在则执行删除  
                        {
                            file.Delete();
                        }
                        dal.DeleteAD(item.fileName_New);

                    }
                    MessageBox.Show("删除成功");
                }
            }
            else
            {
                MessageBox.Show("请您至少选择一条数据");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 投放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_putIn_Click(object sender, EventArgs e)
        {
            List<ADItem> aditemList = new List<ADItem>();
            for (int i = 0; i < this.flowLayoutPanel2.Controls.Count; i++)
            {
                aditemList.Add((Server.ADItem)(this.flowLayoutPanel2.Controls[i]));
            }
            if (SendAdvertisement != null)
            {
                SendAdvertisement(aditemList);
            }
        }
    }
}
