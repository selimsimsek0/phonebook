using PhoneBook.Report.Creator.Providers;
using PhoneBook.Report.Creator.ReportCreator.Abstract;
using PhoneBook.Report.Creator.ServiceModels;
using PhoneBook.Report.Data.UnitOfWork.Abstract;
using PhoneBook.Report.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            PersonService personService = new PersonService();
            List<Person> personList = await personService.GetAllPersonsWithContacts();

            LocationReport selectedReport = _phoneBookReportUOW.LocationReportDal.Get(reportId);
            if (selectedReport == null) throw new Exception("report null");


        }
    }
}
