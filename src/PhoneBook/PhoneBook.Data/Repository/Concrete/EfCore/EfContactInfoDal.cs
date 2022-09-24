using Microsoft.EntityFrameworkCore;
using PhoneBook.Data.Abstract;
using PhoneBook.Entity.Entity;

namespace PhoneBook.Data.Concrete.EfCore
{
    public class EfContactInfoDal : EfRepositoryBase<ContactInfo>, IContactInfoDal
    {
        public EfContactInfoDal(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
