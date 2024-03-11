using Microsoft.AspNetCore.Mvc;

namespace BilgiSayar.Areas.Admin.Components
{
    public class SideBarViewComponent:ViewComponent
    {

        public IViewComponentResult Invoke() { 
            return View(); 
        }

    }
}
