using Microsoft.AspNetCore.Mvc;

namespace Warehouse.api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
