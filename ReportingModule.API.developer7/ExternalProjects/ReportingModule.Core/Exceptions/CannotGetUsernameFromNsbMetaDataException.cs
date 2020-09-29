using System;

namespace ReportingModule.Core.Exceptions
{
    public class CannotGetUsernameFromNsbMetaDataException : Exception
    {
        public CannotGetUsernameFromNsbMetaDataException()
            : base("Cannot retrieve a valid username from NSB Metadata property 'Username'")
        {
        }

        public CannotGetUsernameFromNsbMetaDataException(string message) : base(message)
        {
        }

        public CannotGetUsernameFromNsbMetaDataException(string message, Exception x) : base(message, x)
        {
        }
    }
}