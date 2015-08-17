using System;

namespace MoleAssist
{

    /// <summary>
    /// 标记为此属性的方法将被注册到lua
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    sealed class LuaFunction : Attribute
    {
        public string FunctionName{ get; private set; }
        public LuaFunction() : this(null)
        {
        }

        /// <summary>
        /// Lua函数属性
        /// </summary>
        /// <param name="FuncName">lua中的函数名</param>
        public LuaFunction(string FuncName)
        {
            FunctionName = FuncName;
        }
    }
}
