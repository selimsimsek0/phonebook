using Microsoft.EntityFrameworkCore.Design;

namespace PhoneBook.Report.Data.Context.DesignFactory
{
    class PhoneBookReportDbContextDesignFactory : IDesignTimeDbContextFactory<PhoneBookReportDbContext>
    {
        public PhoneBookReportDbContext CreateDbContext(string[] args)
        {
            return new PhoneBookReportDbContext();
        }
    }
}
