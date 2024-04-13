using BusinessLogic.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/writer")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        private readonly IWriterService _writerService;

        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet]
        public IActionResult GetAllCategory()
        {

            var writer = _writerService.GetAll();
            return Ok(writer);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCategoryById([FromRoute(Name = "id")] int id)
        {
            var writer = _writerService.Get(id);
            return Ok(writer);

        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] Writer writer)
        {


            _writerService.Add(writer);
            return StatusCode(201, writer);

        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteCategory([FromRoute(Name = "id")] int id)
        {
            if (id == null) { throw new Exception("Id yok"); }
            var writer = _writerService.Get(id);

            _writerService.Delete(writer);
            return Ok(writer);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneCategory([FromBody] Writer writer)
        {
            _writerService.Update(writer);
            return Ok(writer);

        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneCategory([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Writer> writerPatch)
        {
            var writer = _writerService.Get(id);
            if (writer == null) { throw new Exception("Bulunamadı"); }

            writerPatch.ApplyTo(writer);
            _writerService.Update(writer);

            return Ok(writer);


        }


    }
}
