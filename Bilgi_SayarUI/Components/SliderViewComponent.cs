using Microsoft.AspNetCore.Mvc;

namespace Bilgi_SayarUI.Components
{
    public class SliderViewComponent:ViewComponent
    {

        public IViewComponentResult Invoke()
        { 
            return View(); 
        
        }


    }
}
