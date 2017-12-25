using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    /// <summary>
    /// 查询条件
    /// </summary>
    [Serializable]
    public class SearchValueInfo
    {
        public string IDCard { get; set; }
        public string inOutType { get; set; }
        public string name { get; set; }
        public DateTime beginDate { get; set; }
        public DateTime endDate { get; set; }


    }
}
