using System.Collections.Generic;

namespace PhoneBook.Entity.Entity
{
    public class Person : IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }

        public virtual ICollection<ContactInfo> ContactInfos { get; set; }
    }
}
