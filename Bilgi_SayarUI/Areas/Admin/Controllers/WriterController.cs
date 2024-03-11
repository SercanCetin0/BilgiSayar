using BusinessLogic.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace Bilgi_SayarUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class WriterController : Controller
    {
        private readonly IWriterService _writerService;

        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        // Burayı nasıl yapacağımı düşünüyorum
        // Muhtemelen Banner yapıcaz banlanıp banlanmıcak 
        // Veya Writer Onaylamada olur
        public IActionResult Index()
        {
            var data =_writerService.GetAll();
            return View(data);
        }

        [HttpGet]
        public IActionResult DeleteWriter(int id)
        {
            var value=_writerService.Get(id);
            _writerService.Delete(value);
            return RedirectToAction("Index");
        }


    }
}
