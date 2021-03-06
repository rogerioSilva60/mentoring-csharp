using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET.Business;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Hypermedia.Filters;
using System.Collections.Generic;

namespace RestWithASPNET.Controllers
{
    [ApiVersion("1")]
    //[ApiController]
    [Authorize("Bearer")]
    //[Route("api/v{version:apiVersion}/persons")]
    public class PersonController : IPersonController
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public ActionResult<List<PersonVO>> Get()
        {
            var persons = _personBusiness.FindAll();
            return Ok(persons);
        }

        [HttpGet("get-by-name")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult<string> GetByName(string name)
        {
            //var person = _personBusiness.FindById(id);
            //if (person == null) return NotFound();
            return Ok(name);
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult<PersonVO> GetById(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }
        
        [HttpPost]
        [ProducesResponseType((201), Type = typeof(PersonVO))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult<PersonVO> Post([FromBody] PersonVO person)
        {
            var newPerson = _personBusiness.Create(person);
            if (newPerson == null) return BadRequest();
            return CreatedAtAction("GetById", new { id = newPerson.Id } ,newPerson);
        }
        
        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PersonVO person)
        {
            var newPerson = _personBusiness.Update(person);
            if (newPerson == null) return BadRequest();
            return Ok(newPerson);
        }

        public override ActionResult Delete(long id)
        {
            PersonVO person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
