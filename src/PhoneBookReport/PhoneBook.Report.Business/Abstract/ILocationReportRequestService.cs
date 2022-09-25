using PhoneBook.Report.Entity.Entity;
using System;
using System.Collections.Generic;

namespace PhoneBook.Report.Business.Abstract
{
    public interface ILocationReportRequestService
    {
        List<LocationReportRequest> GetAllRequest();
        LocationReportRequest GetRequest(Guid id);
        bool Delete(Guid id);
        bool Delete(LocationReportRequest reportRequest);
        bool Add(LocationReportRequest reportRequest);
        bool Update(LocationReportRequest reportRequest);
    }
}
