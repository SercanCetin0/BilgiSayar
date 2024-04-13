using BusinessLogic.Abstract;
using Entities.Concrete;
using Entities.ErrorModels.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace WebApi.Controllers
{
   
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAllCategory()
        {
           
            var categoies = _categoryService.GetAll();
            return Ok(categoies);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCategoryById([FromRoute(Name ="id")]int id) 
        {
            var category = _categoryService.Get(id);
            return Ok(category);

        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody]Category category)
        {
            

            _categoryService.Add(category);
            return StatusCode(201,category);

        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteCategory([FromRoute(Name = "id")] int id)
        {
            if(id == null) { throw new Exception("Id yok"); }
            var category=_categoryService.Get(id);

            _categoryService.Delete(category);
            return Ok(category);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneCategory([FromBody]Category category)
        {
            _categoryService.Update(category);
            return Ok(category);
            
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneCategory([FromRoute(Name = "id")] int id, [FromBody]JsonPatchDocument<Category> categoryPatch)
        {
            var category = _categoryService.Get(id);
            if(category == null) { throw new Exception("Bulunamadı"); }

            categoryPatch.ApplyTo(category);
            _categoryService.Update(category);

            return Ok(category);


        }



    }
}
