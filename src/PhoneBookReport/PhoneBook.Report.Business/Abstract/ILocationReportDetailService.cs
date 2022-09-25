using PhoneBook.Report.Entity.Entity;
using System;
using System.Collections.Generic;

namespace PhoneBook.Report.Business.Abstract
{
    public interface ILocationReportDetailService
    {
        List<LocationReportDetail> GetAllDetail();
        LocationReportDetail GetDetail(Guid id);
        bool Delete(Guid id);
        bool Delete(LocationReportDetail detail);
        bool Add(LocationReportDetail detail);
        bool Update(LocationReportDetail detail);
    }
}
