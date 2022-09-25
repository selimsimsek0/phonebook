using System;

namespace PhoneBook.Report.Entity.DTO
{
    public class AddLocationReportRequestDTO
    {
        public DateTime CompletedDate { get; set; }
        public int Status { get; set; }
        public Guid ReportId { get; set; }
        public int DocumentType { get; set; }
        public string DocumentPath { get; set; }
        public string DocumentName { get; set; }
    }
}
