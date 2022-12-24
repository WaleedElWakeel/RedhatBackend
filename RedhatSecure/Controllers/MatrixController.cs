using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RedhatSecure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatrixController : ControllerBase
    {
        [HttpGet("staging")]
        public IActionResult CallMatrixStaging()
        {
            return Ok("Staging Matrix is called");
        }

        [HttpGet("production")]
        public IActionResult CallMatrixProd()
        {
            return Ok("Production Matrix is called");
        }
    }
}
