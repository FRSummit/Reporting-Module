using System;

namespace ReportingModule.Core.Exceptions
{
    public class CannotGetUserRefFromNsbMetaDataException : ReportingModuleException
    {
        public CannotGetUserRefFromNsbMetaDataException()
            : base("Cannot retrieve a valid user reference from NSB Metadata property 'UserRef'")
        {
        }

        public CannotGetUserRefFromNsbMetaDataException(string message) : base(message)
        {
        }

        public CannotGetUserRefFromNsbMetaDataException(string message, Exception x) : base(message, x)
        {
        }

        public CannotGetUserRefFromNsbMetaDataException(string format, params object[] args) : base(format, args)
        {
        }
    }
}