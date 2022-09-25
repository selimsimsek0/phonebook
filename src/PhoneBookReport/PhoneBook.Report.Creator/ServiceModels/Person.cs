using System;
using System.Collections.Generic;

namespace PhoneBook.Report.Creator.ServiceModels
{
    public class Person
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }

        public virtual ICollection<ContactInfo> ContactInfos { get; set; }
    }
}
