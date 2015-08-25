using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using Config;

namespace MoleAssist
{
    static class ifcolor
    {
        static IntPtr hwnd;
        static Bitmap a;
        public static void fuck(IntPtr hwnd)
        {
            ifcolor.hwnd = hwnd;
            rebitmap();
        }
        public static void rebitmap()
        {
            if ( ifcolor.a != null)
            {
                //释放旧Bitmap
                ifcolor.a.Dispose();
            }
            //新Bitmap
            ifcolor.a = Piccolor.GetWindow(hwnd);
        }
        /// <summary>
        /// 获得物品确定
        /// </summary>
        /// <param name="hwnd"></param>
        [LuaFunction(Prefix: "FightCall_")]
        public static bool GetGoods()
        {
            if(ColorTranslator.ToWin32(ifcolor.a.GetPixel(700,288)) == 1450723 && ColorTranslator.ToWin32(ifcolor.a.GetPixel(594, 411))== 16777215)
            {
                Common.Click(598, 414);
                //Todo：点击598,414
                return true;
            }
            return false;
        }
        /// <summary>
        /// 关闭训练师窗口
        /// </summary>
        /// <param name="hwnd"></param>
        [LuaFunction(Prefix: "FightCall_")]
        public static bool Profile()
        {
            if (ColorTranslator.ToWin32(ifcolor.a.GetPixel(213, 311)) == 16777011 && ColorTranslator.ToWin32(ifcolor.a.GetPixel(983, 304)) == 16777011)
            {
                Common.Click(959,96);
                //Todo：点击959,96关闭按钮
                return true;
            }
            return false;
        }
        /// <summary>
        /// 战斗结束点击确定
        /// </summary>
        /// <param name="hwnd"></param>
        [LuaFunction(Prefix: "FightCall_")]
        public static bool FightEnd()
        {
            if (ColorTranslator.ToWin32(ifcolor.a.GetPixel(542, 196)) == 2866687 && ColorTranslator.ToWin32(ifcolor.a.GetPixel(603, 197)) == 3392255)
            {
                 Common.Click(543, 469);
                //Todo：点击543,469确定按钮
                return true;
            }
            return false;
        }
        /// <summary>
        /// 学会新技能或精灵进化确定
        /// </summary>
        /// <param name="hwnd"></param>
        [LuaFunction(Prefix: "FightCall_")]
        public static bool SkillLvUp()
        {
            if (ColorTranslator.ToWin32(ifcolor.a.GetPixel(189, 222)) == 6908428 && ColorTranslator.ToWin32(ifcolor.a.GetPixel(587, 461)) == 16377170)
            {
                Common.Click(587, 469);
                //Todo：点击587,469确定按钮
                return true;
            }
            return false;
        }
        /// <summary>
        /// 关闭在线时间提示
        /// </summary>
        /// <param name="hwnd"></param>
        [LuaFunction(Prefix: "FightCall_")]
        public static bool OnlineTime()
        {
            if (ColorTranslator.ToWin32(ifcolor.a.GetPixel(409, 320)) == 14144823 && ColorTranslator.ToWin32(ifcolor.a.GetPixel(474, 283)) == 4819199)
            {
                Common.Click(809, 377);
                //Todo：点击809,377确定按钮
                return true;
            }
            return false;
        }
        /// <summary>
        /// 判断首发精灵是否死亡
        /// </summary>
        /// <param name="hwnd"></param>
        [LuaFunction(Prefix: "FightCall_")]
        public static bool PetDie()
        {
            if (ColorTranslator.ToWin32(ifcolor.a.GetPixel(153, 103)) == 3418386)
            {
                Common.Click(260, 102);
                //Todo：点击260,102补血按钮
                return true;
            }
            return false;
        }
        /// <summary>
        /// 寻找并点击野怪
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        [LuaFunction(Prefix: "FightCall_")]
        public static bool FindAndClickMonster()
        {
                Point xy = Piccolor.GetImageContains(a, global::MoleAssist.Properties.Resources.lv, 0);
                if (xy.X == -1)
                {
                    return false;
                }
                Common.Click(xy.X, xy.Y);
                return true;
        }
        /// <summary>
        /// 寻找并点击野怪
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        [LuaFunction(Prefix: "FightCall_")]
        public static bool NONONO()
        {
            if (ColorTranslator.ToWin32(ifcolor.a.GetPixel(568, 416)) == 15855521 && ColorTranslator.ToWin32(ifcolor.a.GetPixel(657, 416)) == 15855521)
            {
                Common.Click(1094, 221);
                //Todo：点击1094,221
                return true;
            }
            return false;

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
        [LuaFunction(Prefix: "FightCall_" , FuncName: "isFightLoading" )]
        public static bool IfcheckGhost()
        {    
            if (ColorTranslator.ToWin32(ifcolor.a.GetPixel(121, 3)) == 2890240)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 判断是否可以使用技能 tips:第一次用来是否进入战斗界面
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        [LuaFunction(Prefix: "FightCall_", FuncName: "couldUseSkill")]
        public static bool IfFight()
        {
            if (ColorTranslator.ToWin32(ifcolor.a.GetPixel(327, 576)) == 14861418 || ColorTranslator.ToWin32(ifcolor.a.GetPixel(515, 576)) == 14861418)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 判断是否出现验证框，返回-1代表没有出现验证框，返回1代表匹配到并点击，返回2代表匹配不到并已经上传到空间
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        [LuaFunction(Prefix: "FightCall_", FuncName: "hasVerify")]
        public static int IfVerify()
        {
            if (ColorTranslator.ToWin32(ifcolor.a.GetPixel(347, 219)) == 16776960 && ColorTranslator.ToWin32(ifcolor.a.GetPixel(516, 411)) == 3407871)
            {
                int key =ColorTranslator.ToWin32(ifcolor.a.GetPixel(418, 305)) +
                         ColorTranslator.ToWin32(ifcolor.a.GetPixel(418, 326)) +
                         ColorTranslator.ToWin32(ifcolor.a.GetPixel(529, 305)) +
                         ColorTranslator.ToWin32(ifcolor.a.GetPixel(529, 326)) +
                         ColorTranslator.ToWin32(ifcolor.a.GetPixel(654, 305)) +
                         ColorTranslator.ToWin32(ifcolor.a.GetPixel(654, 326)) +
                         ColorTranslator.ToWin32(ifcolor.a.GetPixel(793, 305)) +
                         ColorTranslator.ToWin32(ifcolor.a.GetPixel(793, 326));
                if (ConfigManager.hashTable.ContainsKey(key))
                {
                    switch ((int) ConfigManager.hashTable[key])
                    {
                        case 1:
                            Common.Click(418, 305);
                            break;
                        case 2:
                            Common.Click(529, 305);
                            break;
                        case 3:
                            Common.Click(654, 305);
                            break;
                        case 4:
                            Common.Click(793, 305);
                            break;
                    }

                    return 1;
                }
                else
                {
                    string path = System.IO.Path.GetTempPath() + key + ".jpg";
                    Bitmap b = Piccolor.cut(ifcolor.a);
                    b.Save(path);
                    Common.SendFile(path);
                    b.Dispose();
                    return 2;
                }
                
            }
            return -1;
        }
        /// <summary>
        /// 使用技能
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="i">这里传技能号，没必杀技的自动使用1号技能</param>
        [LuaFunction(Prefix: "FightCall_", FuncName: "UseSkill")]
        public static void skill(int i)
        {
            if (ColorTranslator.ToWin32(ifcolor.a.GetPixel(841, 585)) == 47821)
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
        [LuaFunction(Prefix: "FightCall_", FuncName: "FullHP")]
        public static void buxue()
        {
            Common.Click(260, 102);
        }
        /// <summary>
        /// 替换精灵
        /// </summary>
        /// <param name="hwnd"></param>
        [LuaFunction(Prefix: "FightCall_", FuncName: "ReplacePet")]
        public static void ReplaceGhost()
        {
            if (ColorTranslator.ToWin32(ifcolor.a.GetPixel(428, 645)) == 16315888)
            {
                Common.Click(463, 605);
                //Todo:点击第二位精灵   463,605
            }
            else
            {
                Common.Click(1134, 619);
                //Todo:点击换场         1134,619
            }
        }
    }
}
