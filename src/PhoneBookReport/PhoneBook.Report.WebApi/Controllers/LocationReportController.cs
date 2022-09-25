using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Report.Business.Abstract;
using PhoneBook.Report.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Report.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationReportController : ControllerBase
    {
        ILocationReportService _locationReportService;
        public LocationReportController(ILocationReportService locationReportService)
        {
            _locationReportService = locationReportService;
        }

        
    }
}
