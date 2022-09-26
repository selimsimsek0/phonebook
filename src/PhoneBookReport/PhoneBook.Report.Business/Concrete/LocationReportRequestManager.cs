using PhoneBook.Report.Business.Abstract;
using PhoneBook.Report.Business.DependenctResolvers.Ninject;
using PhoneBook.Report.Data.UnitOfWork.Abstract;
using PhoneBook.Report.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook.Report.Business.Concrete
{
    public class LocationReportRequestManager : ILocationReportRequestService
    {
        IPhoneBookReportUOW _reportUOW;
        public LocationReportRequestManager()
        {
            _reportUOW = NinjectInstanceFactory.GetInstance<IPhoneBookReportUOW>();
        }
        public LocationReportRequestManager(IPhoneBookReportUOW reportUOW)
        {
            _reportUOW = reportUOW;
        }
        public bool Add(LocationReportRequest reportRequest)
        {
            return _reportUOW.LocationReportRequestDal.Add(reportRequest);
        }

        public bool Delete(Guid id)
        {
            LocationReportRequest selectedReport = GetRequest(id);
            if (selectedReport == null) return false;
            return _reportUOW.LocationReportRequestDal.Delete(selectedReport);
        }

        public bool Delete(LocationReportRequest reportRequest)
        {
            return _reportUOW.LocationReportRequestDal.Delete(reportRequest);
        }

        public List<LocationReportRequest> GetAllRequest()
        {
            return _reportUOW.LocationReportRequestDal.GetAll(includes: "LocationReport").ToList();
        }

        public LocationReportRequest GetRequest(Guid id)
        {
            return _reportUOW.LocationReportRequestDal.Get(id, "LocationReport");
        }

        public bool Update(LocationReportRequest reportRequest)
        {
            return _reportUOW.LocationReportRequestDal.Update(reportRequest);
        }
    }
}
