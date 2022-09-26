using System;

namespace PhoneBook.Report.Common.CustomExceptions
{
    public class FailReportGenerateException : Exception
    {
        public FailReportGenerateException(string message) : base(message)
        {

        }
    }
}
