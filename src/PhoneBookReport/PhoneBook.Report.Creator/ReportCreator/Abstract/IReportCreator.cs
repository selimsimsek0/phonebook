using System;

namespace PhoneBook.Report.Creator.ReportCreator.Abstract
{
    public interface IReportCreator
    {
        void ReportCreate(Guid reportId);
    }
}
