using BusinessLogic.Abstract;
using Entities.Concrete;
using Entities.Dtos.EntryDto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Identity.Client;

using System.Security.Cryptography;

namespace Bilgi_SayarUI.Areas.Writers.Controllers
{
    [Area("Writers")]
    public class AuthorController : Controller
    {
        private readonly IWriterService _writerService;
        private readonly ICategoryService _categoryService;
        private readonly IEntryService _entryService;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public AuthorController(IWriterService writerService, ICategoryService categoryService, IEntryService entryService, IWebHostEnvironment hostingEnvironment)
        {
            _writerService = writerService;
            _categoryService = categoryService;
            _entryService = entryService;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index([FromQuery] string? editorProfile)

        {

            if (editorProfile is not null)
            {
                HttpContext.Session.SetString("editorProfile", editorProfile);
                var editor = _writerService.GetWriterByUsername(editorProfile);

                return View(editor);
            }

            var username = HttpContext.Session.GetString("editorUsername");
            var data = _writerService.GetWriterByUsername(username);

            return View(data);
        }

        public IActionResult AddNewEntry()
        {
            //    var username = HttpContext.Session.GetString("editorUsername");
            //    var data = _writerService.GetWriterByUsername(username);

            var category = _categoryService.GetAll();
            var datas = new EntryDto() { Categories = category };
            return View(datas);



        }

        [HttpPost]
        public IActionResult AddNewEntry(IFormFile Image, [FromForm] EntryDto entry)
        {



            /**/
            var username = HttpContext.Session.GetString("editorUsername");
            var data = _writerService.GetWriterByUsername(username).WriterId;






            string wwwrootPath = _hostingEnvironment.WebRootPath;
            string fileName = Path.GetFileName(Image.FileName);
            string filePath = Path.Combine(wwwrootPath, "image", fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Image.CopyTo(fileStream);
            }


            var addentry = new Entry()
            {
                CategoryId = entry.CategoryId,
                Title = entry.Title,
                İmage = Image.FileName,
                Text = entry.Text,
                WriterId = data,
                ReleaseDate = DateTime.Now,
                Statu = false



            };


            _entryService.Add(addentry);
            return RedirectToAction("Index");

            // NOrmla profil görüntüleme ile sayfa sahibinin görüntülemesini değiştir
            // FluentValidation Ekle (Kayıt ol , Giriş yap - ürün ekle - profil düzenleye uygulanacak.)






        }



        [HttpGet]
        public IActionResult UpdateProfile()
        {
            var username = HttpContext.Session.GetString("editorUsername");
            var data = _writerService.GetWriterByUsername(username);
            return View(data);
        }
        [HttpPost]
        public IActionResult UpdateProfile(Writer writer)
        {
            var username = HttpContext.Session.GetString("editorUsername");
            if (writer.WriterImage == null)
            {
                var image = _writerService.GetWriterByUsername(username).WriterImage;
                writer.WriterImage = image;
            }

            _writerService.Update(writer);


            return RedirectToAction("Index");
        }



    }
}
