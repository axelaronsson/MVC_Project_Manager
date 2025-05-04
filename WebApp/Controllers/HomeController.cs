using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class HomeController(UserManager<AppUser> userManager, ProjectService projectService) : Controller
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly ProjectService _projectService = projectService;

        [Authorize]
        public IActionResult Index()
        {

            var userId = _userManager.GetUserId(User);
            var projects = _projectService.GetAllAsync();
            Console.WriteLine(userId);
            ViewBag.isCreated = TempData["isCreated"];

            return View(projects);
        }

        [HttpPost]
        public IActionResult Create(ProjectModel project)
        {
            if (ModelState.IsValid)
            {
                bool created = project.Completed;
                Console.WriteLine(created);
                TempData["isCreated"] = true;
                return RedirectToAction("Index", "Home");
            }
            //Console.WriteLine(project.Description);
            //if (project.Client != null) { 
            //    TempData["isCreated"] = true;
            //    return RedirectToAction("Index", "Home");
            //}
            return View(project);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
