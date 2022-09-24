using PhoneBook.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.UnitOfWork.Abstract
{
    public interface IPhoneBookUOW:IUnitOfWork
    {
        IPersonDal PersonDal { get; }
        IContactInfoDal ContactInfoDal { get; }
    }
}
