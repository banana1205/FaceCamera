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
    public partial class WatchPanel2 : BaseWatchPanel
    {
        public WatchPanel2()
        {
            InitializeComponent();
            this.Load += WatchPanel2_Load;
        }

        private void WatchPanel2_Load(object sender, EventArgs e)
        {

        }

        private Dictionary<int, ClientWatch> ClientDic_;
        public override Dictionary<int, ClientWatch> ClientDic()
        {
            if (null == ClientDic_)
            {
                ClientDic_ = new Dictionary<int, ClientWatch>();
                ClientDic_.Add(0, clientWatch1);
                ClientDic_.Add(1, clientWatch2);
            }
            return ClientDic_;
        }

    }
}
