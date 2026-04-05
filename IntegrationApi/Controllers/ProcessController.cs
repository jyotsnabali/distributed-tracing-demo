using Microsoft.AspNetCore.Mvc;

namespace IntegrationApi.Controllers
{
    [ApiController]
    [Route("process")]
    public class ProcessController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ProcessController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _httpClient.GetAsync(
                "https://BACKEND-APP-NAME.azurewebsites.net/process"
            );

            return Ok("Integration processed request");
        }
    }
}
