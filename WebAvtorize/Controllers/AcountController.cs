using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebAvtorize.DataDB;
using WebAvtorize.Models;

namespace WebAvtorize.Controllers
{
    public class AcountController : Controller
    {
        private readonly DataContext context;

        public AcountController(DataContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public IActionResult Login(string? returnUrl)
        {

            return View(new Login() { ReturnUrl=returnUrl});
        }

        //[HttpPost]
        //public async Task<IActionResult> Login(Login model)
        //{

        //    if (ModelState.IsValid)
        //    {

        //        var user = await context.Logins.FirstOrDefaultAsync(user => user.UserName == model.UserName && user.Password == model.Password);
        //        if (user != null)
        //        {
        //            var claim = new List<Claim>()
        //            {
        //              new Claim(ClaimTypes.Name, model.UserName),
        //              new Claim(ClaimTypes.Email,"olim@mail.ru"),
        //              new Claim(ClaimTypes.Role,"Admin")
        //            };

        //            var userIdentity = new ClaimsIdentity(claim, "UserIdentity");
        //            var userPrincipial = new ClaimsPrincipal(userIdentity);

        //            await HttpContext.SignInAsync(userPrincipial, new AuthenticationProperties

        //            {
        //                ExpiresUtc = DateTime.UtcNow.AddMinutes(1),
        //                IsPersistent = true
        //            });

        //            if (model.ReturnUrl != null)
        //            {
        //                return Redirect(model.ReturnUrl);
        //            }

        //            return RedirectToAction("Index", "Home");
        //        }

        //        else if (user == null)
        //        {

        //            await context.Logins.AddAsync(model);
        //            await context.SaveChangesAsync();


        //            user = await context.Logins.FirstOrDefaultAsync(user => user.UserName == model.UserName && user.Password == model.Password);
        //            if (user != null)
        //            { 
        //               var claim = new List<Claim>()
        //              {
        //               new Claim(ClaimTypes.Name,model.UserName),
        //               new Claim(ClaimTypes.Email,"olim@mail.ru"),
        //               new Claim(ClaimTypes.Role,"Admin")
        //              };

        //               var userIdentity = new ClaimsIdentity(claim, "UserIdentity");
        //               var userPrincipial = new ClaimsPrincipal(userIdentity);
                       
        //               await HttpContext.SignInAsync(userPrincipial, new AuthenticationProperties
        //               {
        //                ExpiresUtc = DateTime.UtcNow.AddMinutes(1),
        //                IsPersistent = true
        //               });

        //               if (model.ReturnUrl != null)
        //               {
        //                   return Redirect(model.ReturnUrl);
        //               }

        //                 return RedirectToAction("Index", "Home");
        //            }

        //        }
        //    }  
            
            
        //    return View(model);
           
        //}

        //public async Task<IActionResult> Logout()
        //{
        //    await HttpContext.SignOutAsync();
        //    return RedirectToAction("Index", "Home");
        //}

        //public IActionResult Accessdenied()
        //{
        //    return View();
        //}
    }
}
