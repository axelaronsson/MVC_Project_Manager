using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApp.Controllers
{
    public class HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IProjectService projectService) : Controller
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly IProjectService _projectService = projectService;

        [Authorize]
        public async Task<IActionResult> Index()
        {

            var userName = _userManager.GetUserName(User)!;
            var projects = await _projectService.GetAllAsync(userName);

            return View(projects);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ProjectModel project)
        {
            if (ModelState.IsValid)
            {
                var result = await _projectService.Create(project);
                if (result)
                    return RedirectToAction("Index", "Home");
                return StatusCode(500);
            }

            return View(project);
        }

        [Route("Home/GetUpdateForm/{id}")]
        [Authorize]
        public async Task<IActionResult> GetUpdateForm(string id)
        {
            var project = await _projectService.GetProject(id);
            if (project != null)
            {
                return PartialView("Partials/_Update", project);
            }

            return StatusCode(404);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Update(ProjectModel project)
        {
            if (ModelState.IsValid)
            {
                //throw new InvalidOperationException("error blabla");
                var result = await _projectService.Update(project);
                if (result)
                    return RedirectToAction("Index", "Home");
  
                return StatusCode(500);
            }

            return View(project);

        }


        public IActionResult LogOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
