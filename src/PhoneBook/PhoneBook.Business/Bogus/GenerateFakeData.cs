using Bogus;
using System;
using System.Collections.Generic;
using entity = PhoneBook.Entity.Entity;

namespace PhoneBook.Business.Bogus
{
    public class GenerateFakeData
    {
        public List<entity.Person> GeneratePerons(int count)
        {
            var personFaker = new Faker<entity.Person>("tr")
               .RuleFor(i => i.Id, Guid.Empty)
               .RuleFor(i => i.CreationDate, DateTime.Now)
               .RuleFor(i => i.Name, p => p.Person.FirstName)
               .RuleFor(i => i.Surname, p => p.Person.LastName)
               .RuleFor(i => i.Company, p => p.Person.Company.Name);

            var contactFaker = new Faker<entity.ContactInfo>("tr")
              .RuleFor(i => i.Id, Guid.Empty)
              .RuleFor(i => i.CreationDate, DateTime.Now)
              .RuleFor(i => i.PhoneNumber, p => p.Person.Phone)
              .RuleFor(i => i.Location, p => p.Address.City())
              .RuleFor(i => i.MailAddress, p => p.Person.Email);

            List<entity.Person> fakePersons = personFaker.Generate(count);

            return fakePersons;
        }
        public List<entity.ContactInfo> GenerateContactInfos(int count)
        {
            var contactFaker = new Faker<entity.ContactInfo>("tr")
              .RuleFor(i => i.Id, Guid.Empty)
              .RuleFor(i => i.CreationDate, DateTime.Now)
              .RuleFor(i => i.PhoneNumber, p => p.Person.Phone)
              .RuleFor(i => i.Location, p => p.Address.City())
              .RuleFor(i => i.MailAddress, p => p.Person.Email);

            List<entity.ContactInfo> fakeContacts = contactFaker.Generate(count);

            return fakeContacts;
        }


    }
}
