using PhoneBook.Business.Abstract;
using PhoneBook.Business.DependencyResolvers.Ninject;
using PhoneBook.Data.UnitOfWork.Abstract;
using PhoneBook.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook.Business.Concrete
{
    public class ContactInfoManager : IContactInfoService
    {
        IPhoneBookUOW _phoneBookUOW;
        public ContactInfoManager()
        {
            _phoneBookUOW = NinjectInstanceFactory.GetInstance<IPhoneBookUOW>();
        }
        public bool AddContactInfo(ContactInfo contactInfo)
        {
            return _phoneBookUOW.ContactInfoDal.Add(contactInfo);
        }

        public bool DeleteContactInfo(Guid id)
        {
            //todo unit test
            ContactInfo selectedContactInfo = GetContactInfoById(id);
            if (selectedContactInfo == null) return false;

            return _phoneBookUOW.ContactInfoDal.Delete(selectedContactInfo);
        }

        public bool DeleteContactInfo(ContactInfo contactInfo)
        {
            return _phoneBookUOW.ContactInfoDal.Delete(contactInfo);
        }

        public List<ContactInfo> GetAllContactInfo()
        {
            return _phoneBookUOW.ContactInfoDal.GetAll().ToList();
        }

        public List<ContactInfo> GetAllContactInfoWithPerson()
        {
            return _phoneBookUOW.ContactInfoDal.GetAll(includes: "Person").ToList();
        }

        public ContactInfo GetContactInfoById(Guid id)
        {
            return _phoneBookUOW.ContactInfoDal.Get(id);
        }

        public ContactInfo GetContactInfoByIdWithPerson(Guid id)
        {
            return _phoneBookUOW.ContactInfoDal.Get(id, "Person");
        }

        public bool UpdateContactInfo(ContactInfo contactInfo)
        {
            return _phoneBookUOW.ContactInfoDal.Update(contactInfo);
        }
    }
}
