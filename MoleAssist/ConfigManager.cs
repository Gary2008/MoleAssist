#define LocalConfig
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Common = MoleAssist.Common;

namespace Config
{
    public enum Item { All, Functions, BlackList };
    public enum Functions { AutoFight, Notice };
    public struct BlackListItem
    {
        public override bool Equals(Object obj)
        {
            return obj is BlackListItem && this == (BlackListItem)obj;
        }
        public override int GetHashCode()
        {
            return type.GetHashCode() ^ id.GetHashCode();
        }
        public static bool operator ==(BlackListItem x, BlackListItem y)
        {
            return x.type == y.type && x.id == y.id;
        }
        public static bool operator !=(BlackListItem x, BlackListItem y)
        {
            return !(x == y);
        }
        public string type { get; set; }
        public string id { get; set; }
        public string reason { get; set; }
    }
    public static class ConfigManager
    {
        private const string DEFAULT_REMOTE = "http://7xl2db.dl1.z0.glb.clouddn.com";

        private static readonly string ProductVersion = System.Windows.Forms.Application.ProductVersion.ToString();
        private static readonly string AssemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();


        private static string remote_ = DEFAULT_REMOTE;  //结尾必需不包含斜杠
        private static bool loaded_ = false;
        private static readonly XmlDocument xmlDoc_ = new XmlDocument();
        private static XmlNode xmlRoot_;
        public static Hashtable hashTable = new Hashtable();

        static ConfigManager()
        {
            Load();
        }

        public static bool IsLoaded()
        {
            return loaded_;
         }

        public static bool Load()
        {
            return Load(DEFAULT_REMOTE);
        }
        public static bool Load(string remote)
        {
            try
            {
#if DEBUG && LocalConfig
                string local = Directory.GetCurrentDirectory() + "\\LocalConfig";
                if (Directory.Exists(local))
                {
                    Common.Trace("检测到本地配置：" + local);
                    remote = "file:///" + local;
                }
#endif
                remote_ = remote;

                StreamReader reader;
                {
                    reader = new StreamReader(Request("/config.xml").GetResponseStream());
                    Parse(reader.ReadToEnd());
                    reader.Dispose();
                }
                {
                    reader = new StreamReader(Request("/verify.xml").GetResponseStream());
                    ParseVerify(reader.ReadToEnd());
                    //reader.Dispose();
                }
                loaded_ = true;
                return true;
            }
            catch (ConfigException e)
            {
                if (e is ConfigFetchException)
                {
                    MessageBox.Show("获取配置文件失败\n" + e.Message + "\n" + e.StackTrace);
                    Environment.Exit(0);
                }
                if (e is ConfigParseException)
                {
                    MessageBox.Show("解析配置文件失败\n" + e.Message + "\n" + e.StackTrace);
                    Environment.Exit(0);
                }
                throw;
            }
            catch (Exception e)
            {
                MessageBox.Show("初始化配置失败 \n" + e.Message  + "\n" + e.StackTrace);
                throw;
            }
        }

        public static XmlNodeList AllNodes
        {
            get
            {
                if (!loaded_)
                {
                    Load();
                }
                return xmlRoot_.ChildNodes;
            }

        }

        public static string LuaScript
        {
            get
            {
                try
                {
                    if (!loaded_)
                    {
                        Load();
                    }
                    string luaUri = xmlRoot_.SelectSingleNode("lua").InnerText;
                    StreamReader reader = new StreamReader(Request(luaUri).GetResponseStream());
                    char[] buffer = new char[3];
                    reader.ReadBlock(buffer, 0, 3);
                    if (buffer[0] == 14 && buffer[1] == 146 && buffer[2] == 250)
                    {
                        return DESEncrypt.Decrypt(reader.ReadToEnd());
                    }
                    return new string(buffer) + reader.ReadToEnd();
                }
                catch (ConfigException e)
                {
                    MessageBox.Show("配置出现异常\n" + e.Message);
                    Environment.Exit(0);
                    throw;
                }
            }
        }

        /// <summary>
        /// 获取指定配置项
        /// Item.All ：      返回根节点的子节点列表 List<XmlNode>
        /// Item.Functions ：返回可用功能列表 List<Config.Functions>
        /// Item.BlackList ：返回黑名单列表  List<BlackListInfo>
        /// </summary>
        /// <param name="item">要获取的配置</param>
        /// <returns>返回值类型根据参数item不同而不同</returns>
        public static object Get(Item item)
        {
            if (!loaded_)
            {
                Load();
            }

            switch (item)
            {
                case Item.All:
                    return ConvertToList(xmlRoot_.SelectSingleNode("config").GetEnumerator(),
                        (XmlNode node, out XmlNode ret) => {
                            ret = node;
                            return true;
                        });
                case Item.Functions:
                    return ConvertToList(xmlRoot_.SelectSingleNode("function").GetEnumerator(),
                        (XmlNode node, out Functions ret) => {
                            ret = (Config.Functions)Enum.Parse(typeof(Config.Functions), node.Name);
                            return Get(node, "enabled", "false") == "true";
                        });
                case Item.BlackList:
                    return ConvertToList(xmlRoot_.SelectSingleNode("list/balck").GetEnumerator(),
                        (XmlNode node, out BlackListItem ret) => {
                            XmlAttributeCollection attrs = node.Attributes;
                            ret = new BlackListItem { type = attrs.GetNamedItem("type").InnerText,
                                id = attrs.GetNamedItem("id").InnerText,
                                reason = attrs.GetNamedItem("reason").InnerText,
                            };
                            return true;
                        });
                default:
                    throw new ConfigParseException("Try to get an unkown Item");
            }

        }
        private delegate bool ConvertCallBack<T>(XmlNode node, out T ret);
        private static List<T> ConvertToList<T>(System.Collections.IEnumerator ienum, ConvertCallBack<T> callback)
        {
            List<T> result = new List<T> { };
            while (ienum.MoveNext())
            {
                XmlNode node = ienum.Current as XmlNode;
                T ret;
                if (callback(node, out ret))
                {
                    result.Add(ret);
                }
            }
            return result;
        }

        public static object Get(string item)
        {
            return Get((Item)Enum.Parse(typeof(Item), item));
        }

        public static XmlNode Get(string item, string name)
        {
            if (!loaded_)
            {
                Load();
            }
            return xmlRoot_.SelectSingleNode(item + "/" + name);
        }

        public static string Get(XmlNode item, string attr)
        {
            return Get(item, attr, null);
        }

        /// <summary>
        /// 获取指定配置节点的属性
        /// </summary>
        /// <param name="item">xml节点类</param>
        /// <param name="attr">属性名称</param>
        /// <param name="def">无此属性时返回值</param>
        /// <returns></returns>
        public static string Get(XmlNode item, string attr, string def)
        {
            XmlNode t = item.Attributes.GetNamedItem(attr);
            if (t == null)
            {
                return def;
            }
            return t.InnerText;
        }

        private static void Parse(string xml)
        {
            try
            {
                xmlDoc_.LoadXml(xml);
                xmlRoot_ = xmlDoc_.SelectSingleNode("config");
            }
            catch (XmlException e)
            {
                throw new ConfigParseException(string.Format("配置文件解析失败 {0} ", xml), e);
            }

        }
        private static void ParseVerify(string xml)
        {
            try
            {
                var doc = new XmlDocument();
                doc.LoadXml(xml);
                XmlNodeList nodes = doc.SelectNodes("verify/item");
                foreach (XmlElement node in nodes)
                {
                    int key = int.Parse(node.GetAttribute("key"));
                    int value = int.Parse(node.GetAttribute("value"));
                    hashTable.Add(key, value);
                }
            }
            catch (XmlException e)
            {
                throw new ConfigParseException(string.Format("配置文件解析失败 {0} ", xml), e);
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
                        throw new ConfigFetchException("UnkownProtocol");
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
                    HttpWebResponse response = (HttpWebResponse)e.Response;
                    throw new ConfigFetchException(string.Format(@"ProtocolError
Status: {0} ( {1} ) 
File: {2}", (int)response.StatusCode, response.StatusDescription, requestFile), e);
                }
                throw new ConfigFetchException("UnkownError: " + e.Message, e);
            }
        }

    }
    public static class DESEncrypt
    {

        /// <summary>
        /// DES对称加密的密钥 
        /// </summary>
        private const string key = "YourMotherBoom";

        public static string Encrypt(string encryptString)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key.Substring(0, 8));
            byte[] keyIV = keyBytes;
            byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, provider.CreateEncryptor(keyBytes, keyIV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Convert.ToBase64String(mStream.ToArray());
        }
        public static string Decrypt(string decryptString)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key.Substring(0, 8));
            byte[] keyIV = keyBytes;
            byte[] inputByteArray = Convert.FromBase64String(decryptString);
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, provider.CreateDecryptor(keyBytes, keyIV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Encoding.UTF8.GetString(mStream.ToArray());
        }
    }
}
