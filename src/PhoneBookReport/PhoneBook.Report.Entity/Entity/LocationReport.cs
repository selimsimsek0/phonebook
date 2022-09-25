using System.Collections.Generic;

namespace PhoneBook.Report.Entity.Entity
{
    public  class LocationReport:IEntity
    {
        public virtual LocationReportRequest ReportRequest { get; set; }
        public virtual ICollection<LocationReportDetail> ReportDetails { get; set; }
    }
}
