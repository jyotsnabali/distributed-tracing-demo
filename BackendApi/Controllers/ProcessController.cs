using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("process")]
    public class ProcessController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Backend processed request");
        }
    }
}
