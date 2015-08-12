using System;
using System.Net;
using System.Net.Cache;
using System.Xml;

namespace MoleAssist
{
    
    public static class ConfigManager
    {
        private const string DEFAULT_REMOTE = "http://7xl2db.dl1.z0.glb.clouddn.com";
        private static readonly string ProductVersion = System.Windows.Forms.Application.ProductVersion.ToString();
        private static readonly string AssemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        private static string remote_ = null;  //结尾必需不包含斜杠
        private static bool loaded_ = false;

        static ConfigManager()
        {
            
        }

        public static bool IsLoaded()
        {
            return loaded_;
        }

        public static bool Load(string remote = DEFAULT_REMOTE)
        {
            remote_ = remote;
            if ( !Parse( Request("/config.xml").GetResponseStream().ToString() ) )
            {
                return false;
            }
            loaded_ = true;
            return true;
        }

        public static string Get(uint id)
        {
            if (!loaded_)
                Load();
            //TODO: 返回配置项

            throw new NotImplementedException();
        }

        public static string Get(string item)
        {
            if (!loaded_)
                Load();
            //TODO: 返回配置项

            throw new NotImplementedException();
        }

        private static bool Parse(string xml)
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc.LoadXml(xml);
            //TODO: 解析XML并存储转存信息

            throw new NotImplementedException();
        }

        private static HttpWebResponse Request(string RequestFile)
        {
            HttpWebRequest request = WebRequest.Create(remote_ + RequestFile) as HttpWebRequest;
            request.Method = "GET";
            request.Timeout = 10 * 1000;
            request.CachePolicy =  new HttpRequestCachePolicy(HttpRequestCacheLevel.Revalidate);
            request.UserAgent = "MoleAssist ( " + ProductVersion + ";"+ AssemblyVersion + " )";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            return response;
        }

    }
}
