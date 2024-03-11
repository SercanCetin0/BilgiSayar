using Microsoft.AspNetCore.Mvc;

namespace Bilgi_SayarUI.Components
{
    public class FootherViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
