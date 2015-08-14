using System;
using System.Runtime.Serialization;

namespace Config
{
    [Serializable]
    public class ConfigException : Exception
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
        protected ConfigException(SerializationInfo info, StreamingContext context) : base (info, context)
        {
        }
    }
    [Serializable]
    public class ConfigFetchException : ConfigException
    {
        public ConfigFetchException()
        {
        }
        public ConfigFetchException(string message) : base(message)
        {
        }
        public ConfigFetchException(string message, Exception inner) : base(message, inner)
        {
        }
        protected ConfigFetchException(SerializationInfo info, StreamingContext context) : base (info, context)
        {
        }
    }
    [Serializable]
    public class ConfigParseException : ConfigException
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
        protected ConfigParseException(SerializationInfo info, StreamingContext context) : base (info, context)
        {
        }
    }
}
