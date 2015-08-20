using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace MoleAssist
{
    public static partial class Common
    {
        /// <summary>
        /// 程序设置
        /// </summary>
        internal static Properties.Settings settings { get { return MoleAssist.Properties.Settings.Default; } }
        internal static IntPtr hGame;

        /// <summary>
        /// 将指定方法的信息转换为字符串返回
        /// </summary>
        /// <param name="m">方法信息</param>
        /// <returns>返回字符串形式的方法信息</returns>
        public static string StrMethodInfo(MethodBase m)
        {
            string result = "";
            IEnumerator enumerator = m.GetParameters().GetEnumerator();
            result += m.Name + ": { ";
            while (enumerator.MoveNext())
            {
                var cur = (ParameterInfo)enumerator.Current;
                result += cur.ParameterType + " " + cur.Name + ", ";
            }
            result += "}";
            return result;
        }

        /// <summary>
        /// 获取指定的自定义Attribute
        /// </summary>
        /// <typeparam name="T">自定义Attribute类型</typeparam>
        /// <param name="info">要获取Attribute的对象信息</param>
        /// <returns>自定义Attribute</returns>
        public static T GetCustomAttribute<T>(MemberInfo info) where T : Attribute
        {
            object[] attributes = info.GetCustomAttributes(typeof(T), false);
            foreach (object attribute in attributes)
            {
                if (attribute is T)
                    return (T)attribute;
            }
            return null;
        }

        [LuaFunction]
        public static string HelloWorld()
        {
            return "HelloWorld";
        }

        /// <summary>
        /// 输出调试信息
        /// </summary>
        /// <param name="str">调试信息文本</param>
        [LuaFunction]
        public static void Trace(string str)
        {
#if TRACE
            System.Diagnostics.Trace.WriteLine(str);
#endif
        }
        [LuaFunction]
        public static void MsgBox(string str, string caption = "")
        {
            System.Windows.Forms.MessageBox.Show(str, caption);
        }
        [LuaFunction]
        [DllImport("user32.dll", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true ) ]
        private static extern int PostMessage(
            IntPtr hWnd,
            uint msg,
            IntPtr wParam,
            IntPtr lParam
            );
        public static void Click(IntPtr hWnd, Point p)
        {
            const uint WM_LBUTTONDOWN = 0x0201;
            const uint WM_LBUTTONUP = 0x202;
            IntPtr MK_LBUTTON = new IntPtr(0x0001);
            PostMessage(hWnd, WM_LBUTTONDOWN, MK_LBUTTON, mklong(p.X, p.Y));
            PostMessage(hWnd, WM_LBUTTONUP, MK_LBUTTON, mklong(p.X, p.Y));
        }
        [LuaFunction]
        public static void Click(int x, int y)
        {
            Click(hGame ,new Point(x,y));
        }
        public static IntPtr mklong(int a, int b)
        {
            return new IntPtr (a + (b << 16));
        }
        public delegate bool ChildWindowProcessCallBack(IntPtr hwnd, out IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int EnumChildWindows(IntPtr hWndParent, ChildWindowProcessCallBack lpfn, out IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int GetClassName(IntPtr hWnd, IntPtr ClassNameBuffer, int MaxCount);
        public static bool ChildWindowProcess(IntPtr hwnd, out IntPtr lParam)
        {
            const string FLASHCLASSNAME = "MacromediaFlashPlayerActiveX";
            const int len = 256;
            IntPtr pBuffer = Marshal.AllocHGlobal(len);
            GetClassName(hwnd, pBuffer, len);
            string ClassName = Marshal.PtrToStringAuto(pBuffer);
            if (ClassName == FLASHCLASSNAME)
            {
                lParam = hwnd;
                return false;
            }
            Marshal.FreeHGlobal(pBuffer);
            lParam = IntPtr.Zero;
            return true;
        }
        public static bool UpdateFlashHandle(IntPtr parentWindow)
        {
            IntPtr h;

            EnumChildWindows(parentWindow, new ChildWindowProcessCallBack(ChildWindowProcess), out h );
            hGame = h;
            return h != IntPtr.Zero;
        }
        /// <summary>
        /// 上传jpg到空间
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="uri"></param>
        /// <param name="encodingType"></param>
        /// <returns></returns>
        public static string SendFile(string fileName, string encodingType = "UTF-8")
        {
            using (WebClient myWebClient = new WebClient())
            {
                byte[] responseArray = myWebClient.UploadFile("http://updata.xyh968200.goodrain.net/upload_file.php", "POST", fileName);
                return Encoding.GetEncoding(encodingType).GetString(responseArray);
            }
        }



    }
}
