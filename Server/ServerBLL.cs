using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Threading;
using System.Data;
using System.Data.SqlClient;

namespace Server
{
    public class ServerBLL
    {
        private ServerDAL dal = new ServerDAL();
        private ZKSIdReadBLL ZKSIdRead = new ZKSIdReadBLL();//身份证读卡


        //public void OpenRegisterWhiteListThread()
        //{
        //    ZKSIdRead.Start();//身份证读卡器

        //}

        /// <summary>
        /// 注册白名单
        /// </summary>
        //public void RegisterWhiteList()
        //{
        //    PersonnelInfo PInfo = new PersonnelInfo();
        //    if (ZKSIdRead.ReadCard(ref PInfo))
        //    {
        //        ServerDAL dal = new ServerDAL();
        //        dal.RegisterPersonnelInfo(PInfo);
        //    }
        //}

        /// <summary>
        /// 数据同步
        /// </summary>
        /// <returns></returns>
        public bool DataSync(List<ClientInfo> list)
        {
            try
            {
                DataTable PDt = dal.GetPersonnel();
                DataTable FDt = dal.GetFaceFeature();
                SqlHelper sql = new SqlHelper();
                //SqlParameter[] param = { 
                //                    new SqlParameter("@PDt", PDt),
                //                    new SqlParameter("@FDt", FDt)
                //                };
                int EffectCount = 0;

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].DBInfo != null)
                    {
                        string DataSource = list[i].IpAddress + "\\" + list[i].DBInfo.Server;
                        string User = list[i].DBInfo.User;
                        string Password = list[i].DBInfo.Password;
                        string Database = list[i].DBInfo.Database;
                        string connectionStr = "Data Source=" + DataSource + ";user=" + User + ";password=" + Password + ";Initial Catalog=" + Database + ";";
                        if (!string.IsNullOrEmpty(connectionStr))
                        {
                            EffectCount = sql.ExecuteSqlBulkCopy(PDt, connectionStr, "Personnel");
                            EffectCount = sql.ExecuteSqlBulkCopy(FDt, connectionStr, "FaceFeature");
                            EffectCount = dal.DeleteDuplicateData(connectionStr);

                            //EffectCount += sql.ExecuteStoredProcedure("ServerToClient", param.ToArray(), connectionStr);
                        }
                    }
                    else
                    {
                        LogHelper.logRecord("IpAddress:" + list[i].IpAddress + " => 未携带数据库连接属性");
                    }
                }
                if (EffectCount > 0)
                {
                    return true;
                    //MessageBox.Show("下发成功！");
                }
                return false;
            }
            catch (Exception e)
            {
                LogHelper.logRecord("DataSync() => " + e.Message);
                return false;
            }
        }



    }
}
