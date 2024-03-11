using Microsoft.AspNetCore.Mvc;

namespace BilgiSayar.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
