using System;

namespace com.mobiquity.packer
{
    public class APIException : Exception
    {
        public APIException(string message) : base(message) 
        { 
        }
    }
}
