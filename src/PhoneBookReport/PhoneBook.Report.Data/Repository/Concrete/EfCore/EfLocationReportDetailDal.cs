using Microsoft.EntityFrameworkCore;
using PhoneBook.Report.Data.Repository.Abstract;
using PhoneBook.Report.Entity.Entity;

namespace PhoneBook.Report.Data.Repository.Concrete.EfCore
{
    public class EfLocationReportDetailDal : EfRepositoryBase<LocationReportDetail>, ILocationReportDetailDal
    {
        public EfLocationReportDetailDal(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
