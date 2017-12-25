using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class ADItem : UserControl
    {
        public string filePath = string.Empty;
        public bool isChecked = false;
        public string fileName_New = string.Empty;
        public ADItem()
        {
            InitializeComponent();
        }

        private void ADItem_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                //System.Drawing.Image img = System.Drawing.Image.FromFile(filePath);
                pictureBox1.ImageLocation = filePath;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (isChecked)
            {
                isChecked = false;
                this.pictureBox1.BorderStyle = BorderStyle.None;
            }
            else
            {
                isChecked = true;
                //Pen pen = new Pen(Color.Blue);
                //pen.Width = 2;
                //Graphics g = this.pictureBox1.CreateGraphics();
                //g.DrawRectangle(pen, 0, 0
                //                , this.pictureBox1.Width - 2
                //                , this.pictureBox1.Height - 2);
                pictureBox1.BorderStyle = BorderStyle.Fixed3D;
                pictureBox1.Refresh();//强制控件重新绘制

            }

        }
    }
}
