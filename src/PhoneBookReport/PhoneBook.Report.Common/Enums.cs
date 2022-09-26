using PhoneBook.Report.Common.Extensions;

namespace PhoneBook.Report.Common
{
    public static class Enums
    {
        public enum DocumentType
        {
            [EnumDescription("Txt File")]
            Txt = 0,
            [EnumDescription("PDF File")]
            Pdf = 1,
            [EnumDescription("Excel File")]
            Excel = 2
        }

        public enum CreatedStatus
        {
            [EnumDescription("Request queued.")]
            InQueue = 0,
            [EnumDescription("Generating report.")]
            Creating = 1,
            [EnumDescription("Report created.")]
            Created = 2,
            [EnumDescription("Failed to generate report.")]
            Fail = 3

        }
    }
}
