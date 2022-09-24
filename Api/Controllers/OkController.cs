using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DockerTestBD.Api.Controllers
{
    /// <summary>
    /// Test connection
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OkController : ControllerBase
    {
        /// <summary>
        /// method for connect
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string OK() => "OK";
    }
}
