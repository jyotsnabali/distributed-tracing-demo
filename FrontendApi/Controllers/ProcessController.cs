using Microsoft.AspNetCore.Mvc;

namespace FrontendApi.Controllers
{
    [ApiController]
    [Route("process")]
    public class ProcessController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _integrationApiUrl;

        public ProcessController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _integrationApiUrl = configuration["DownstreamServices:IntegrationApiUrl"]
                ?? throw new InvalidOperationException("DownstreamServices:IntegrationApiUrl is not configured.");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using var client = _httpClientFactory.CreateClient();
            using var response = await client.GetAsync($"{_integrationApiUrl}/process");
            response.EnsureSuccessStatusCode();

            return Ok("Frontend processed request");
        }
    }
}
