using Microsoft.EntityFrameworkCore;
using PhoneBook.Report.Data.Repository.Abstract;
using PhoneBook.Report.Entity.Entity;

namespace PhoneBook.Report.Data.Repository.Concrete.EfCore
{
    public class EfLocationReportDal:EfRepositoryBase<LocationReport>,ILocationReportDal
    {
        public EfLocationReportDal(DbContext dbContext):base(dbContext)
        {

        }
    }
}
