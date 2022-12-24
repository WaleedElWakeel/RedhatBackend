using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace RedhatBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public OffersController(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        #region GET URL
        [HttpGet]
        public async Task<IActionResult> GetOffer()
        {
            try
            {
                var offer = await CallSecure();
                return Ok(offer);
            }
            catch (Exception e)
            {
                return BadRequest(new Offer()
                {
                    ErrorCode = 1,
                    Message = e.Message
                });
            }
        }

        private async Task<Offer> CallSecure()
        {
            var url = _configuration["SecureURL"];
            if (string.IsNullOrEmpty(url))
                return new()
                {
                    ErrorCode = 1,
                    Message = "URL empty",
                    EAIMessage = null
                };
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetStringAsync(url);
            return new()
            {
                ErrorCode = 0,
                Message = "Success",
                EAIMessage = result
            };
        }

        class Offer
        {
            public int ErrorCode { get; set; }
            public string Message { get; set; }
            public string EAIMessage { get; set; }
        } 
        #endregion

        [HttpGet("test")]
        public IActionResult Test()
        {
            var result = "Fail";
            if (Directory.Exists("/config"))
                result = "/Config";
            else if(Directory.Exists(Directory.GetCurrentDirectory() + "/Config"))
                result = "Directory.GetCurrentDirectory()/Config";

            return Ok(result);
        }

        [HttpGet("details")]
        public IActionResult Details()
        {
            var currentDir = Directory.GetCurrentDirectory();
            var directories = Directory.GetDirectories(currentDir);
            var files = Directory.GetFiles(currentDir);

            return Ok(new { 
                current= currentDir, 
                dirs = string.Join(", ",directories), 
                files = string.Join(", ",files)
            });
        }


    }
}
