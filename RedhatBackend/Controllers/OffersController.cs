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
        [HttpGet]
        public async Task<IActionResult> GetOffer()
        {
            try
            {
                var offer = await CallSecure();
                return Ok(offer);
            }
            catch(Exception)
            {
                return BadRequest(new Offer()
                {
                    ErrorCode = 1,
                    Message = "Error"
                });
            }
        }

        private async Task<Offer> CallSecure()
        {
            var url = _configuration["SecureURL"];
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


    }
}
