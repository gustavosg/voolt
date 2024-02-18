using Microsoft.AspNetCore.Mvc;

namespace Voolt_Test_Project.Controllers
{
    public class WebSiteHeaderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
