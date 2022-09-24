using System;

namespace PhoneBook.Entity.Entity
{
    public class ContactInfo:IEntity
    {
        public Guid PersonId { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public string Location { get; set; }

        public virtual Person Person { get; set; }
    }
}