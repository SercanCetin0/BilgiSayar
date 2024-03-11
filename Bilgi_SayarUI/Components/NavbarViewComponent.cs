using BusinessLogic.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Bilgi_SayarUI.Components
{
    public class NavbarViewComponent:ViewComponent
    {

        private readonly ICategoryService _categoryService;

        public NavbarViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryService.GetAll();
           
            return View(categories);

        }

    }
}
