using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Server
{
    public class ClientInfo
    {
        /// <summary>
        /// 客户端唯一标识
        /// </summary>
        public IntPtr ConnId { get; set; }
        /// <summary>
        /// 远程客户端IP地址
        /// </summary>
        public string IpAddress { get; set; }
        /// <summary>
        /// 远程客户端端口号
        /// </summary>
        public ushort Port { get; set; }

        /// <summary>
        /// 数据库链接属性
        /// </summary>
        public DatabaseInfo DBInfo { get; set; }

        private int WatchClientId_ = -1;
        /// <summary>
        /// 关联监视器的编号
        /// </summary>
        public int WatchClientId
        {
            set { WatchClientId_ = value; }
            get { return WatchClientId_; }
        }
    }
}
