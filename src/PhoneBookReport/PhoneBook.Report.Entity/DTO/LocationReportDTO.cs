using System;

namespace PhoneBook.Report.Entity.DTO
{
    public class LocationReportDTO
    {
        public Guid ReportId{ get; set; }
        public int Status { get; set; }
        public string StatusDescription { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
