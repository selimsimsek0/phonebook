using Microsoft.EntityFrameworkCore;
using PhoneBook.Report.Entity.Entity;

namespace PhoneBook.Report.Data.Context
{
    public class PhoneBookReportDbContext:DbContext
    {

        private string DbName => "PhoneBookReport";
        private string ConnectionString => $@"Server=localhost;Port=5432;Database={DbName};User Id=selimsimsek;Password=12345;";

        public PhoneBookReportDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
                optionsBuilder.UseNpgsql(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocationReport>(locationReport =>
            {
                locationReport.ToTable("LocationReports");

                locationReport.Property(p => p.Id).HasColumnType("uuid").IsRequired().HasDefaultValueSql("gen_random_uuid()");
                locationReport.HasKey(p => p.Id);
                locationReport.Property(p => p.CreationDate).IsRequired();

                locationReport.HasOne(p => p.ReportRequest).WithOne(p=>p.LocationReport).HasForeignKey<LocationReportRequest>(p => p.ReportId).HasConstraintName("locationreportrequest_locationreport_reportid_fk");
                locationReport.HasMany(p => p.ReportDetails).WithOne().HasForeignKey(p => p.ReportId).HasConstraintName("locationreportdetails_locationreport_reportid_fk");
            });

            modelBuilder.Entity<LocationReportDetail>(locationReportDetail =>
            {
                locationReportDetail.ToTable("LocationReportDetails");

                locationReportDetail.Property(p => p.Id).HasColumnType("uuid").IsRequired().HasDefaultValueSql("gen_random_uuid()");
                locationReportDetail.HasKey(p => p.Id);
                locationReportDetail.Property(p => p.CreationDate).IsRequired();

                locationReportDetail.Property(p => p.Location).HasColumnType("varchar(255)").IsRequired();
                locationReportDetail.Property(p => p.PersonCount).HasColumnType("double precision").IsRequired();
                locationReportDetail.Property(p => p.PhoneNumberCount).HasColumnType("double precision").IsRequired();
            });

            modelBuilder.Entity<LocationReportRequest>(reportRequest =>
            {
                reportRequest.ToTable("LocationReportRequests");
                reportRequest.HasKey(p => p.Id);

                reportRequest.Property(p => p.Id).HasColumnType("uuid").IsRequired().HasDefaultValueSql("gen_random_uuid()");
                reportRequest.Property(p => p.CreationDate).IsRequired();

                reportRequest.Property(p => p.CompletedDate).IsRequired();
                reportRequest.Property(p => p.Status).HasColumnType("int").IsRequired();
                reportRequest.Property(p => p.ReportId).HasColumnType("uuid").IsRequired();
                reportRequest.Property(p => p.DocumentType).HasColumnType("int");
                reportRequest.Property(p => p.DocumentPath).HasColumnType("varchar(500)");
                reportRequest.Property(p => p.DocumentName).HasColumnType("varchar(255)");
            });


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<LocationReport> LocationReports { get; set; }
        public DbSet<LocationReportDetail> LocationReportDetails { get; set; }
        public DbSet<LocationReportRequest> LocationReportRequests { get; set; }
    }
}
