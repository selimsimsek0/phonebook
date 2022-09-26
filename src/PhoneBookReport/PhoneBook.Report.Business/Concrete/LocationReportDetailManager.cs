using PhoneBook.Report.Business.Abstract;
using PhoneBook.Report.Business.DependenctResolvers.Ninject;
using PhoneBook.Report.Data.UnitOfWork.Abstract;
using PhoneBook.Report.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook.Report.Business.Concrete
{
    public class LocationReportDetailManager : ILocationReportDetailService
    {
        IPhoneBookReportUOW _reportUOW;
        public LocationReportDetailManager()
        {
            _reportUOW = NinjectInstanceFactory.GetInstance<IPhoneBookReportUOW>();
        }
        public LocationReportDetailManager(IPhoneBookReportUOW reportUOW)
        {
            _reportUOW = reportUOW;
        }

        public bool Add(LocationReportDetail detail)
        {
            return _reportUOW.LocationReportDetailDal.Add(detail);
        }

        public bool Delete(Guid id)
        {
            LocationReportDetail selectedDetail = GetDetail(id);
            if (selectedDetail == null) return false;
            return _reportUOW.LocationReportDetailDal.Delete(selectedDetail);
        }

        public bool Delete(LocationReportDetail detail)
        {
            return _reportUOW.LocationReportDetailDal.Delete(detail);
        }

        public List<LocationReportDetail> GetAllDetail()
        {
            return _reportUOW.LocationReportDetailDal.GetAll().ToList();
        }

        public LocationReportDetail GetDetail(Guid id)
        {
            return _reportUOW.LocationReportDetailDal.Get(id);
        }

        public bool Update(LocationReportDetail detail)
        {
            return _reportUOW.LocationReportDetailDal.Update(detail);
        }
    }
}
