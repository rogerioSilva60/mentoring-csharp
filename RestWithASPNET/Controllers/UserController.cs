using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Business.Implementations;
using RestWithASPNET.Data.VO;

namespace RestWithASPNET.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpPost]
        public ActionResult<UserVO> Create([FromBody] UserVO user)
        {
            if (user == null) return BadRequest("Invalid user request");
            if (!_userBusiness.Create(user)) return BadRequest("Failed to register the user");
            return Ok();
        }
    }
}
