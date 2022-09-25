using System;

namespace PhoneBook.Report.Entity.Entity
{
    public class LocationReportDetail : IEntity
    {
        public Guid ReportId { get; set; }
        public string Location { get; set; }
        public double PersonCount { get; set; }
        public double PhoneNumberCount { get; set; }

    }
}
