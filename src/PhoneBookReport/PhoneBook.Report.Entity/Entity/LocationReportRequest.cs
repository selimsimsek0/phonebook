namespace PhoneBook.Report.Entity.Entity
{
    public class LocationReportRequest:ReportRequest
    {
        public LocationReportRequest()
        {
            base.ReportType = nameof(LocationReport);
        }
    }
}
