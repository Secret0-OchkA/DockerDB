using Microsoft.AspNetCore.Mvc;
using TestDockerBD.ApiClient;

namespace DockerTestBDWeb.Contollers
{
    [Route("Company")]
    public class CompanyController : Controller
    {
        readonly ILogger logger;
        readonly ApiClient client;
        public CompanyController(ILogger<CompanyController> logger, ApiClient client)
        {
            this.logger = logger;
            this.client = client;
        }

        // GET: CompanyController
        [Route("Index")]
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Company> companies = (await client.CompaniesAllAsync()).ToList();
            return View(companies);
        }
        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await client.CompaniesDELETEAsync(id).ConfigureAwait(false);
            return Redirect("~/Company/Index");
        }
        [HttpGet]
        [Route("Post")]
        public async Task<IActionResult> Post([FromQuery] string name)
        {
            await client.CompaniesPOSTAsync(name).ConfigureAwait(false);
            return Redirect("~/Company/Index");
        }
    }
}
