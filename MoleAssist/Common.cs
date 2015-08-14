using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MoleAssist
{
    public static partial class Common
    {
        internal static MoleAssist.Properties.Settings settings { get { return MoleAssist.Properties.Settings.Default; } }
        public static bool Start()
        {
            return true;
        }
        public static string HelloWorld()
        {
            return "HelloWorld";
        }
        public static void Trace(string str)
        {
            System.Diagnostics.Trace.WriteLine(str);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true ) ]
        private static extern Int32 MessageBox(
        IntPtr hWnd,
        string lpText,
        string lpCaption,
        uint uType
        );
        public static void MsgBox(string str, string caption = "")
        {
            MessageBox((IntPtr)0, str, caption, 0);
        }
    }
}
