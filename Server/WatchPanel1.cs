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
    public partial class WatchPanel1 : BaseWatchPanel
    {
        public WatchPanel1()
        {
            InitializeComponent();
            this.Load += WatchPanel1_Load;
        }

        private void WatchPanel1_Load(object sender, EventArgs e)
        {

        }

        private Dictionary<int, ClientWatch> ClientDic_;
        public override Dictionary<int, ClientWatch> ClientDic()
        {
            if (null == ClientDic_)
            {
                ClientDic_ = new Dictionary<int, ClientWatch>();
                ClientDic_.Add(0, clientWatch1);
            }
            return ClientDic_;
        }

    }
}
