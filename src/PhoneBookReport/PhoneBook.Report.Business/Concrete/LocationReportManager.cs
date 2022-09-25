using PhoneBook.Report.Business.Abstract;
using PhoneBook.Report.Business.DependenctResolvers.Ninject;
using PhoneBook.Report.Data.UnitOfWork.Abstract;
using PhoneBook.Report.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook.Report.Business.Concrete
{
    public class LocationReportManager : ILocationReportService
    {
        IPhoneBookReportUOW _reportUOW;
        public LocationReportManager()
        {
            _reportUOW = NinjectInstanceFactory.GetInstance<IPhoneBookReportUOW>();
        }
        public bool Add(LocationReport report)
        {
            return _reportUOW.LocationReportDal.Add(report);
        }

        public bool Delete(Guid id)
        {
            LocationReport selectedReport = GetReport(id);
            if (selectedReport == null) return false;
            return _reportUOW.LocationReportDal.Delete(selectedReport);
        }

        public bool Delete(LocationReport report)
        {
            return _reportUOW.LocationReportDal.Delete(report);
        }

        public List<LocationReport> GetAllReport()
        {
            return _reportUOW.LocationReportDal.GetAll(includes: "ReportRequest").ToList();
        }

        public LocationReport GetReport(Guid id)
        {
            return _reportUOW.LocationReportDal.Get(id, "ReportRequest");
        }

        public bool Update(LocationReport report)
        {
            return _reportUOW.LocationReportDal.Update(report);
        }
    }
}
