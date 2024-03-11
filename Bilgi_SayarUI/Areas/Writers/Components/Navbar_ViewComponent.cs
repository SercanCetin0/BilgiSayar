using Microsoft.AspNetCore.Mvc;

namespace Bilgi_SayarUI.Areas.Writers.Components
{
    public class Navbar_ViewComponent:ViewComponent
    {

        public IViewComponentResult Invoke() 
        {
        return View();
        
        }

    }
}
