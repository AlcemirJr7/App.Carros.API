using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Indentity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _singInManager;
        public AuthenticateService(UserManager<AppUser> userManager, SignInManager<AppUser> singInManager)
        {
            _userManager = userManager;
            _singInManager = singInManager;

        }
        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            var result = await _singInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);

            return result.Succeeded;

        }
        public async Task<bool> RegisterUserAsync(string email, string password)
        {
            var applicationUser = new AppUser()
            {
                UserName = email,
                Email = email,

            };

            var result = await _userManager.CreateAsync(applicationUser, password);

            if (result.Succeeded)
            {
                await _singInManager.SignInAsync(applicationUser, isPersistent: false);
            }

            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _singInManager.SignOutAsync();
        }


    }
}
