using Microsoft.AspNetCore.Mvc;

namespace FrontendApi.Controllers
{
    [ApiController]
    [Route("process")]
    public class ProcessController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProcessController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using var client = _httpClientFactory.CreateClient();
            using var response = await client.GetAsync(
                "https://INTEGRATION-APP-NAME.azurewebsites.net/process"
            );

            return Ok("Frontend processed request");
        }
    }
}
