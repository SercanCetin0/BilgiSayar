using Microsoft.AspNetCore.Mvc;

namespace Bilgi_SayarUI.Areas.Admin.Components
{
    public class SidebarViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
