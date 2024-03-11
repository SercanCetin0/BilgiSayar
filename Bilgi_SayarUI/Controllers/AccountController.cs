using Bilgi_SayarUI.Models;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bilgi_SayarUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signManager;

        public AccountController(UserManager<IdentityUser> userManager , SignInManager<IdentityUser> signManager)
        {
            _userManager = userManager;
            _signManager = signManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AccessDenied([FromQuery(Name = "ReturnUrl")] string returnUrl)
        {

            return View();


        }

        public IActionResult Login([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
        {
            return View(new LoginModel() { ReturnUrl = ReturnUrl });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginModel login)
        {
            

            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByNameAsync(login.Name);
               
                if (user is not null)
                {
                    await _signManager.SignOutAsync();//eğer oturum hali hazırda çıksa sonlandır.
                    if ((await _signManager.PasswordSignInAsync(user, login.Password, false, false)).Succeeded)// giriş yap başarılıysa
                    {
                        HttpContext.Session.SetString("editorUsername", user.UserName);
                        
                        return Redirect(login.ReturnUrl ?? "/");
                    }
                }
                ModelState.AddModelError("Error", "Invalid username or password");


            }
            return View();
        }

        public async Task<IActionResult> Logout([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")// Beni ana sayfaya tekrar at dedim
        {
            await _signManager.SignOutAsync();// çıkış
         
            return Redirect(ReturnUrl);
        }

        public IActionResult Register()
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm]UserRegisterDto userRegister)
        {
            var user = new IdentityUser()
            {
                UserName = userRegister.Username,
                Email = userRegister.Email
            };

            var result= await _userManager.CreateAsync(user,userRegister.Password);
            if (result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "Editor");// eklenen kullanıcın rolu Editor olacak
                if (roleResult.Succeeded) { return RedirectToAction("Index", new { ReturnUrl = "/" }); }//Anasayfya yönlendirdik
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);//hata varsa hataları modele yükle
                }


            }
            return View("");
        }

    
    }
}
