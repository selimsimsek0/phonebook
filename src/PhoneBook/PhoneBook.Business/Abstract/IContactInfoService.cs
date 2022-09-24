using PhoneBook.Entity.Entity;
using System;
using System.Collections.Generic;

namespace PhoneBook.Business.Abstract
{
    public interface IContactInfoService
    {
        ContactInfo GetContactInfoById(Guid id);
        ContactInfo GetContactInfoByIdWithPerson(Guid id);
        List<ContactInfo> GetAllContactInfo();
        List<ContactInfo> GetAllContactInfoWithPerson();
        bool DeleteContactInfo(Guid id);
        bool DeleteContactInfo(ContactInfo ContactInfo);
        bool AddContactInfo(ContactInfo ContactInfo);
        bool UpdateContactInfo(ContactInfo ContactInfo);
    }
}
