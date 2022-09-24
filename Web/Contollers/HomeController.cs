using Microsoft.AspNetCore.Mvc;

namespace DockerTestBDWeb.Contollers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
