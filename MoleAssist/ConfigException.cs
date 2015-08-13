using System;

namespace Config
{
    class ConfigException : ApplicationException
    {
        public ConfigException() : base()
        {
        }
        public ConfigException(string message) : base(message)
        {
        }
        public ConfigException(string message, Exception inner) : base(message, inner)
        {
        }
    }
    class ConfigFetchException : ConfigException
    {
        public ConfigFetchException()
        {
        }
        public ConfigFetchException(string message)
        {
        }
        public ConfigFetchException(string message, Exception inner) : base(message, inner)
        {
        }
    }
    class ConfigParseException : ConfigException
    {
        public ConfigParseException() : base()
        {
        }
        public ConfigParseException(string message) : base(message)
        {
        }
        public ConfigParseException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
