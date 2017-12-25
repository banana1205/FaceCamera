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
    public partial class WatchPanel16 : BaseWatchPanel
    {
        public WatchPanel16()
        {
            InitializeComponent();
        }
        private Dictionary<int, ClientWatch> ClientDic_;
        public override Dictionary<int, ClientWatch> ClientDic()
        {
            if (null == ClientDic_)
            {
                ClientDic_ = new Dictionary<int, ClientWatch>();
                ClientDic_.Add(0, clientWatch1);
                ClientDic_.Add(1, clientWatch2);
                ClientDic_.Add(2, clientWatch3);
                ClientDic_.Add(3, clientWatch4);
                ClientDic_.Add(4, clientWatch5);
                ClientDic_.Add(5, clientWatch6);
                ClientDic_.Add(6, clientWatch7);
                ClientDic_.Add(7, clientWatch8);
                ClientDic_.Add(8, clientWatch9);
                ClientDic_.Add(9, clientWatch10);
                ClientDic_.Add(10, clientWatch11);
                ClientDic_.Add(11, clientWatch12);
                ClientDic_.Add(12, clientWatch13);
                ClientDic_.Add(13, clientWatch14);
                ClientDic_.Add(14, clientWatch15);
                ClientDic_.Add(15, clientWatch16);
            }
            return ClientDic_;
        }
    }
}
