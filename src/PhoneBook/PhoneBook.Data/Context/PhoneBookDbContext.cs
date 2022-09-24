using Microsoft.EntityFrameworkCore;

namespace PhoneBook.Data.Context
{
    public class PhoneBookDbContext:DbContext
    {
        public PhoneBookDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
