using Microsoft.EntityFrameworkCore;
using PhoneBook.Entity.Entity;

namespace PhoneBook.Data.Context
{
    public class PhoneBookDbContext:DbContext
    {
        private  string DbName => "PhoneBook";
        private string ConnectionString => $@"Server=localhost;Port=5432;Database={DbName};User Id=selimsimsek;Password=12345;";

        public PhoneBookDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(optionsBuilder.IsConfigured==false)
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(person =>
            {
                person.ToTable("Persons");

                person.Property(p => p.Id).HasColumnType("uuid").IsRequired().HasDefaultValueSql("gen_random_uuid()");
                person.HasKey(p => p.Id);
                person.Property(p => p.CreationDate).IsRequired();

                person.Property(p => p.Name).HasColumnType("varchar(100)").IsRequired();
                person.Property(p => p.Surname).HasColumnType("varchar(100)").IsRequired();
                person.Property(p => p.Company).HasColumnType("varchar(255)");

                person.HasMany(p => p.ContactInfos).WithOne(p => p.Person).HasForeignKey(p => p.PersonId).HasConstraintName("contactinfos_persons_personid_fk");
            });

            modelBuilder.Entity<ContactInfo>(contact =>
            {
                contact.ToTable("ContactInfos");

                contact.Property(p => p.Id).HasColumnType("uuid").IsRequired().HasDefaultValueSql("gen_random_uuid()");
                contact.HasKey(p => p.Id);
                contact.Property(p => p.CreationDate).IsRequired();

                contact.Property(p => p.PhoneNumber).HasColumnType("varchar(30)");
                contact.Property(p => p.MailAddress).HasColumnType("varchar(30)");
                contact.Property(p => p.Location).HasColumnType("varchar(100)");
            });


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
    }
}
