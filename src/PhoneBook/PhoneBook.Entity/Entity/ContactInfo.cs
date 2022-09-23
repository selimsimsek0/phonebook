namespace PhoneBook.Entity.Entity
{
    public class ContactInfo:IEntity
    {
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public string Location { get; set; }

        public virtual Person Person { get; set; }
    }
}