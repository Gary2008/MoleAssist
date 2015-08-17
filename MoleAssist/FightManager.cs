using NLua;
using NLua.Exceptions;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace MoleAssist
{
    public enum FightType { Wild, NPC, CustomPoint };
    public struct FightOption
    {
        public IntPtr handle;
        /// <summary>
        /// Wild. 野怪
        /// NPC. NPC/忍者
        /// CustomPoint.自定义坐标
        /// </summary>
        public string type;
        /// <summary>
        /// 见窗口控件
        /// </summary>
        public int NPC;  
        public Point customPoint;
        public int interval;
        /// <summary>
        /// 0.单技能模式 1.多技能模式 见窗口控件
        /// </summary>
        public int skillMode;
        /// <summary>
        /// 含义见窗口控件
        /// </summary>
        public string skillOrder;
        public int identifyFailed;
        public bool ReHP;
        public bool useAnger;
        public bool alert;
        public bool qucikTraining;
        public bool couldHiddenMode;
    };
    public class FightManager : IDisposable
    {
        private Lua state_ = null;
        private string luaScript_ = null;

        public bool IsFighting { get; protected set; }
        public FightOption FightOptions;

        public FightManager(string lua) {
            IsFighting = false;
            luaScript_ = lua;
            InitLua();
            callLua(luaScript_);
        }

        /// <summary>
        /// 初始化Lua解释器
        /// </summary>
        private void InitLua()
        {
            if (state_ != null)
            {
                //已初始化
                return ;
            }
            state_ = new Lua();
            //LUA初始化
            state_.LoadCLRPackage();
            callLua(@"import ('System')
import ('System.Windows.Forms')
import ('System.Drawing')");
            //TODO: 注册LUA函数
            RegisterMethodsAsFunction( typeof(Common) );
            RegisterMethodsAsFunction( typeof(Piccolor) );

        }

        /// <summary>
        /// 将类方法作为lua函数注册
        /// </summary>
        /// <param name="classInfo">类信息，使用typeof(className)获取</param>
        /// <returns></returns>
        public bool RegisterMethodsAsFunction(Type classInfo)
        {
            if (state_ == null)
            {
                return false;
            }
            MethodInfo[] methods = classInfo.GetMethods();
            foreach (MethodInfo m in methods)
            {
                if (m.IsDefined(typeof(LuaFunction), true))
                {
                    var attr = Common.GetCustomAttribute<LuaFunction>(m);
                    string luaFuncName = attr.FunctionName != null ? attr.FunctionName : m.Name; //如未指定lua函数名，默认使用c#方法名注册
                    Common.Trace("注册Lua函数"+ luaFuncName + "（From " + classInfo.Name + "）：" +  Common.StrMethodInfo(m));
                    state_.RegisterFunction(luaFuncName, m);
                }
            }
            return true;
        }

        /// <summary>
        /// 调用Lua执行指定脚本
        /// </summary>
        /// <param name="script">要执行的脚本</param>
        /// <returns>执行结果，需自行转换对象类型</returns>
        public object[] callLua(string script)
        {
            try
            {
                return state_.DoString(script);
            }
            catch (LuaScriptException e)
            {
                MessageBox.Show("LuaScriptException : " + e.Message, "脚本异常");
                return null;
            }catch (LuaException e)
            {
                MessageBox.Show("LuaException :" + e.Message, "Lua异常");
                throw;
            }
        }

        /// <summary>
        /// 通知Lua开始战斗
        /// </summary>
        /// <param name="type">战斗类型</param>
        /// <returns></returns>
        public bool Start() {
            if (IsFighting)
            {
                return false;
            }
            IsFighting = true;
            //TODO: 传入对象
            state_["Settings"] = Common.settings;
            state_["FightOptions"] = this.FightOptions;
            //TODO: start fight processing
            callLua("StartFight()");

            return true;
        }

        /// <summary>
        /// 通知Lua停止战斗
        /// </summary>
        /// <returns></returns>
        public bool Stop()
        {
            if (!IsFighting)
            {
                return true;
            }
            IsFighting = false;

            //TODO: stop fight processing
            callLua("StopFight()");

            return true;
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                    if (state_　!= null)
                    {
                        state_.Close();
                    }

                }
                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。
                disposedValue = true;

            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
         ~FightManager() {
           // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
           Dispose(false);
         }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
