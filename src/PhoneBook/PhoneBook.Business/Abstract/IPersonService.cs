using PhoneBook.Entity.Entity;
using System;
using System.Collections.Generic;

namespace PhoneBook.Business.Abstract
{
    public interface IPersonService
    {
        Person GetPersonById(Guid id);
        Person GetPersonByIdWithContactInfos(Guid id);
        List<Person> GetAllPerson();
        List<Person> GetAllPersonWithContactInfos();
        bool DeletePerson(Guid id);
        bool DeletePerson(Person person);
        bool AddPerson(Person person);
        bool UpdatePerson(Person person);
    }
}
