using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;

namespace MoleAssist
{
    static class ifcolor
    {
        /// <summary>
        /// 获得物品确定
        /// </summary>
        /// <param name="hwnd"></param>
        public static bool getgoods(IntPtr hwnd)
        {
            Bitmap a = Piccolor.GetWindow(hwnd);
            if(ColorTranslator.ToWin32(a.GetPixel(700,288)) == 1450723 && ColorTranslator.ToWin32(a.GetPixel(594, 411))== 16777215)
            {
                Common.Click(598, 414);
                //Todo：点击598,414
                return true;
            }
            a.Dispose();
            return false;
        }
        /// <summary>
        /// 关闭训练师窗口
        /// </summary>
        /// <param name="hwnd"></param>
        public static bool Closedata(IntPtr hwnd)
        {
            Bitmap a = Piccolor.GetWindow(hwnd);
            if (ColorTranslator.ToWin32(a.GetPixel(959, 95)) == 9665024 && ColorTranslator.ToWin32(a.GetPixel(552, 114)) == 6014655)
            {
                Common.Click(959,96);
                //Todo：点击959,96关闭按钮
                return true;
            }
            a.Dispose();
            return false;
        }
        /// <summary>
        /// 战斗结束点击确定
        /// </summary>
        /// <param name="hwnd"></param>
        public static bool fightend(IntPtr hwnd)
        {
            Bitmap a = Piccolor.GetWindow(hwnd);
            if (ColorTranslator.ToWin32(a.GetPixel(542, 196)) == 2866687 && ColorTranslator.ToWin32(a.GetPixel(603, 197)) == 3392255)
            {
                Common.Click(543, 469);
                //Todo：点击543,469确定按钮
                return true;
            }
            a.Dispose();
            return false;
        }
        /// <summary>
        /// 学会新技能或精灵进化确定
        /// </summary>
        /// <param name="hwnd"></param>
        public static bool skilllvup(IntPtr hwnd)
        {
            Bitmap a = Piccolor.GetWindow(hwnd);
            if (ColorTranslator.ToWin32(a.GetPixel(189, 222)) == 6908428 && ColorTranslator.ToWin32(a.GetPixel(587, 461)) == 16377170)
            {
                Common.Click(587, 469);
                //Todo：点击587,469确定按钮
                return true;
            }
            a.Dispose();
            return false;
        }
        /// <summary>
        /// 关闭在线时间提示
        /// </summary>
        /// <param name="hwnd"></param>
        public static bool Onlinetime(IntPtr hwnd)
        {
            Bitmap a = Piccolor.GetWindow(hwnd);
            if (ColorTranslator.ToWin32(a.GetPixel(409, 320)) == 14144823 && ColorTranslator.ToWin32(a.GetPixel(474, 283)) == 4819199)
            {
                Common.Click(809, 377);
                //Todo：点击809,377确定按钮
                return true;
            }
            a.Dispose();
            return false;
        }
        /// <summary>
        /// 判断首发精灵是否死亡
        /// </summary>
        /// <param name="hwnd"></param>
        public static bool GhostDie(IntPtr hwnd)
        {
            Bitmap a = Piccolor.GetWindow(hwnd);
            if (ColorTranslator.ToWin32(a.GetPixel(153, 103)) == 3418386)
            {
                Common.Click(260, 102);
                //Todo：点击260,102补血按钮
                return true;
            }
            a.Dispose();
            return false;
        }
        /// <summary>
        /// 寻找并点击野怪
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        public static bool FindAndCheckGhost(IntPtr hwnd)
        {
                Bitmap a = Piccolor.GetWindow(hwnd);
                Point xy = Piccolor.GetImageContains(a, global::MoleAssist.Properties.Resources.lv, 0);
                if (xy.X == -1)
                {
                    a.Dispose();
                    return false;
                }
                Common.Click(xy.X, xy.Y);
                a.Dispose();
                return true;
        }
        /// <summary>
        /// 传入自定义坐标
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void GhostXY(int x,int y)
        {
            Common.Click(x, y);
        }
        /// <summary>
        /// 判断是否进入战斗加载界面
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        public static bool IfcheckGhost(IntPtr hwnd)
        {
            Bitmap a = Piccolor.GetWindow(hwnd);         
            if (ColorTranslator.ToWin32(a.GetPixel(121, 3)) == 2890240)
            {
                a.Dispose();
                return true;
            }
            a.Dispose();
            return false;
        }
        /// <summary>
        /// 判断是否可以使用技能 tips:第一次用来是否进入战斗界面
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        public static bool IfFight(IntPtr hwnd)
        {
            Bitmap a = Piccolor.GetWindow(hwnd);
            if (ColorTranslator.ToWin32(a.GetPixel(327, 576)) == 14861418)
            {
                a.Dispose();
                return true;
            }
            a.Dispose();
            return false;
        }
        /// <summary>
        /// 判断是否出现验证框，返回-1代表没有出现验证框，返回1，2，3，4，代表需要点击那个位置，返回5代表验证库中找不到匹配数据
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        public static int IfVerify(IntPtr hwnd)
        {
            Bitmap a = Piccolor.GetWindow(hwnd);
            if (ColorTranslator.ToWin32(a.GetPixel(347, 219)) == 16776960 && ColorTranslator.ToWin32(a.GetPixel(516, 411)) == 3407871)
            {
                int key = int.Parse((ColorTranslator.ToWin32(a.GetPixel(418, 305))).ToString()+
                                    (ColorTranslator.ToWin32(a.GetPixel(418, 326))).ToString() +
                                    (ColorTranslator.ToWin32(a.GetPixel(418, 305))).ToString() +
                                    (ColorTranslator.ToWin32(a.GetPixel(418, 326))).ToString() +
                                    (ColorTranslator.ToWin32(a.GetPixel(418, 305))).ToString() +
                                    (ColorTranslator.ToWin32(a.GetPixel(418, 326))).ToString() +
                                    (ColorTranslator.ToWin32(a.GetPixel(418, 305))).ToString() +
                                    (ColorTranslator.ToWin32(a.GetPixel(418, 326))).ToString());
                if (Common.ht.ContainsKey(key))
                {
                    a.Dispose();
                    return int.Parse((string)Common.ht[key]);
                }
                else
                {
                    a.Dispose();
                    return 5;
                }
                
            }
            a.Dispose();
            return -1;
        }
        /// <summary>
        /// 使用技能
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="i">这里传技能号，没必杀技的自动使用1号技能</param>
        public static void skill(IntPtr hwnd, int i)
        {
            Bitmap a = Piccolor.GetWindow(hwnd);
            if (ColorTranslator.ToWin32(a.GetPixel(841, 585)) == 47821)
            {
                if (i == 1)
                {
                    Common.Click(356, 622);
                }
                else if (i == 2)
                {
                    Common.Click(498, 623);
                }
                else if (i == 3)
                {
                    Common.Click(640, 624);
                }
                else if (i == 4)
                {
                    Common.Click(774, 625);
                }
                else if (i == 5)
                {
                    Common.Click(928, 621);
                }
            }
            else
            {
                if (i == 1)
                {
                    Common.Click(353, 622);
                }
                else if (i == 2)
                {
                    Common.Click(548, 623);
                }
                else if (i == 3)
                {
                    Common.Click(737, 622);
                }
                else if (i == 4)
                {
                    Common.Click(932, 624);
                }
                else if (i == 5)
                {
                    Common.Click(353, 622);
                }

            }

        }
        /// <summary>
        /// 点击补血按钮
        /// </summary>
        public static void buxue()
        {
            Common.Click(260, 102);
        }
        /// <summary>
        /// 替换精灵
        /// </summary>
        /// <param name="hwnd"></param>
        public static void ReplaceGhost(IntPtr hwnd)
        {
            Common.Click(1134,619);
            //Todo:点击换场         1134,619
            Common.Click(463, 605);
            //Todo:点击第二位精灵   463,605
        }


        //public static void Bless(IntPtr hwnd)//-------------大地祝福确定
        //{
        //    Bitmap a = Piccolor.GetWindow(hwnd);
        //    if (a.GetPixel(662, 381) == "F9E552")
        //    {
        //        //Todo：点击663, 382确定按钮
        //    }
        //    a.Dispose();
        //}
    }
}
