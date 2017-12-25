using Common;
using HPSocketCS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Data.SqlClient;
using System.Threading;

namespace Server
{
    public enum AppState
    {
        Starting, Started, Stoping, Stoped, Error
    }

    public partial class ServerMainWin : Form
    {
        private AppState appState = AppState.Stoped;
        private delegate void WriteLog(string msg);

        private WriteLog WriteLogDelegate;
        HPSocketCS.TcpPackServer server = new HPSocketCS.TcpPackServer();//服务端组件
        private ServerDAL dal = new ServerDAL();
        private ServerBLL bll = new ServerBLL();
        private List<ClientInfo> OnLineClient = new List<ClientInfo>();

        public ServerMainWin()
        {
            InitializeComponent();
            ServerConfig.LoadConfig();
        }

        #region 窗体生命周期
        private void ServerMainWin_FormClosed(object sender, FormClosedEventArgs e)
        {
            server.Destroy();
        }

        private void ServerMainWin_Load(object sender, EventArgs e)
        {
            try
            {
                LogHelper.logRecord("==========启动==========");
                server.OnAccept += Server_OnAccept;//接受连接请求
                server.OnShutdown += Server_OnShutdown;//服务通信组件停止
                server.OnClose += Server_OnClose;//连接正常或者异常关闭
                server.OnSend += Server_OnSend;//数据发送成功
                server.OnReceive += Server_OnReceive;//服务端接收到数据
                server.OnHandShake += Server_OnHandShake;//成功握手
                // 设置包头标识,与对端设置保证一致性
                server.PackHeaderFlag = 0xff;
                // 设置最大封包大小
                server.MaxPackSize = 1024 * 100;
                server.SocketBufferSize = 1024 * 1024 * 4 - 1;
                SetAppState(AppState.Stoped);

                reLoadWatchers(2);




            }
            catch (Exception ex)
            {
                SetAppState(AppState.Error);
                LogHelper.logRecord(ex.Message);
            }
            Start();//开启服务
        }
        #endregion
        #region UI
        /// <summary>
        /// 设置程序状态
        /// </summary>
        /// <param name="state"></param>
        void SetAppState(AppState state)
        {
            appState = state;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            reLoadWatchers(3);
        }
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            reLoadWatchers(4);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            reLoadWatchers(1);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            reLoadWatchers(2);
        }

        #endregion
        #region 服务端组件 核心事件处理
        /// <summary>
        /// 开启服务
        /// </summary>
        private void Start()
        {
            try
            {
                String ip = "0.0.0.0";//监听本地
                ushort port = 6080;//设置一个非主流的端口号，避免占用其他应用程序
                server.IpAddress = ip;
                server.Port = port;
                // 写在这个位置是上面可能会异常
                SetAppState(AppState.Starting);
                // 启动服务
                if (server.Start())
                {
                    SetAppState(AppState.Started);
                    LogHelper.logRecord(string.Format("服务启动成功 -> {0}({1})", ip, port));
                }
                else
                {
                    SetAppState(AppState.Stoped);
                    LogHelper.logRecord(string.Format("服务启动失败 -> {0}({1})", server.ErrorMessage, server.ErrorCode));
                }
            }
            catch (Exception ex)
            {
                LogHelper.logRecord(ex.Message);
            }
        }
        /// <summary>
        /// 关闭服务
        /// </summary>
        private void Stop()
        {
            // 停止服务
            SetAppState(AppState.Stoping);
            if (server.Stop())
            {
                SetAppState(AppState.Stoped);
            }
            else
            {
                LogHelper.logRecord(string.Format("服务停止失败 -> {0}({1})", server.ErrorMessage, server.ErrorCode));
            }
        }

        #region 消息接收事件


        //注意：只传递SendData数据
        private HPSocketCS.HandleResult Server_OnReceive(IntPtr connId, byte[] bytes)
        {
            // 数据到达了
            try
            {

                // 获取附加数据
                var clientInfo = server.GetExtra<ClientInfo>(connId);
                if (clientInfo != null)
                {
                    // clientInfo 就是accept里传入的附加数据了
                    //Write(string.Format(" > [{0},OnReceive] -> {1}:{2} ({3} bytes)", clientInfo.ConnId, clientInfo.IpAddress, clientInfo.Port, bytes.Length));
                    SendData sendData = server.BytesToObject(bytes) as SendData;

                    switch (sendData.ActionCode)
                    {
                        case ActionCodeBase.ThroughDoor:
                            if (sendData.IORInfoL.Count > 0)
                            {
                                this.Invoke(new Action<ClientInfo, SendData>(ReSendToClient), clientInfo, sendData);
                                dal.RecordInOut(sendData.IORInfoL[0]);
                                if (sendData.IORInfoL[0].ThroughWay == "ThroughWay_C")
                                {
                                    if (sendData.PInfoL.Count > 0)
                                    {
                                        dal.RegisterPersonnelInfo(sendData.PInfoL[0]);
                                    }
                                    if (sendData.FFInfoL.Count > 0)
                                    {
                                        dal.RegisterFaceFeature(sendData.FFInfoL[0].Feature, sendData.FFInfoL[0].IDCard);
                                    }
                                }
                            }

                            break;
                        case ActionCodeBase.UploadData_Success:
                            //收到数据上传成功指令，则下发数据，各端实时同步最新数据
                            clientInfo.DBInfo = sendData.DBInfo;
                            List<ClientInfo> list = GetClientInfoList();//在线客户端列表
                            bll.DataSync(list);
                            break;
                        case ActionCodeBase.ReSendPicture:
                            //发送画面 =》 监视窗口
                            this.Invoke(new Action<ClientInfo, SendData>(ReSendToClient), clientInfo, sendData);
                            break;

                    }
                    //Write(string.Format(" > [{0},OnReceive] -> SendData({1},{2})", clientInfo.ConnId, sendData.Order, sendData.Message));

                }
                else
                {
                    LogHelper.logRecord(string.Format(" > [{0},OnReceive] -> ({1} bytes)", connId, bytes.Length));
                }

                return HandleResult.Ok;
            }
            catch (Exception)
            {

                return HandleResult.Ignore;
            }
        }

        #endregion

        #region 消息成功发送事件
        private HPSocketCS.HandleResult Server_OnSend(IntPtr connId, byte[] bytes)
        {
            return HandleResult.Ok;
        }
        #endregion

        #region 客户端断开连接（正常和异常）
        private HPSocketCS.HandleResult Server_OnClose(IntPtr connId, HPSocketCS.SocketOperation enOperation, int errorCode)
        {
            ClientInfo client = server.GetExtra<ClientInfo>(connId);
            this.Invoke(new Action<ClientInfo>(DisBindClient), client);
            OnLineClient.Remove(client);//移除出在线客户端
            WatcherPanelInstance.DisBindClient(client);
            return HandleResult.Ok;
        }
        #endregion

        #region 服务通信组件停止
        private HPSocketCS.HandleResult Server_OnShutdown()
        {
            //Write("服务停止 > [OnShutdown]");
            return HandleResult.Ok;
        }
        #endregion

        #region 接受客户端连接请求
        private HPSocketCS.HandleResult Server_OnAccept(IntPtr connId, IntPtr pClient)
        {
            // 客户进入了
            // 获取客户端ip和端口
            string ip = string.Empty;
            ushort port = 0;
            if (server.GetRemoteAddress(connId, ref ip, ref port))
            {
                //通知客户端连接成功
                SendData sendData = new SendData();
                sendData.ActionCode = ActionCodeBase.ConnectionSuccess;
                server.SendBySerializable(connId, sendData);
                //存储客户端信息
            }
            else
            {
                //Write(string.Format(" > [{0},OnAccept] -> Server_GetClientAddress() Error", connId));
            }

            // 设置附加数据
            ClientInfo clientInfo = new ClientInfo();
            clientInfo.ConnId = connId;
            clientInfo.IpAddress = ip;
            clientInfo.Port = port;
            if (server.SetExtra(connId, clientInfo) == false)
            {
                LogHelper.logRecord(string.Format(" > [{0},OnAccept] -> SetConnectionExtra fail", connId));
            }
            this.Invoke(new Action<ClientInfo>(BindClient), clientInfo);
            return HandleResult.Ok;
        }
        #endregion

        #region 与客户端成功握手
        private HandleResult Server_OnHandShake(IntPtr connId)
        {
            LogHelper.logRecord(string.Format(" > [{0},OnHandShake]", connId));
            return HandleResult.Ok;
        }
        #endregion
        #endregion
        #region 监控客户端
        private string WatchPanelName = "Server.WatchPanel{0}";
        private BaseWatchPanel WatcherPanelInstance { set; get; }
        private Assembly EntryAssembly_;
        public Assembly EntryAssembly
        {
            get
            {
                if (null == EntryAssembly_)
                {
                    EntryAssembly_ = Assembly.GetEntryAssembly();
                }
                return EntryAssembly_;
            }
        }

        /// <summary>
        /// 窗体布局
        /// </summary>
        /// <param name="count">窗口个数</param>
        private void reLoadWatchers(int count)
        {
            if (watcherPanel.Controls.Count > 0)
            {
                watcherPanel.Controls.RemoveAt(0);
            }

            WatcherPanelInstance = EntryAssembly.CreateInstance(string.Format(WatchPanelName, count), true) as BaseWatchPanel;
            ((Control)WatcherPanelInstance).Dock = DockStyle.Fill;
            watcherPanel.Controls.Add((Control)WatcherPanelInstance);
            BindAll();
        }
        private void DisBindAll()
        {
            List<ClientInfo> list = GetClientInfoList();
            for (int i = 0; i < list.Count; i++)
            {
                WatcherPanelInstance.DisBindClient(list[i]);
            }
        }
        private void BindAll()
        {
            List<ClientInfo> list = GetClientInfoList();
            for (int i = 0; i < list.Count; i++)
            {
                WatcherPanelInstance.BindClient(list[i], i);
            }
        }
        private void BindClient(ClientInfo client)
        {
            WatcherPanelInstance.BindClient(client);
        }
        private void ReSendToClient(ClientInfo client, SendData data)
        {
            WatcherPanelInstance.SendDataToClientWatch(client, data);
        }

        private void DisBindClient(ClientInfo client)
        {
            WatcherPanelInstance.DisBindClient(client);
        }
        public List<ClientInfo> GetClientInfoList()
        {
            List<ClientInfo> list = new List<ClientInfo>();
            IntPtr[] prts = server.GetAllConnectionIDs();
            if (null != prts)
            {
                foreach (IntPtr clientId in server.GetAllConnectionIDs())
                {
                    list.Add(server.GetExtra<ClientInfo>(clientId));
                }
            }
            return list;
        }
        #endregion

        #region 发布命令

        /// <summary>
        /// 上传数据
        /// </summary>
        /// <param name="connId"></param>
        public void Send_UploadData(IntPtr connId)
        {
            SendData sendData = new SendData();
            sendData.ActionCode = ActionCodeBase.UploadData;
            server.SendBySerializable(connId, sendData);
        }

        #endregion



        private void 数据同步ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
            //遍历在线客户端，发送上传数据指令，接收客户端上传结果，计数成功个数，全部上传后，下发数据
            //
            List<ClientInfo> list = GetClientInfoList();//在线客户端列表
            if (bll.DataSync(list))
            {
                MessageBox.Show("数据同步成功！");
            }
        }

        private void 白名单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WhiteListWindow form = new WhiteListWindow();
            form.PersonType = "PersonType_01";
            form.ShowDialog();
        }

        private void 黑名单管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WhiteListWindow WLWin = new WhiteListWindow();
            WLWin.PersonType = "PersonType_02";
            WLWin.ShowDialog();
        }

        private void 访客管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WhiteListWindow WLWin = new WhiteListWindow();
            WLWin.PersonType = "PersonType_00";
            WLWin.ShowDialog();
        }

        private void 进出记录ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InOutRecordWindow IORWin = new InOutRecordWindow();
            IORWin.ShowDialog();
        }

        private void 数据库连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBaseSetWin dbWin = new DataBaseSetWin();
            dbWin.StartPosition = FormStartPosition.CenterParent;
            dbWin.ShowDialog();
        }

        private void 广告管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ADManageWin adManageWin = new ADManageWin();
            adManageWin.SendAdvertisement += new SendAdvertisementD(SendAdvertisement);
            adManageWin.ShowDialog();
        }

        #region 发布广告

        /// <summary>
        /// 发布广告
        /// </summary>
        /// <param name="ADItem"></param>
        private void SendAdvertisement(List<ADItem> ADItem)
        {
            //Thread SendBigDataThread = new Thread(SendADThread);
            //SendBigDataThread.Start(ADItem);
            new Thread(() =>
                {
                    try
                    {
                        //SendData sendData = new SendData();
                        //sendData.ActionCode = ActionCodeBase.PutInAdvertisement;
                        List<ADFileStream> ADSL = new List<ADFileStream>();
                        foreach (ADItem item in ADItem)
                        {
                            FileInfo fi = new FileInfo(item.filePath);
                            byte[] buff = new byte[fi.Length];
                            FileStream fs = fi.OpenRead();
                            fs.Read(buff, 0, Convert.ToInt32(fs.Length));
                            fs.Close();
                            ADFileStream ADS = new ADFileStream();
                            ADS.FileStream = buff;
                            ADS.FileName = item.fileName_New;
                            ADSL.Add(ADS);
                        }
                        byte[] bigData = ADSL.PaseToByte();
                        IntPtr[] ConnectionIDs = server.GetAllConnectionIDs();
                        foreach (IntPtr connId in ConnectionIDs)
                        {
                            server.SendBigDataToClient(connId, bigData, ActionCodeBase.PutInAdvertisement, null, null);
                        }
                        MessageBox.Show("投放成功");
                    }
                    catch
                    {
                        MessageBox.Show("投放失败");
                    }
                }).Start();
        }

        public void SendADThread(object obj)
        {
            List<ADItem> ADItem = (List<ADItem>)obj;

            SendData sendData = new SendData();
            sendData.ActionCode = ActionCodeBase.PutInAdvertisement;
            List<ADFileStream> ADSL = new List<ADFileStream>();
            foreach (ADItem item in ADItem)
            {
                FileInfo fi = new FileInfo(item.filePath);
                byte[] buff = new byte[fi.Length];
                FileStream fs = fi.OpenRead();
                fs.Read(buff, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                ADFileStream ADS = new ADFileStream();
                ADS.FileStream = buff;
                ADS.FileName = item.fileName_New;
                ADSL.Add(ADS);
            }
            byte[] bigData = ADSL.PaseToByte();
            IntPtr[] ConnectionIDs = server.GetAllConnectionIDs();
            bool result = false;
            foreach (IntPtr connId in ConnectionIDs)
            {
                server.SendBigDataToClient(connId, bigData, ActionCodeBase.PutInAdvertisement, null, null);
            }
            if (result)
            {
                MessageBox.Show("投放成功");
            }
            else
            {
                MessageBox.Show("投放失败");
            }
        }


        private void SendBigDataToServer(byte[] bigData, IntPtr connId)
        {
            string dataId = Guid.NewGuid().PaseToString();
            long perlen = server.MaxPackSize - 60 * 1024;//少传5K，避免溢出 每段大小
            long packs = (bigData.Length + perlen - 1) / perlen;//段数
            for (long i = 0; i < packs; i++)
            {
                long L;
                PostDataState state = PostDataState.Part;
                if ((i + 1) * perlen >= bigData.Length)
                {
                    //最后一个包
                    L = (bigData.Length - i * perlen);
                    state = PostDataState.Over;
                }
                else
                {
                    state = PostDataState.Part;
                    L = perlen;
                }
                byte[] sendData = new byte[L];
                Array.Copy(bigData, i * perlen, sendData, 0, L);
                SendData pd = new SendData()
                {
                    State = state,
                    DataId = dataId,
                    //Data = sendData,
                    //IsBigData = true
                    ActionCode = ActionCodeBase.PutInAdvertisement
                };
                server.SendBySerializable(connId, pd);
            }
        }
        #endregion

        #region new ToolStripMenu
        private void 数据同步ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //
            //遍历在线客户端，发送上传数据指令，接收客户端上传结果，计数成功个数，全部上传后，下发数据
            //
            List<ClientInfo> list = GetClientInfoList();//在线客户端列表
            if (list.Count > 0)
            {
                if (bll.DataSync(list))
                {
                    MessageBox.Show("数据同步成功！");
                }
            }
            else
            {
                MessageBox.Show("客户端未连接！");
            }
        }

        private void 白名单ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WhiteListWindow form = new WhiteListWindow();
            form.PersonType = "PersonType_01";
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void 黑名单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WhiteListWindow WLWin = new WhiteListWindow();
            WLWin.PersonType = "PersonType_02";
            WLWin.StartPosition = FormStartPosition.CenterParent;
            WLWin.ShowDialog();
        }

        private void 访客ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WhiteListWindow WLWin = new WhiteListWindow();
            WLWin.PersonType = "PersonType_00";
            WLWin.StartPosition = FormStartPosition.CenterParent;
            WLWin.ShowDialog();
        }

        private void 进出记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InOutRecordWindow IORWin = new InOutRecordWindow();
            IORWin.StartPosition = FormStartPosition.CenterParent;
            IORWin.ShowDialog();
        }

        private void 广告管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ADManageWin adManageWin = new ADManageWin();
            adManageWin.SendAdvertisement += new SendAdvertisementD(SendAdvertisement);
            adManageWin.StartPosition = FormStartPosition.CenterParent;
            adManageWin.ShowDialog();
        }

        #endregion









    }
}
