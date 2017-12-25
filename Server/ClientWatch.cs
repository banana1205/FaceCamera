using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace Server
{
    public enum ClientWatchState { Watching, Stop }
    public partial class ClientWatch : UserControl
    {
        public ClientWatchState State = ClientWatchState.Stop;
        private ClientInfo WatchingClient = null;
        public ClientWatch()
        {
            InitializeComponent();
        }
        public void BindClient(ClientInfo client)
        {
            WatchingClient = client;
            State = ClientWatchState.Watching;
            Write(string.Format("设备{0}[{1}:{2}] -> 成功连接", client.ConnId, client.IpAddress, client.Port));
        }
        public void DisBindClient(ClientInfo client)
        {
            if (client == WatchingClient)
            {
                State = ClientWatchState.Stop;
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                pictureBox3.Image = null;
                label_name.Text = null;
                label_card.Text = null;
                label_throughWay.Text = null;
                label_time.Text = null;
                Write(string.Format("设备{0}[{1}:{2}] -> 断开连接", client.ConnId, client.IpAddress, client.Port));
            }
            else
            {
                Write(string.Format("设备{0}[{1}:{2}] -> 断开连接失败", client.ConnId, client.IpAddress, client.Port));
            }
        }
        /// <summary>
        /// 画面接收
        /// </summary>
        /// <param name="client"></param>
        /// <param name="data"></param>
        public void OnReceive(ClientInfo client, SendData data)
        {
            Write(string.Format("{0} ->[OnReceive] sendData({1},{2})", client.IpAddress, data.Order, data.Message));

            if (!string.IsNullOrEmpty(data.image))
            {
                Bitmap bit = ImageConversion.Base64StringToBitmap(data.image);
                pictureBox1.Image = ImageConversion.Base64StringToBitmap(data.image);
            }
          
            if (data.IORInfoL != null)
            {
                if (data.IORInfoL.Count > 0)
                {
                    this.pictureBox2.Image = ImageConversion.BytesToBitmap(data.IORInfoL[0].SceneImage);
                    if (data.PInfoL.Count > 0)
                    {
                        this.pictureBox3.Image = ImageConversion.BytesToBitmap(data.PInfoL[0].FaceImage);
                        this.label_name.Text = data.PInfoL[0].Name;
                        this.label_card.Text = data.PInfoL[0].IDCard;
                        this.label_throughWay.Text = data.IORInfoL[0].InOutType == "InOutType_00" ? "进" : "出";
                        this.label_time.Text = data.IORInfoL[0].InOutTime.ToString("yyyy年MM月dd日 HH:mm:ss");
                    }
                }
            }
            
        }
        public void Write(string msg)
        {
            //logList.Items.Add(msg);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
             
        }


    }
}
