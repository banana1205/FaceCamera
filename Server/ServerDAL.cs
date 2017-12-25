using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Data.SqlClient;
using System.Data;

namespace Server
{
    public class ServerDAL
    {
        SqlHelper db = new SqlHelper();
        string connectionStr { get { return ServerConfig.connectionStrings; } }


        #region 数据同步

        /// <summary>
        /// 去除重复数据
        /// </summary>
        /// <param name="ServerConnectionStr"></param>
        /// <returns></returns>
        public int DeleteDuplicateData(string ServerConnectionStr)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" DELETE  FROM  Personnel ");
            sql.Append(" WHERE IDCard IN (SELECT IDCard FROM Personnel GROUP BY IDCard HAVING count(IDCard) > 1) ");
            sql.Append(" AND DBID NOT IN  (SELECT  MAX(DBID) FROM Personnel GROUP BY IDCard HAVING  count(IDCard)>1) ");

            sql.Append(" DELETE  FROM  FaceFeature ");
            sql.Append(" WHERE IDCard IN (SELECT IDCard FROM FaceFeature GROUP BY IDCard HAVING count(IDCard) > 1) ");
            sql.Append(" AND DBID NOT IN  (SELECT  MAX(DBID) FROM FaceFeature GROUP BY IDCard HAVING  count(IDCard)>1) ");

            return db.ExecuteNonQuery(sql.ToString(), ServerConnectionStr);
        }

        /// <summary>
        /// 注册人脸特征
        /// </summary>
        /// <param name="feature1"></param>
        /// <param name="IDCard"></param>
        /// <returns></returns>
        public int RegisterFaceFeature(byte[] feature1, string IDCard)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append(" INSERT INTO FaceFeature  ");
            sqlStr.Append(" (Feature, IDCard, Flag, CreateDate) ");
            sqlStr.Append(" VALUES  ");
            sqlStr.Append(" (@Feature, @IDCard,1, @CreateDate) ");
            SqlParameter[] parm = {
                                     new SqlParameter("@Feature",feature1),//byte[]数组内容 
                                     new SqlParameter("@IDCard",IDCard),//
                                     new SqlParameter("@CreateDate",DateTime.Now)//
                                 };
            return db.ExecuteNonQuery(sqlStr.ToString(), parm.ToArray(), connectionStr);
        }

        /// <summary>
        /// 注册人员基本信息
        /// </summary>
        /// <param name="PInfo"></param>
        /// <returns></returns>
        public int RegisterPersonnelInfo(PersonnelInfo PInfo)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" if not exists (select IDCard from Personnel where flag=1 and IDCard=@IDCard ) ");
            sql.Append(" INSERT INTO dbo.Personnel ");
            sql.Append(" (Name, IDCard, Flag, CreateDate, LastModifyDate, PersonType, FaceImage, Address,Gender,Nation,BirthDate) ");
            sql.Append(" VALUES ");
            sql.Append(" (@Name, @IDCard,1, @CreateDate, @LastModifyDate, @PersonType, @FaceImage, @Address,@Gender,@Nation,@BirthDate) ");

            sql.Append(" else ");

            sql.Append(" UPDATE dbo.Personnel SET ");
            sql.Append(" Name = @Name, ");
            sql.Append(" LastModifyDate = @LastModifyDate, ");
            sql.Append(" FaceImage = @FaceImage, ");
            sql.Append(" Address = @Address, ");
            sql.Append(" Gender = @Gender, ");
            sql.Append(" Nation = @Nation, ");
            sql.Append(" BirthDate = @BirthDate ");
            sql.Append(" WHERE Flag=1 ");
            sql.Append(" AND IDCard=@IDCard ");

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Name", PInfo.Name));
            paramList.Add(new SqlParameter("@IDCard", PInfo.IDCard));
            //paramList.Add(new SqlParameter("@Phone", PInfo.Phone));
            paramList.Add(new SqlParameter("@CreateDate", DateTime.Now));
            paramList.Add(new SqlParameter("@LastModifyDate", DateTime.Now));
            paramList.Add(new SqlParameter("@PersonType", PInfo.PersonType));
            paramList.Add(new SqlParameter("@FaceImage", PInfo.FaceImage));
            paramList.Add(new SqlParameter("@Address", PInfo.Address));
            paramList.Add(new SqlParameter("@Gender", PInfo.Gender));
            paramList.Add(new SqlParameter("@Nation", PInfo.Nation));
            paramList.Add(new SqlParameter("@BirthDate", PInfo.BirthDate));

            return db.ExecuteNonQuery(sql.ToString(), paramList.ToArray(), connectionStr);
        }

        /// <summary>
        /// 获取人员信息表 ==》 下发数据 做存储过程参
        /// </summary>
        /// <returns></returns>
        public DataTable GetPersonnel()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM dbo.Personnel ");
            return db.ExecuteReader(sql.ToString(), connectionStr);
        }

        /// <summary>
        /// 获取人脸特征库 ==》 下发数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetFaceFeature()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM dbo.FaceFeature ");
            return db.ExecuteReader(sql.ToString(), connectionStr);
        }

        /// <summary>
        /// 记录进出
        /// </summary>
        /// <param name="IDCard">身份证号</param>
        /// <param name="InOutTime">进出时间</param>
        /// <param name="InOutType">进出类型 0 出 | 1 进</param>
        /// <returns></returns>
        public bool RecordInOut(InOutRecordInfo IORecordInfo)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append(" INSERT INTO InOutRecord ");
            sqlStr.Append(" (IDCard, InOutType, InOutTime, Flag,CompareResult,ThroughWay,SceneImage) ");
            sqlStr.Append(" VALUES ");
            sqlStr.Append(" (@IDCard, @InOutType, @InOutTime, 1,@CompareResult,@ThroughWay,@SceneImage ) ");
            SqlParameter[] parm = {
                                  new SqlParameter("@IDCard",IORecordInfo.IDCard),
                                  new SqlParameter("@InOutType",IORecordInfo.InOutType),
                                  new SqlParameter("@InOutTime",IORecordInfo.InOutTime),
                                  new SqlParameter("@CompareResult",IORecordInfo.CompareResult),
                                  new SqlParameter("@ThroughWay",IORecordInfo.ThroughWay),
                                  new SqlParameter("@SceneImage",IORecordInfo.SceneImage)
                                  };
            return db.ExecuteNonQuery(sqlStr.ToString(), parm.ToArray(), connectionStr) > 0 ? true : false;
        }

        #endregion

        #region 名单管理

        /// <summary>
        /// 白名单列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetWhiteList(string PersonType, int pageIndex, int pageSize, SearchValueInfo sInfo)
        {
            string OrderBy = " ORDER BY LastModifyDate DESC ";
            int start = (pageIndex - 1) * pageSize;
            StringBuilder condition = new StringBuilder();
            condition.AppendFormat(" WHERE Flag=1 AND PersonType='{0}' ", PersonType);
            if (!string.IsNullOrEmpty(sInfo.name))
            {
                condition.AppendFormat(" and Name like '%{0}%' ", sInfo.name);
            }
            if (!string.IsNullOrEmpty(sInfo.IDCard))
            {
                condition.AppendFormat(" and IDCard like '%{0}%' ", sInfo.IDCard);
            }
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" SELECT top {0} ROW_NUMBER() OVER( {1} ) RowNumber, * ", pageSize, OrderBy);
            sql.Append(" FROM dbo.Personnel ");
            sql.Append(condition);
            sql.AppendFormat(" and DBID not in ( SELECT top {0} DBID from Personnel {1} {2} ) {2} ", start, condition, OrderBy);

            sql.Append(" ; SELECT COUNT(*) FROM Personnel ");
            sql.Append(condition);
            return db.GetDataSet(sql.ToString(), connectionStr);
        }

        /// <summary>
        /// 更改人员类型
        /// </summary>
        /// <param name="personType"></param>
        /// <param name="IDCard"></param>
        /// <returns></returns>
        public int UpdataPersonType(string personType, string IDCard)
        {
            IDCard = IDCard.Trim().Replace("|", "','");
            StringBuilder sql = new StringBuilder();
            sql.Append(" UPDATE dbo.Personnel Set ");
            sql.Append(" LastModifyDate = @LastModifyDate, ");
            sql.Append(" PersonType = @PersonType ");
            sql.AppendFormat(" WHERE IDCard IN ( '{0}' ) ", IDCard);
            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter("@LastModifyDate", DateTime.Now));
            parm.Add(new SqlParameter("@PersonType", personType));
            return db.ExecuteNonQuery(sql.ToString(), parm.ToArray(), connectionStr);
        }

        /// <summary>
        /// 删除人员（逻辑删除）
        /// </summary>
        /// <param name="IDCard"></param>
        /// <returns></returns>
        public int DeletePersonnel(string IDCard)
        {
            IDCard = IDCard.Trim().Replace("|", "','");
            StringBuilder sql = new StringBuilder();
            sql.Append(" UPDATE dbo.Personnel Set ");
            sql.Append(" LastModifyDate = @LastModifyDate, ");
            sql.Append(" Flag = 0 ");
            sql.AppendFormat(" WHERE IDCard IN ( '{0}' ) ", IDCard);
            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter("@LastModifyDate", DateTime.Now));
            return db.ExecuteNonQuery(sql.ToString(), parm.ToArray(), connectionStr);
        }

        #endregion

        #region 进出记录

        /// <summary>
        /// 进出记录
        /// </summary>
        /// <returns></returns>
        public DataSet GetInOutRecod(int pageIndex, int pageSize, SearchValueInfo sInfo)
        {

            int start = (pageIndex - 1) * pageSize;
            string OrderBy = " ORDER BY r.InOutTime DESC ";
            StringBuilder condition = new StringBuilder();
            condition.Append(" WHERE r.Flag=1 ");
            //双击人员查询
            if (!string.IsNullOrEmpty(sInfo.IDCard))
            {
                condition.AppendFormat(" AND r.IDCard like '%{0}%' ", sInfo.IDCard);
            }
            if (!string.IsNullOrEmpty(sInfo.beginDate.PaseToString()))
            {
                condition.AppendFormat(" AND r.InOutTime >='{0}' ", sInfo.beginDate.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            if (!string.IsNullOrEmpty(sInfo.endDate.PaseToString()))
            {
                condition.AppendFormat(" AND r.InOutTime <='{0}' ", sInfo.endDate.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            if (!string.IsNullOrEmpty(sInfo.name.PaseToString()))
            {
                condition.AppendFormat(" AND p.Name like '%{0}%' ", sInfo.name);
            }
            if (!string.IsNullOrEmpty(sInfo.inOutType))
            {
                condition.AppendFormat(" AND r.InOutType='{0}' ", sInfo.inOutType);
            }

            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" SELECT top {0} ROW_NUMBER() OVER( {1} ) RowNumber ", pageSize, OrderBy);
            sql.Append(" ,r.InOutType ");
            sql.Append(" ,Code_IOType.CName as InOutTypeName ");
            sql.Append(" ,r.InOutTime ");
            sql.Append(" ,r.CompareResult ");
            sql.Append(" ,r.ThroughWay ");
            sql.Append(" ,r.SceneImage ");
            sql.Append(" ,Code_Tway.CName as ThroughWayName ");

            sql.Append(" ,p.Name,p.IDCard ");
            sql.Append(" FROM dbo.InOutRecord r ");
            sql.Append(" LEFT JOIN Personnel p ON p.IDCard=r.IDCard AND p.Flag=1 ");
            sql.Append(" Left join Code Code_IOType on Code_IOType.CodeID=r.InOutType and Code_IOType.KindCode='InOutType' ");
            sql.Append(" Left join Code Code_Tway on Code_Tway.CodeID=r.ThroughWay and Code_Tway.KindCode='ThroughWay' ");
            sql.Append(condition);
            sql.AppendFormat(" and r.DBID not in ( SELECT top {0} r.DBID from InOutRecord r  ", start);
            sql.AppendFormat(" LEFT JOIN Personnel p ON p.IDCard=r.IDCard AND p.Flag=1 {0} {1} ) {1} ", condition, OrderBy);
            sql.Append(" ; SELECT COUNT(1) ");
            sql.Append(" FROM dbo.InOutRecord r ");
            sql.Append(" LEFT JOIN Personnel p ON p.IDCard=r.IDCard AND p.Flag=1 ");
            sql.Append(condition);
            return db.GetDataSet(sql.ToString(), connectionStr);
        }
        #endregion

        /// <summary>
        /// 获取Code
        /// </summary>
        /// <param name="KindCode"></param>
        /// <returns></returns>
        public DataTable GetCode(string KindCode)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT CodeID, KindCode, CName, EName ");
            sql.Append(" FROM dbo.Code ");
            sql.AppendFormat(" WHERE Flag=1 AND KindCode='{0}' ", KindCode);
            sql.Append(" ORDER BY CodeID DESC ");
            return db.ExecuteReader(sql.ToString(), connectionStr);
        }

        #region 广告

        /// <summary>
        /// 上传广告
        /// </summary>
        /// <param name="FileName_Old"></param>
        /// <param name="FileName_New"></param>
        /// <returns></returns>
        public int InsertAD(string FileName_Old, string FileName_New)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" INSERT INTO dbo.Advertisement (IsPutIn, FileName_Old, FileName_New) ");
            sql.Append(" VALUES (0, @FileName_Old, @FileName_New) ");
            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter("@FileName_Old", FileName_Old));
            parm.Add(new SqlParameter("@FileName_New", FileName_New));
            return db.ExecuteNonQuery(sql.ToString(), parm.ToArray(), connectionStr);
        }

        /// <summary>
        /// 删除广告
        /// </summary>
        /// <param name="FileName_NewStr"></param>
        /// <returns></returns>
        public int DeleteAD(string FileName_NewStr)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" DELETE Advertisement WHERE FileName_New IN ('{0}') ", FileName_NewStr);
            return db.ExecuteNonQuery(sql.ToString(), connectionStr);
        }

        /// <summary>
        /// 获取广告列表
        /// </summary>
        /// <param name="IsPutIn"></param>
        /// <returns></returns>
        public DataTable GetADList(int IsPutIn)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT DBID, IsPutIn, FileName_Old, FileName_New ");
            sql.Append(" FROM dbo.Advertisement ");
            sql.AppendFormat(" WHERE IsPutIn={0} ", IsPutIn);
            return db.ExecuteReader(sql.ToString(), connectionStr);
        }

        #endregion

    }
}
