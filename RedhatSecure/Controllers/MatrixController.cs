using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RedhatSecure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatrixController : ControllerBase
    {
        [HttpGet]
        public IActionResult CallMatrix()
        {
            return Ok("Matrix is called");
        }
    }
}
