using System;

namespace com.mobiquity.packer
{
    public class APIException : Exception
    {
        public string ConfigurationLine { get; set; }
        public APIException(string message) : base(message) 
        { 
        }

        public APIException(string message, string configurationLine) : base(message)
        {
            ConfigurationLine = configurationLine;
        }
    }
}
