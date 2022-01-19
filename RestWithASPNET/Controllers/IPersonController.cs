using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/persons")]
    public abstract class IPersonController : ControllerBase
    {
        /// <summary>
        /// Deletes a specific PersonItem.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public abstract ActionResult Delete(long id);
    }
}
