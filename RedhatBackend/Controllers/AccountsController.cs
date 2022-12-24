using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RedhatBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        [HttpGet("Name")]
        public IActionResult GetName([FromQuery] string name)
        {
            return Ok($"From BE: Name is {name}");
        }
    }
}
