namespace PhoneBook.Report.Entity.Entity
{
    public  class LocationReport:IEntity
    {
        public string Location { get; set; }
        public double PersonCount { get; set; }
        public double PhoneNumberCount { get; set; }

        public virtual LocationReportRequest ReportRequest { get; set; }
    }
}
