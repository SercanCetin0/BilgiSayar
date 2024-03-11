using Microsoft.AspNetCore.Mvc;

namespace BilgiSayar.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
