using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Report.Business.Abstract;
using PhoneBook.Report.Entity.DTO;
using PhoneBook.Report.Entity.Entity;
using System;
using System.Collections.Generic;

namespace PhoneBook.Report.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationReportController : ControllerBase
    {
        ILocationReportService _locationReportService;
        IMapper _mapper;
        public LocationReportController(ILocationReportService locationReportService, IMapper mapper)
        {
            _locationReportService = locationReportService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<LocationReport> reportList = _locationReportService.GetAllReport();
            List<LocationReportDTO> reportListDTO = _mapper.Map<List<LocationReportDTO>>(reportList);
            return Ok(reportListDTO);
        }

        [HttpGet("reportdetail{id}")]
        public IActionResult Get(Guid id)
        {
            LocationReport report = _locationReportService.GetReport(id);
            return Ok(report);
        }

        [HttpGet("createreportinexcel")]
        public IActionResult CreateReportInExcel()
        {
            bool createResult = _locationReportService.CreateExcelReport();
            return Ok();
        }

    }
}
