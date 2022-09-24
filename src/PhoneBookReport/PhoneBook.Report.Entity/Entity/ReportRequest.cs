using System;

namespace PhoneBook.Report.Entity.Entity
{
    public abstract class ReportRequest:IEntity
    {
        public DateTime RequestDate { get; set; }
        public int Status { get; set; }
        public string ReportType { get; set; }
        public Guid ReportId { get; set; }
        public int DocumentType { get; set; }
        public string DocumentPath { get; set; }
        public string DocumentName { get; set; }
    }
}
