using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.ComponentModel;
using System.Reflection;
using Common;

namespace Server
{
    public static class ServerConfig
    {
        //public static string connectionStrings;//数据库连接

        #region new
        public static string path = System.Environment.CurrentDirectory;
        public static string fileName = "BaseConfig.xml";

        private static string _connectionStrings = @"server=BANANA\MSSQLSERVER2014;uid=sa;pwd=Sa123456;database=wzjy";
        [Description("服务端数据库连接")]
        public static string connectionStrings { set { _connectionStrings = value; } get { return _connectionStrings; } }

        private static string _DataServer = @"192.168.1.9\MSSQLSERVER2014";
        [Description("服务端数据库")]
        public static string DataServer { set { _DataServer = value; } get { return _DataServer; } }

        private static string _DataBase = "wzjy";
        [Description("服务端数据库名称")]
        public static string DataBase { set { _DataBase = value; } get { return _DataBase; } }

        private static string _DataUser = "sa";
        [Description("服务端数据库用户名")]
        public static string DataUser { set { _DataUser = value; } get { return _DataUser; } }

        private static string _DataPwd = "Sa123456";
        [Description("服务端数据库用户名")]
        public static string DataPwd { set { _DataPwd = value; } get { return _DataPwd; } }

        #endregion


        private static FileSystemWatcher watcher;

        public static void LoadConfig()
        {
            try
            {
                string filePath = path + @"\" + fileName;
                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    Updata();
                }
                else
                {
                    Create();
                }

                if (null != watcher) watcher.Dispose();
                watcher = new FileSystemWatcher(System.Environment.CurrentDirectory, ".xml");//EXE运行路径
                watcher.NotifyFilter = NotifyFilters.LastWrite;
                watcher.Changed += Watcher_Changed;
                watcher.EnableRaisingEvents = true;

            }
            catch (Exception ex)
            {
                //CConfig.SaveLog("CConfig.LoadConfig() fail,error:" + ex.Message);
                Environment.Exit(-1);
            }
        }

        private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                watcher.EnableRaisingEvents = false;
                Updata();
                watcher.EnableRaisingEvents = true;
            }
        }


        /// <summary>
        /// 加载配置文件
        /// </summary>
        private static void Updata()
        {
            string filePath = path + @"\" + fileName;
            XmlDocument xml = new XmlDocument();
            if (!File.Exists(filePath))
            {
                throw new Exception("配置文件不存在，路径：" + filePath);
            }
            xml.Load(filePath);

            PropertyInfo[] myproperties = typeof(ServerConfig).GetProperties();
            foreach (PropertyInfo property in myproperties)
            {
                string name = property.Name;
                string remark = string.Empty;
                //string value = property.GetValue(property, null).PaseToString();
                if (xml.GetElementsByTagName(name).Count > 0)
                {
                    //value = xml.DocumentElement[name].InnerText.Trim();
                    property.SetValue(property, Convert.ChangeType(xml.DocumentElement[name].InnerText.Trim(), property.PropertyType), null);
                }
                else
                {
                    property.SetValue(property, property.GetValue(property, null), null);
                }

            }
        }

        /// <summary>
        /// 创建配置文件
        /// </summary>
        private static void Create()
        {
            string filePath = path + @"\" + fileName;
            XmlDocument xmlDoc = new XmlDocument();
            //创建类型声明节点  
            XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "");
            xmlDoc.AppendChild(node);
            //创建根节点  
            XmlNode root = xmlDoc.CreateElement("ServerConfig");
            xmlDoc.AppendChild(root);
            PropertyInfo[] myproperties = typeof(ServerConfig).GetProperties();
            foreach (PropertyInfo property in myproperties)
            {
                string name = property.Name;
                string value = property.GetValue(property, null).PaseToString();
                string remark = string.Empty;
                object[] objs = property.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (objs.Length > 0)
                {
                    remark = ((DescriptionAttribute)objs[0]).Description;
                }
                CreateNode(xmlDoc, root, name, value, remark);
            }
            xmlDoc.Save(filePath);
        }

        /// <summary>    
        /// 创建节点    
        /// </summary>    
        /// <param name="xmldoc"></param>  xml文档  
        /// <param name="parentnode"></param>父节点    
        /// <param name="name"></param>  节点名  
        /// <param name="value"></param>  节点值  
        ///   
        public static void CreateNode(XmlDocument xmlDoc, XmlNode parentNode, string name, string value, string remark)
        {
            XmlNode node = xmlDoc.CreateNode(XmlNodeType.Element, name, null);

            XmlComment comment = xmlDoc.CreateComment(remark);
            node.InnerText = value;
            parentNode.AppendChild(node);
            parentNode.InsertBefore(comment, node);
        }


    }
}
