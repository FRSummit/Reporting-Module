using System;

namespace ReportingModule.Core.Exceptions
{
    public class CannotGetUserIdFromNsbMetaDataException : ReportingModuleException
    {
        public CannotGetUserIdFromNsbMetaDataException()
            : base("Cannot retrieve a valid ID from NSB Metadata property 'UserId'")
        {
        }

        public CannotGetUserIdFromNsbMetaDataException(string message) : base(message)
        {
        }

        public CannotGetUserIdFromNsbMetaDataException(string message, Exception x) : base(message, x)
        {
        }

        public CannotGetUserIdFromNsbMetaDataException(string format, params object[] args) : base(format, args)
        {
        }
    }
}