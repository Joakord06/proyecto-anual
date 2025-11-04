using Microsoft.AspNetCore.Mvc;

namespace LayeredApp.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}