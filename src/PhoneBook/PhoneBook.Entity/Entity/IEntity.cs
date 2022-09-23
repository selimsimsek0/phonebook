using System;

namespace PhoneBook.Entity.Entity
{
    public abstract class IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
