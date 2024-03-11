using BusinessLogic.Abstract;
using Microsoft.AspNetCore.Mvc;
using Ninject.Activation;

namespace Bilgi_SayarUI.Areas.Writers.Components
{
    public class EditorControlViewComponent:ViewComponent
    {
        private readonly IWriterService _writerService;

      
        public IViewComponentResult Invoke()
        {
    
            
            ViewBag.editor= HttpContext.Session.GetString("editorProfile");
            
            return View();

        }


    }
}
