using Microsoft.EntityFrameworkCore;
using PhoneBook.Data.Abstract;
using PhoneBook.Entity.Entity;

namespace PhoneBook.Data.Concrete.EfCore
{
    public class EfPersonDal:EfRepositoryBase<Person>,IPersonDal
    {
        public EfPersonDal(DbContext dbContext): base(dbContext) 
        {

        }
    }
}
