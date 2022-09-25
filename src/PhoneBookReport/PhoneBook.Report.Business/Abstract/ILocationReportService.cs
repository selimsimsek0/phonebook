using PhoneBook.Report.Entity.Entity;
using System;
using System.Collections.Generic;

namespace PhoneBook.Report.Business.Abstract
{
    public interface ILocationReportService
    {
        List<LocationReport> GetAllReport();
        LocationReport GetReport(Guid id);
        bool Delete(Guid id);
        bool Delete(LocationReport report);
        bool Add(LocationReport report);
        bool Update(LocationReport report);
    }
}
