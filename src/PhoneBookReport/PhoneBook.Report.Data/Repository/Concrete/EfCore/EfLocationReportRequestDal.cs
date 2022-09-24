using Microsoft.EntityFrameworkCore;
using PhoneBook.Report.Data.Repository.Abstract;
using PhoneBook.Report.Entity.Entity;

namespace PhoneBook.Report.Data.Repository.Concrete.EfCore
{
    public class EfLocationReportRequestDal : EfRepositoryBase<LocationReportRequest>, ILocationReportRequestDal
    {
        public EfLocationReportRequestDal(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
