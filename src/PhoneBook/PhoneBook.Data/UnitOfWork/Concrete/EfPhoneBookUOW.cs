using Microsoft.EntityFrameworkCore;
using PhoneBook.Data.Abstract;
using PhoneBook.Data.UnitOfWork.Abstract;

namespace PhoneBook.Data.UnitOfWork.Concrete
{
    public class EfPhoneBookUOW : EfUnitOfWorkBase, IPhoneBookUOW
    {
        public IPersonDal PersonDal { get; }

        public IContactInfoDal ContactInfoDal { get; }

        public EfPhoneBookUOW(IPersonDal personDal, IContactInfoDal contactInfoDal, DbContext dbContext):base(dbContext)
        {
            PersonDal = personDal;
            ContactInfoDal = contactInfoDal;
        }
    }
}
