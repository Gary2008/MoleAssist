using System;

namespace MoleAssist
{

    /// <summary>
    /// 标记为此属性的方法将被注册到lua
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    sealed class LuaFunctionAttribute : Attribute
    {
        public string FuncName { get; private set; }
        public string Prefix { get; private set; }
        public LuaFunctionAttribute() : this(null)
        {
        }

        /// <summary>
        /// Lua函数属性
        /// </summary>
        /// <param name="FuncName">lua中的函数名</param>
        /// <param name="prefix">lua中的函数名前缀</param>
        public LuaFunctionAttribute(string FuncName = null, string Prefix = "")
        {
            this.FuncName = FuncName;
            this.Prefix = Prefix;
        }
    }
}
