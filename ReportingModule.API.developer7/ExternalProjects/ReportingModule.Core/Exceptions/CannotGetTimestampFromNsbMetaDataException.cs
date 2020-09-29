using System;

namespace ReportingModule.Core.Exceptions
{
    public class CannotGetTimestampFromNsbMetaDataException : ReportingModuleException
    {
        public CannotGetTimestampFromNsbMetaDataException()
            : base("Cannot retrieve a valid timestamp from NSB Metadata property 'CommandSentUtc'")
        {
        }

        public CannotGetTimestampFromNsbMetaDataException(string message) : base(message)
        {
        }

        public CannotGetTimestampFromNsbMetaDataException(string message, Exception x) : base(message, x)
        {
        }

        public CannotGetTimestampFromNsbMetaDataException(string format, params object[] args) : base(format, args)
        {
        }
    }
}