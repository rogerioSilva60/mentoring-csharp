using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Business;
using RestWithASPNET.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/authors")]
    public class AuthorController : ControllerBase
    {
        private IAuthorBusiness _authorBusiness;

        public AuthorController(IAuthorBusiness authorBusiness)
        {
            _authorBusiness = authorBusiness;
        }

        [HttpGet]
        public ActionResult<List<AuthorVO>> GetAll()
        {
            var authors = _authorBusiness.FindAll();
            return Ok(authors);
        }
    }
}
