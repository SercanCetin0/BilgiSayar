using Bilgi_SayarUI.Areas.Admin.DependencyResolvers.Ninject;
using BusinessLogic.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Ninject;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;

namespace Bilgi_SayarUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;


        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService ;

        }



        public IActionResult Index()
        {
            var data = _categoryService.GetAll();

            return View(data);

        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory([FromForm]Category category)
        {
            
                _categoryService.Add(category);
                return RedirectToAction("Index");
            
           
        }

        [HttpGet]
        public IActionResult DeleteCategory(int id) 
        {
            
                var value =_categoryService.Get(id);
                _categoryService.Delete(value);
                return RedirectToAction("Index");
            
          
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value=_categoryService.Get(id);

            return View(value);
       
        
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            
            _categoryService.Update(category);

                return RedirectToAction("Index");
            
            

        }

    }
}
