using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET.Models;
using RestWithASPNET.Services;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var persons = _personService.FindAll();
            return Ok(persons);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            var newPerson = _personService.Create(person);
            if (newPerson == null) return BadRequest();
            return Ok(newPerson);
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            var newPerson = _personService.Update(person);
            if (newPerson == null) return BadRequest();
            return Ok(newPerson);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Person person = _personService.FindById(id);
            if (person == null) return NotFound();
            _personService.Delete(id);
            return NoContent();
        }
    }
}
