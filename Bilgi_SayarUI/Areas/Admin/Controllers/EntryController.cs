using Bilgi_SayarUI.Models;
using BusinessLogic.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bilgi_SayarUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EntryController : Controller
    {
        private readonly IEntryService _entryService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public EntryController(IEntryService entryService, IWebHostEnvironment hostingEnvironment)
        {
            _entryService = entryService;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index(string? search, bool? statu)
        {
            var data=_entryService.GetWantedEntry(search, statu);
          //  var data = _entryService.GetEntryByDesc();
            return View(data);

        }
        
        public IActionResult GetPassiveEntry()
        {
            var data = _entryService.GetPassiveEntries();
            return RedirectToAction("Index");
        }




        [HttpGet]
        public IActionResult UpdateEntry(int id)
        {

            var model = _entryService.Get(id);         
            _entryService.Update(model);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult DeleteEntry(int id)
        {


            var model = _entryService.Get(id);


            string wwwrootPath = _hostingEnvironment.WebRootPath;
            string imagePath = Path.Combine(wwwrootPath, "image", model.İmage);
            System.IO.File.Delete(imagePath);
            _entryService.Delete(model);
            return RedirectToAction("Index");

        }

    }
}
