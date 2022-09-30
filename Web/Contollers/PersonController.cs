using Microsoft.AspNetCore.Mvc;
using TestDockerBD.ApiClient;

namespace DockerTestBDWeb.Contollers
{
    [Route("Person")]
    public class PersonController : Controller
    {
        readonly ILogger logger;
        readonly ApiClient client;
        public PersonController(ILogger<PersonController> logger, ApiClient client)
        {
            this.logger = logger;
            this.client = client;
        }

        [Route("Index")]
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Person> persons = (await client.PersonsAllAsync()).ToList();
            await Task.Delay(1);
            return View(persons);
        }
        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await client.PersonsDELETEAsync(id).ConfigureAwait(false);
            return Redirect("~/Person/Index");
        }
        [HttpGet]
        [Route("Post")]
        public async Task<IActionResult> Post([FromQuery] string name, [FromQuery] int age)
        {
            await client.PersonsPOSTAsync(name, age).ConfigureAwait(false);
            return Redirect("~/Person/Index");
        }
    }
}
