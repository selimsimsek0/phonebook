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
    public class PersonController : ControllerBase
    {
        IPersonService _personService;
        IMapper _mapper;
        public PersonController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Person> personList = _personService.GetAllPerson();
            return Ok(personList);
        }

        [HttpGet]
        [Route("withcontactinfos")]
        public IActionResult GetWithContactInfos()
        {
            List<Person> personList = _personService.GetAllPersonWithContactInfos();
            return Ok(personList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            Person personList = _personService.GetPersonById(id);
            return Ok(personList);
        }

        [HttpGet("withcontactinfos{id}")]
        public IActionResult GetByIdWithContactInfos(Guid id)
        {
            Person person = _personService.GetPersonByIdWithContactInfos(id);
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddPersonDTO personDTO)
        {
            Person person = _mapper.Map<Person>(personDTO);
            bool addedResult = _personService.AddPerson(person);
            if (addedResult) return Ok();
            else return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Person person)
        {
            bool deleteResult = _personService.DeletePerson(person);
            if (deleteResult) return Ok();
            else return BadRequest();
        }

        [HttpDelete]
        [Route("deletebyid")]
        public IActionResult DeleteById(Guid id)
        {
            bool deleteResult = _personService.DeletePerson(id);
            if (deleteResult) return Ok();
            else return BadRequest();
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            bool updatedResult = _personService.UpdatePerson(person);
            if (updatedResult) return Ok();
            else return BadRequest();
        }

    }
}
