using BusinessLogic.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bilgi_SayarUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
       
            private readonly ICommentService _commentService;

            public CommentController(ICommentService commentService)
            {
            _commentService = commentService;
            }

            public IActionResult Index()
            {
                var data = _commentService.GetAll();
                return View(data);
            }

            [HttpGet]
            public IActionResult UpdateComment(int id)
            {
            
                var model = _commentService.Get(id);
               
                _commentService.Update(model);
                return RedirectToAction("Index");
            
           
        }




    

            [HttpGet]
            public IActionResult DeleteComment(int id)
            {
                if (ModelState.IsValid)
                {
                    var model = _commentService.Get(id);
                    _commentService.Delete(model);
                    return RedirectToAction("Index");
                }
                return BadRequest(ModelState);

            }

        }
    }

