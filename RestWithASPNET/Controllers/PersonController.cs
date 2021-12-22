using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET.Business;
using RestWithASPNET.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/person")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }

        [HttpGet]
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
        public ActionResult<string> GetByName(string name)
        {
            //var person = _personBusiness.FindById(id);
            //if (person == null) return NotFound();
            return Ok(name);
        }

        [HttpGet("{id}")]
        public ActionResult<PersonVO> GetById(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] PersonVO person)
        {
            var newPerson = _personBusiness.Create(person);
            if (newPerson == null) return BadRequest();
            return Ok(newPerson);
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] PersonVO person)
        {
            var newPerson = _personBusiness.Update(person);
            if (newPerson == null) return BadRequest();
            return Ok(newPerson);
        }

        /// <summary>
        /// Deletes a specific PersonItem.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            PersonVO person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
