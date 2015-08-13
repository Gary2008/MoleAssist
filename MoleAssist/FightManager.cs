using NLua;
using System;
using System.Drawing;
using settings = MoleAssist.Properties.Settings;

namespace Fight
{
    public class FightManager
    {
        protected Lua state_ = null;
        protected string luaScript_ = null;

        public bool IsFighting { get; set; }
        public Point CustomPoint { get; set; }
        
        public FightManager(string lua) {
            IsFighting = false;
            CustomPoint = settings.Default.customPoint;
            luaScript_ = lua;
            state_ = new Lua();
            //TODO: 注册LUA函数

        }

        ~FightManager()
        {
            state_.Close();
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
    }
}
