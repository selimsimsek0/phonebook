using PhoneBook.Business.Abstract;
using PhoneBook.Business.Bogus;
using PhoneBook.Business.DependencyResolvers.Ninject;
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

        public PersonManager()
        {
            _phoneBookUOW = NinjectInstanceFactory.GetInstance<IPhoneBookUOW>();
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

        public bool GenerateFakePerson(int count)
        {
            GenerateFakeData generateFakeData = new GenerateFakeData();
            List<Person> fakePersons = generateFakeData.GeneratePerons(count);
            List<ContactInfo> fakeContactInfos = generateFakeData.GenerateContactInfos(count * 2);

            _phoneBookUOW.NewTranaction();
            try
            {
                int contactIndex = 0;
                foreach (var fakePerson in fakePersons)
                {
                    bool addPersonResult = _phoneBookUOW.PersonDal.Add(fakePerson);
                    if (addPersonResult == false) throw new Exception();

                    fakeContactInfos[contactIndex].PersonId = fakePerson.Id;
                    bool addContactResult = _phoneBookUOW.ContactInfoDal.Add(fakeContactInfos[contactIndex]);
                    if (addContactResult == false) throw new Exception();
                    contactIndex++;

                    fakeContactInfos[contactIndex].PersonId = fakePerson.Id;
                    addContactResult = _phoneBookUOW.ContactInfoDal.Add(fakeContactInfos[contactIndex]);
                    if (addContactResult == false) throw new Exception();
                    contactIndex++;
                }

                _phoneBookUOW.Commit();
            }
            catch
            {
                _phoneBookUOW.RollBack();
                throw;
            }

            return true;
        }

        public List<Person> GetAllPerson()
        {
            return _phoneBookUOW.PersonDal.GetAll().ToList();
        }

        public List<Person> GetAllPersonWithContactInfos()
        {
            return _phoneBookUOW.PersonDal.GetAll(includes: "ContactInfos").ToList();
        }

        public Person GetPersonById(Guid id)
        {
            return _phoneBookUOW.PersonDal.Get(id);
        }

        public Person GetPersonByIdWithContactInfos(Guid id)
        {
            return _phoneBookUOW.PersonDal.Get(id, "ContactInfos");
        }

        public bool UpdatePerson(Person person)
        {
            return _phoneBookUOW.PersonDal.Update(person);
        }
    }
}
