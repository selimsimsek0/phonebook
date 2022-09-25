using PhoneBook.Report.Business.Enums;
using PhoneBook.Report.Creator.Providers;
using PhoneBook.Report.Creator.ReportCreator.Abstract;
using PhoneBook.Report.Creator.ServiceModels;
using PhoneBook.Report.Data.UnitOfWork.Abstract;
using PhoneBook.Report.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook.Report.Creator.ReportCreator.Concrete
{
    public class LocationReportCreater : ILocationReportCreator
    {
        IPhoneBookReportUOW _phoneBookReportUOW;
        public LocationReportCreater(IPhoneBookReportUOW phoneBookReportUOW)
        {
            _phoneBookReportUOW = phoneBookReportUOW;
        }
        public async void ReportCreate(Guid reportId)
        {
            ContactInfoService contactInfoService = new ContactInfoService();
            List<ContactInfo> contactInfoList = await contactInfoService.GetAllContactInfosWithPerson();

            LocationReport selectedReport = _phoneBookReportUOW.LocationReportDal.Get(reportId);
            if (selectedReport == null) throw new Exception("report null");

            bool updateResult = UpdateReportStatus(selectedReport);
            if (updateResult == false) throw new Exception("request update fail");

            var contactIngoGroupByLocation = contactInfoList.GroupBy(p => p.Location);

            foreach (var groupItem in contactIngoGroupByLocation)
            {
                LocationReportDetail reportDetail = SetLocationReportDetail(groupItem, selectedReport.Id);
                bool addResult = AddReportDetail(reportDetail);
                if (addResult == false) throw new Exception("Report detail could not be added.");
            }
        }

        private bool UpdateReportStatus(LocationReport selectedReport)
        {
            selectedReport.ReportRequest.Status = (int)Enums.CreatedStatus.Creating;
            return _phoneBookReportUOW.LocationReportRequestDal.Update(selectedReport.ReportRequest);
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
        private bool AddReportDetail(LocationReportDetail reportDetail)
        {
            return _phoneBookReportUOW.LocationReportDetailDal.Add(reportDetail);
        }
    }
}
