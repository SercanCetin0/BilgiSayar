using BusinessLogic.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Bilgi_SayarUI.Components
{
    public class CartViewComponent : ViewComponent
    {
        private readonly IEntryService _entryService;

        public IViewComponentResult Invoke()
        {
          //  var data = _entryService.GetByCategory();
            return View();
        }

    }
}
