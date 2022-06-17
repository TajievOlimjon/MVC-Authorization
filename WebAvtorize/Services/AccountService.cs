using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WebAvtorize.Areas.Admin.Models;
using WebAvtorize.Models;

namespace WebAvtorize.Services
{
    public class AccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountService(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<IdentityUser> Login(Login model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null) return null;

            var validatePassword = new PasswordValidator<IdentityUser>();
            var result = await validatePassword.ValidateAsync(_userManager, user, model.Password);
            if (result.Succeeded == false) return null;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.UserName)
            };

            await _userManager.AddClaimsAsync(user, claims);

            return user;
        }

        public async Task<bool> Register(Register register)
        {
            var user = new IdentityUser
            {
                Email = register.Email,
                UserName = register.UserName
            };
            var result = await _userManager.CreateAsync(user);
            return result.Succeeded;
        }
    }
}
