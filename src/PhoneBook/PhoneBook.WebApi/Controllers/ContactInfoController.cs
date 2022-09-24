using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Business.Abstract;
using PhoneBook.Entity.DTO;
using PhoneBook.Entity.Entity;
using System;
using System.Collections.Generic;

namespace PhoneBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        IContactInfoService _contactInfoService;
        IMapper _mapper;
        public ContactInfoController(IContactInfoService contactInfoService, IMapper mapper)
        {
            _contactInfoService = contactInfoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ContactInfo> contactInfoList = _contactInfoService.GetAllContactInfo();
            return Ok(contactInfoList);
        }

        [HttpGet]
        [Route("withperson")]
        public IActionResult GetWithPersons()
        {
            List<ContactInfo> contactInfoList = _contactInfoService.GetAllContactInfoWithPerson();
            return Ok(contactInfoList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            ContactInfo contactInfoList = _contactInfoService.GetContactInfoById(id);
            return Ok(contactInfoList);
        }

        [HttpGet("withperson{id}")]
        public IActionResult GetByIdWithPersons(Guid id)
        {
            ContactInfo contactInfoList = _contactInfoService.GetContactInfoByIdWithPerson(id);
            return Ok(contactInfoList);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddContactInfoDTO contactInfoDTO)
        {
            ContactInfo contactInfo = _mapper.Map<ContactInfo>(contactInfoDTO);
            bool addedResult = _contactInfoService.AddContactInfo(contactInfo);
            if (addedResult) return Ok();
            else return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] ContactInfo contactInfo)
        {
            bool deleteResult = _contactInfoService.DeleteContactInfo(contactInfo);
            if (deleteResult) return Ok();
            else return BadRequest();
        }

        [HttpDelete]
        [Route("deletebyid")]
        public IActionResult DeleteById(Guid id)
        {
            bool deleteResult = _contactInfoService.DeleteContactInfo(id);
            if (deleteResult) return Ok();
            else return BadRequest();
        }

        [HttpPut]
        public IActionResult Put([FromBody] ContactInfo contactInfo)
        {
            bool updatedResult = _contactInfoService.UpdateContactInfo(contactInfo);
            if (updatedResult) return Ok();
            else return BadRequest();
        }

    }
}
