#define openLocalConfig
using System;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Windows.Forms;
using System.Xml;

namespace Config
{
    public enum Item { Functions, Lua };
    public static class ConfigManager
    {
        private const string DEFAULT_REMOTE = "http://7xl2db.dl1.z0.glb.clouddn.com";

        private static readonly string ProductVersion;
        private static readonly string AssemblyVersion;


        private static string remote_ = null;  //结尾必需不包含斜杠
        private static bool loaded_ = false;
        private static XmlDocument xmldoc_;

        static ConfigManager()
        {
            ProductVersion = System.Windows.Forms.Application.ProductVersion.ToString();
            AssemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            xmldoc_ = new XmlDocument();
#if DEBUG && openLocalConfig
            string local =  Directory.GetCurrentDirectory() + "/LocalConfig" ;
            if (Directory.Exists(local))
                Load("file:///" + local);
#endif
        }

        public static bool IsLoaded()
        {
            return loaded_;
        }

        public static bool Load(string remote = DEFAULT_REMOTE)
        {
            try
            {
                remote_ = remote;
                StreamReader reader = new StreamReader(Request("/config.xml").GetResponseStream());
                Parse(reader.ReadToEnd());
                loaded_ = true;
                return true;
            }
            catch (ConfigException e)
            {
                if (e is ConfigFetchException)
                {
                    MessageBox.Show("获取配置文件失败" + "\n" + e.Message);
                    Environment.Exit(0);
                }
                if (e is ConfigParseException)
                {
                    MessageBox.Show("解析配置文件失败" + "\n" + e.Message);
                    Environment.Exit(0);
                }
                throw;
            }
        }


        public static string Get(Item item)
        {
            if (!loaded_)
                Load();
            //TODO: 返回配置项
            if (item == Item.Lua)
            {
                return "1+1";
            }
            throw new NotImplementedException();
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

        public static string Get(string item, string name)
        {
            if (!loaded_)
                Load();
            //TODO: 返回配置项
            
            throw new NotImplementedException();
        }

        private static void Parse(string xml)
        {
            try
            {
                xmldoc_.LoadXml(xml);
                //TODO: other parsing things

            }
            catch (XmlException e)
            {
                throw new ConfigParseException("配置文件解析失败", e);
            }

        }

        private static WebResponse Request(string requestFile)
        {
            try
            {
                dynamic request = null;
                string protocol = remote_.Substring(0, remote_.IndexOf("://"));
                switch (protocol)
                {
                    case "http":
                    case "https":
                        request = WebRequest.Create(remote_ + requestFile) as HttpWebRequest;
                        request.UserAgent = "MoleAssist ( " + ProductVersion + ";" + AssemblyVersion + " )";
                        break;
                    case "ftp":
                        request = WebRequest.Create(remote_ + requestFile) as FtpWebRequest;
                        break;
                    case "file":
                        request = WebRequest.Create(remote_ + requestFile) as FileWebRequest;
                        break;
                    default:
                        throw new Exception("Your mother boom");
                        break;
                }
                request.Method = "GET";
                request.Timeout = 10 * 1000;
                request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.Revalidate);
                WebResponse response = request.GetResponse();
                return response;
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse response = (HttpWebResponse) e.Response;
                    throw new ConfigFetchException( string.Format("ProtocolError {0} ( {1} )", (int)response.StatusCode, response.StatusDescription) , e);
                }
                throw new ConfigFetchException("UnkownError", e);
            }
        }

    }
}
