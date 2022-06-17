using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebAvtorize.Areas.Admin.Models;
using WebAvtorize.DataDB;
using WebAvtorize.Models;
using WebAvtorize.Services;

namespace WebAvtorize.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AcountController : Controller
    {
        
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly AccountService accountService;       
        public AcountController(AccountService accountService, SignInManager<IdentityUser> signInManager)
        {
            this.accountService = accountService;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            return View(new Login() { ReturnUrl = returnUrl });
        }


        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {

            var account = await accountService.Login(model);
            if (account == null) return View(model);
            await  _signInManager.SignInAsync(account, false, null);
            if (!string.IsNullOrEmpty(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }
            return View("Index","Home");
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View(new Register());
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            if (!ModelState.IsValid) return View(model);
            await   accountService.Register(model);
            return RedirectToAction("Index", "Student");

           
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home","Admin");
        }


        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
