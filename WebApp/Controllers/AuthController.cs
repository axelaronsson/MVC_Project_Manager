using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers;


public class AuthController(UserService userService, SignInManager<AppUser> signInManager) : Controller
{
    private readonly UserService _userService = userService;
    private readonly SignInManager<AppUser> _signInManager = signInManager;

    [Route("/SignUp")]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    [Route("/SignUp")]
    public async Task<IActionResult> SignUp(UserSignUpForm form)
    {
        if (!ModelState.IsValid)
        {
            return View(form);
        }

        if (await _userService.ExistsAsync(form.Email))
        {
            ModelState.AddModelError("Exists", "User already exists.");
            return View(form);
        }

        var result = await _userService.CreateAsync(form);
        if (result)
            return RedirectToAction("SignIn", "Auth");

        ModelState.AddModelError("NotCreated", "User was not created.");
        return View(result);
    }

    [Route("/SignIn")]
    public IActionResult SignIn(string returnUrl = "/")
    {
        ViewBag.ReturnUrl = returnUrl;
        ViewBag.ErrorMessage = "";
        return View();
    }

    [HttpPost]
    [Route("/SignIn")]
    public async Task<IActionResult> SignIn(UserSignInForm form, string returnUrl = "/")
    {

        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(form.Email, form.Password, false, false);
            if (result.Succeeded)
            {
                if (Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);

                return RedirectToAction("Index", "Home");
            }
        }

        ViewBag.ReturnUrl = returnUrl;
        ViewBag.ErrorMessage = "Incorrect email or password";
        return View(form);
    }

    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
