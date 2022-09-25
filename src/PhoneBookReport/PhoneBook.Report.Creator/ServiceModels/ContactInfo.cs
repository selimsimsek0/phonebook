using System;

namespace PhoneBook.Report.Creator.ServiceModels
{
    public class ContactInfo
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid PersonId { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public string Location { get; set; }

        public virtual Person Person { get; set; }
    }
}
