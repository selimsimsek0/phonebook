using Microsoft.EntityFrameworkCore;
using PhoneBook.Report.Data.Repository.Abstract;
using PhoneBook.Report.Data.UnitOfWork.Abstract;

namespace PhoneBook.Report.Data.UnitOfWork.Concrete
{
    public class EfPhoneBookReportUOW:EfUnitOfWorkBase,IPhoneBookReportUOW
    {
        public ILocationReportDal LocationReportDal { get; }
        public ILocationReportDetailDal LocationReportDetailDal { get; }

        public ILocationReportRequestDal LocationReportRequestDal { get; }
        public EfPhoneBookReportUOW(DbContext context, ILocationReportDal locationReportDal, ILocationReportRequestDal locationReportRequestDal, ILocationReportDetailDal locationReportDetailDal) : base(context)
        {
            LocationReportDal = locationReportDal;
            LocationReportDetailDal = locationReportDetailDal;
            LocationReportRequestDal = locationReportRequestDal;
        }

    }
}
