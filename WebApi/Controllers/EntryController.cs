using BusinessLogic.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/entry")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly IEntryService _entryService;

        public EntryController(IEntryService entryService)
        {
            _entryService = entryService;
        }

        [HttpGet]
        public IActionResult GetAllCategory()
        {

            var entry = _entryService.GetAll();
            return Ok(entry);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCategoryById([FromRoute(Name = "id")] int id)
        {
            var entry = _entryService.Get(id);
            return Ok(entry);

        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] Entry entry)
        {


            _entryService.Add(entry);
            return StatusCode(201, entry);

        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteCategory([FromRoute(Name = "id")] int id)
        {
            if (id == null) { throw new Exception("Id yok"); }
            var entry = _entryService.Get(id);

            _entryService.Delete(entry);
            return Ok(entry);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneCategory([FromBody] Entry entry)
        {
            _entryService.Update(entry);
            return Ok(entry);

        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneCategory([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Entry> entryPatch)
        {
            var entry = _entryService.Get(id);
            if (entry == null) { throw new Exception("Bulunamadı"); }

            entryPatch.ApplyTo(entry);
            _entryService.Update(entry);

            return Ok(entry);


        }






    }
}
