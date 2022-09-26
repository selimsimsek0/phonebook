using System;

namespace PhoneBook.Report.Common.CustomExceptions
{
    public class FailDocumentGenerateException : Exception
    {
        public FailDocumentGenerateException(string message) : base(message)
        {

        }
    }
}
