using System;

namespace PhoneBook.Report.Common.CustomExceptions
{
    public class FailDataInsertException : Exception
    {
        public FailDataInsertException(string message) : base(message)
        {

        }
    }
}
