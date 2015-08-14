using NLua;
using NLua.Exceptions;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Fight
{
    public enum FightType { Wild, NPC, CustomPoint };
    public class FightManager : IDisposable
    {
        private Lua state_ = null;
        private string luaScript_ = null;
        

        public bool IsFighting { get; set; }
        public Point CustomPoint { get; set; }
        

        public FightManager(string lua) {
            IsFighting = false;
            CustomPoint = Common.settings.customPoint;
            luaScript_ = lua;
            InitLua();
            callLua(luaScript_);
        }

        private void InitLua()
        {
            if (state_ != null)
            {
                return ;

            }
            state_ = new Lua();
            //TODO: 注册LUA函数
            MethodInfo[] methods = typeof(MoleAssist.Common).GetMethods();
            foreach (MethodInfo m in methods)
            {
                state_.RegisterFunction(m.Name, m);
            }
        }

        public object[] callLua(string script)
        {
            try
            {
                return state_.DoString(script);
            }
            catch (LuaScriptException e)
            {
                MessageBox.Show("Exception~\n LuaScriptException : " + e.Message);
                return null;
            }catch (LuaException e)
            {
                MessageBox.Show("Exception~\n LuaException :" + e.Message);
                throw;
            }
        }

        public bool Start(FightType type) {
            if (IsFighting)
            {
                return false;
            }
            IsFighting = true;
            //TODO: start fight processing
            if (type == FightType.CustomPoint)
            {
                callLua(string.Format("SetCustomPoint({0},{1})", CustomPoint.X, CustomPoint.Y));
            }
            //传给LUA字符串，可改变FightType枚举值顺序，一旦对外发布不要改变已有名称
            callLua( string.Format("StartFight(\"{0}\")", FightType.GetName(typeof(FightType), type) ));

            return true;
        }

        public bool Stop()
        {
            if (!IsFighting)
            {
                return true;
            }
            IsFighting = true;

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
                        state_.Dispose();
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
