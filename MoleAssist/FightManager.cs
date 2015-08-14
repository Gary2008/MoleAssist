using NLua;
using System;
using System.Drawing;
using settings = MoleAssist.Properties.Settings;

namespace Fight
{
    public class FightManager : IDisposable
    {
        private Lua state_ = null;
        private string luaScript_ = null;
        
        public bool IsFighting { get; set; }
        public Point CustomPoint { get; set; }
        
        public FightManager(string lua) {
            IsFighting = false;
            CustomPoint = settings.Default.customPoint;
            luaScript_ = lua;
            state_ = new Lua();
            //TODO: 注册LUA函数

        }

        public bool Start() {
            if (IsFighting)
            {
                return false;
            }
            IsFighting = true;
            //TODO: start fight processing
            throw new NotImplementedException();
        }
        public bool Stop()
        {
            if (!IsFighting)
            {
                return true;
            }
            IsFighting = true;
            //TODO: stop fight processing

            throw new NotImplementedException();
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
                    state_.Close();
                    state_.Dispose();
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
