using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public class BaseWatchPanel: UserControl
    {
    
        public virtual Dictionary<int, ClientWatch> ClientDic() { return null; }
        /// <summary>
        /// 绑定监视窗口
        /// </summary>
        /// <param name="client"></param>
        /// <param name="id"></param>
        public void BindClient(ClientInfo client, int id = -1)
        {
            if (id >= 0 && id < ClientDic().Count)
            {
                if (ClientDic()[id].State != ClientWatchState.Watching)
                {
                    client.WatchClientId = id;
                    ClientDic()[id].BindClient(client);
                }
            }
            else
            {
                foreach (int i in ClientDic().Keys)
                {
                    if (ClientDic()[i].State != ClientWatchState.Watching)
                    {
                        client.WatchClientId = i;
                        ClientDic()[i].BindClient(client);
                        break;
                    }
                }
            }
        }

        public void DisBindClient(ClientInfo client)
        {
            int id = client.WatchClientId;
            if (id >= 0 && id < ClientDic().Count)
            {
                if (ClientDic()[id].State == ClientWatchState.Watching)
                {
                    ClientDic()[client.WatchClientId].DisBindClient(client);
                    client.WatchClientId = -1;
                    
                }
            }
        }
        /// <summary>
        /// 发送数据到监视窗口
        /// </summary>
        /// <param name="client"></param>
        /// <param name="data"></param>
        public void SendDataToClientWatch(ClientInfo client, SendData data) {
            int id = client.WatchClientId;
            if (id >= 0 && id < ClientDic().Count)
            {
                if (ClientDic()[id].State == ClientWatchState.Watching)
                {
                    ClientDic()[client.WatchClientId].OnReceive(client, data);
                }
            }
      
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseWatchPanel
            // 
            this.Name = "BaseWatchPanel";
            this.ResumeLayout(false);

        }
    }
}
