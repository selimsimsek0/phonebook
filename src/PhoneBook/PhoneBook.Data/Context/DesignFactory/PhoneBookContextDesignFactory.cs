using Microsoft.EntityFrameworkCore.Design;

namespace PhoneBook.Data.Context.DesignFactory
{
    public class PhoneBookContextDesignFactory : IDesignTimeDbContextFactory<PhoneBookDbContext>
    {
        public PhoneBookDbContext CreateDbContext(string[] args)
        {
            return new PhoneBookDbContext();
        }
    }
}
