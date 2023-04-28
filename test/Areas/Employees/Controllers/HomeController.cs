using Microsoft.AspNetCore.Mvc;

namespace test.Areas.Employees.Controllers
{
    public class HomeController : Controller
    {
        [Area("Employees")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
