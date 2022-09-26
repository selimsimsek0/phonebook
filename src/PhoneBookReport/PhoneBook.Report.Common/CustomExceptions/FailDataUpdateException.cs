using System;

namespace PhoneBook.Report.Common.CustomExceptions
{
    public class FailDataUpdateException:Exception
    {
        public FailDataUpdateException(string message):base(message)
        {

        }
    }
}
