using PhoneBook.Business.Abstract;
using PhoneBook.Data.UnitOfWork.Abstract;
using PhoneBook.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook.Business.Concrete
{
    public class PersonManager : IPersonService
    {
        IPhoneBookUOW _phoneBookUOW;
        public PersonManager(IPhoneBookUOW phoneBookUOW)
        {
            _phoneBookUOW = phoneBookUOW;
        }
        public bool AddPerson(Person person)
        {
            return _phoneBookUOW.PersonDal.Add(person);
        }

        public bool DeletePerson(Guid id)
        {
            Person selectedPerson = GetPersonById(id);
            if (selectedPerson == null) return false;

            return _phoneBookUOW.PersonDal.Delete(selectedPerson);
        }

        public bool DeletePerson(Person person)
        {
            return _phoneBookUOW.PersonDal.Delete(person);
        }

        public List<Person> GetAllPerson()
        {
            return _phoneBookUOW.PersonDal.GetAll().ToList();
        }

        public List<Person> GetAllPersonWithContactInfos()
        {
            return _phoneBookUOW.PersonDal.GetAll(includes:"ContactInfos").ToList();
        }

        public Person GetPersonById(Guid id)
        {
            return _phoneBookUOW.PersonDal.Get(id);
        }

        public Person GetPersonByIdWithContactInfos(Guid id)
        {
            return _phoneBookUOW.PersonDal.Get(id,"ContactInfos");
        }

        public bool UpdatePerson(Person person)
        {
            return _phoneBookUOW.PersonDal.Update(person);
        }
    }
}
