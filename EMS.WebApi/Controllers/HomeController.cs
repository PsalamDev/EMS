using Microsoft.AspNetCore.Mvc;

namespace EMS.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
