using PhoneBook.Report.Creator.Providers;
using PhoneBook.Report.Creator.ReportCreator.Abstract;
using PhoneBook.Report.Creator.ServiceModels;
using PhoneBook.Report.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Report.Creator.ReportCreator.Concrete
{
    public class LocationReportCreater : ILocationReportCreator
    {
        public async Task<bool> CreateReportAsync(LocationReport selectedReport)
        {
            selectedReport.ReportDetails = new List<LocationReportDetail>();
            ContactInfoService contactInfoService = new ContactInfoService();
            List<ContactInfo> contactInfoList = await contactInfoService.GetAllContactInfosWithPerson();

            var contactIngoGroupByLocation = contactInfoList.GroupBy(p => p.Location);

            foreach (var groupItem in contactIngoGroupByLocation)
            {
                selectedReport.ReportDetails.Add(SetLocationReportDetail(groupItem, selectedReport.Id));
            }

            return true;
        }

        private LocationReportDetail SetLocationReportDetail(IGrouping<string, ContactInfo> groupItem, Guid selectedReportId)
        {
            double phoneNumberCount = groupItem.Where(p => string.IsNullOrWhiteSpace(p.PhoneNumber) == false).Count();
            double personCount = groupItem.Select(p => p.Person).Distinct().Count();
            return new LocationReportDetail
            {
                CreationDate = DateTime.Now,
                Id = Guid.Empty,
                Location = groupItem.Key,
                PersonCount = personCount,
                PhoneNumberCount = phoneNumberCount,
                ReportId = selectedReportId
            };
        }
      
    }
}
