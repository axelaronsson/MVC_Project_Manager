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
        public IActionResult Index()
        {

            var userId = _userManager.GetUserId(User);
            var userName = _userManager.GetUserName(User)!;
            var projects = _projectService.GetAllAsync(userName);
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
                TempData["isCreated"] = true;
                _projectService.Create(project);
                return RedirectToAction("Index", "Home");
            }

            //Console.WriteLine(project.Description);
            //if (project.Client != null) { 
            //    TempData["isCreated"] = true;
            //    return RedirectToAction("Index", "Home");
            //}
            return View(project);
        }

        [Route("Home/GetUpdateForm/{id}")]
        public IActionResult GetUpdateForm(string id)
        {
            var project = _projectService.GetProject(id);
            if (project != null)
            {
                return PartialView("Partials/_Update", project);
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult Update(ProjectModel project)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //throw new InvalidOperationException("error blabla");
                    var result = _projectService.Update(project);
                    if (result)
                        return RedirectToAction("Index", "Home");
                    return StatusCode(404);
                    
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return StatusCode(500);
                }
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
