using PhoneBook.Report.Creator.ReportCreator.Abstract;
using PhoneBook.Report.Creator.ServiceModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Report.Creator.ReportCreator.Concrete
{
    public class LocationReportCreater : ILocationReportCreator
    {
        public async void ReportCreate(Guid reportId)
        {
            PersonService personService = new PersonService();
            List<Person> personList = await personService.GetAllPersonsWithContacts();
        }
    }
}
