﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class WatchPanel4 : BaseWatchPanel
    {
        public WatchPanel4()
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
            }
            return ClientDic_;
        }
    }
}
