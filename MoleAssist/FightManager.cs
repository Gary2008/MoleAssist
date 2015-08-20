using NLua;
using NLua.Exceptions;
using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Reflection;
using System.Threading;
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

        public bool IsFighting { get; protected set; }
        public FightOption FightOptions;


        private enum LuaMsgType { Do, Start, Destory  };
        private struct LuaMsg{
            public override bool Equals(Object obj)
            {
                return obj is LuaMsg && this == (LuaMsg)obj;
            }
            public override int GetHashCode()
            {
                return type.GetHashCode() ^ param.GetHashCode();
            }
            public static bool operator ==(LuaMsg x, LuaMsg y)
            {
                return x.type == y.type && x.param == y.param;
            }
            public static bool operator !=(LuaMsg x, LuaMsg y)
            {
                return !(x == y);
            }
            public LuaMsg(LuaMsgType type, object[] param = null)
            {
                this.type = type;
                this.param = param;
            }
            public LuaMsgType type { get; set; }
            public object[] param { get; set; }
    }
        /// 代表Lua解释器是否初始化完成
        private bool ltloaded_ = false;
        /// Lua解释器线程
        private Thread lthread;
        /// Lua解释器 通信队列（线程安全）
        private ConcurrentQueue<LuaMsg> ltqueue = new ConcurrentQueue<LuaMsg>();
   
        public FightManager(string luaScript) {
            IsFighting = false;
            InitLua();
            //加载一次lua
            callLua(luaScript);
        }


        /// <summary>
        /// LT 开头 = LuaThread专用，不要在主线程直接调用
        /// </summary>
        private void LTInit(ref Lua state)
        {
                //LUA初始化
                state.LoadCLRPackage();
                callLua(@"import ('System')
import ('System.Windows.Forms')
import ('System.Drawing')");
                //TODO: 注册LUA函数
                LTRegisterMethodsAsFunction(state, typeof(Common));
                LTRegisterMethodsAsFunction(state, typeof(Piccolor));
                LTRegisterMethodsAsFunction(state, typeof(ifcolor));
                state["Settings"] = Common.settings;
                state["FightOptions"] = this.FightOptions;
                callLua("Set()");
            ltloaded_ = true;
        }
        private void LTWorking()
        {
            try
            {
                state_ = new Lua();
                LTInit(ref state_);
                while (state_ != null)
                {
                    LuaMsg msg;
                    if (ltqueue.TryDequeue(out msg))
                    {
                        switch (msg.type)
                        {
                            case LuaMsgType.Do:
                                state_.DoString((string)msg.param[0]);
                                break;
                            case LuaMsgType.Start:
                                while (IsFighting)
                                {
                                    state_.DoString("Fight()");
                                }
                                break;
                            case LuaMsgType.Destory:
                                state_.Close();
                                state_.Dispose();
                                state_ = null;
                                return;
                            default:
                                break;
                        }
                        Thread.Sleep(FightOptions.interval);
                    }
                    else
                    {
                    Thread.Yield();
                    }
                }
            }
            catch (LuaScriptException e)
            {
                MessageBox.Show("LuaScriptException : " + e.Message + e.StackTrace, "脚本异常");
            }
            catch (LuaException e)
            {
                MessageBox.Show("LuaException :" + e.Message + e.StackTrace, "Lua异常");
            }
        }
        /// <summary>
        /// 初始化Lua解释器线程
        /// </summary>
        private bool InitLua()
        {
            if (ltloaded_)
            {
                //已初始化直接返回
                return true;
            }
            ltloaded_ = false;
            lthread = new Thread(LTWorking);
            lthread.Start();
            // 等待lua线程执行完初始化操作再返回
            while (ltloaded_)
            {
                if (lthread.IsAlive)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 将类方法作为lua函数注册
        /// 注意：该方法必须由创建lua state的线程调用
        /// </summary>
        /// <param name="classInfo">类信息，使用typeof(className)获取</param>
        /// <returns></returns>
        public bool LTRegisterMethodsAsFunction(Lua state, Type classInfo, bool direct = false)
        {
            if (state == null)
            {
                return false;
            }
            MethodInfo[] methods = classInfo.GetMethods();
            foreach (MethodInfo m in methods)
            {
                if (direct || m.IsDefined(typeof(LuaFunction), true))
                {
                    var attr = Common.GetCustomAttribute<LuaFunction>(m);
                    string prefix = string.IsNullOrEmpty(attr.Prefix) ? string.Empty : attr.Prefix; //如未指定前缀，默认无前缀
                    string luaFuncName = prefix + (string.IsNullOrEmpty(attr.FuncName) ? m.Name : attr.FuncName); //如未指定lua函数名，默认使用c#方法名注册
                    Common.Trace("注册Lua函数"+ luaFuncName + "（From " + classInfo.Name + "）：" +  Common.StrMethodInfo(m));
                    state.RegisterFunction(luaFuncName, m);
                }
            }
            return true;
        }

        /// <summary>
        /// 将指定脚本加入lua执行队列
        /// </summary>
        /// <param name="script">要执行的脚本</param>
        /// <returns>执行结果，需自行转换对象类型</returns>
        public void callLua(string script)
        {
            NotifyLua(LuaMsgType.Do, new object[] { script });
        }
        private void NotifyLua(LuaMsgType t, object[] o)
        {
            ltqueue.Enqueue(new LuaMsg(t, o ));
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
            //TODO: start fight processing
            NotifyLua(LuaMsgType.Start, null);
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

                }
                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                if (lthread != null && lthread.IsAlive)
                {
                    IsFighting = false;
                    NotifyLua(LuaMsgType.Destory, null);
                    if (!lthread.Join(3 * 1000))
                    {
                        //3秒内没有结束则强行终止线程
                        try
                        {
                            lthread.Abort();
                        }
                        catch (ThreadAbortException)
                        {
                        }
                    }

                }
                if (state_ != null)
                {
                    state_.Dispose();
                }
                // TODO: 将大型字段设置为 null。
                state_ = null;
                ltqueue = null;
                lthread = null;

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
