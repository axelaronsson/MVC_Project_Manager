using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Services;

public class UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
{
    private readonly UserManager<AppUser> _userManager = userManager;

    public async Task<bool> ExistsAsync(string email)
    {
        if (await _userManager.Users.AnyAsync(u => u.Email == email))
            return true;
        return false;
    }

    public async Task<bool> CreateAsync(UserSignUpForm form)
    {
        if (form != null)
        {
            var appUser = new AppUser
            {
                UserName = form.Email,
                Email = form.Email,
                FirstName = form.FirstName,
                LastName = form.LastName,
                PhoneNumber = form.Phone
            };

            var result = await _userManager.CreateAsync(appUser, form.Password);
            return result.Succeeded;
        }

        return false;
    }
}
