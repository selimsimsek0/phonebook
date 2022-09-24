using System;

namespace PhoneBook.Entity.DTO
{
    public class AddContactInfoDTO
    {
        public Guid PersonId { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public string Location { get; set; }
    }
}
