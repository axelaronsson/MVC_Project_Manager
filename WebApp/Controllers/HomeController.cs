using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            var project = new ProjectModel
            {
                Id = 1,
                ProjectName = "Website Redesign",
                Client = "GitLab Inc.",
                Description = "It is necessary to develop a website redesign in a corporate style."
            };

            var project2 = new ProjectModel
            {
                Id = 2,
                ProjectName = "Landing Page",
                Client = "Bitbucket, Inc.",
                Description = "It is necessary to create a landing together with the development of design."
            };

            var project3 = new ProjectModel
            {
                Id = 3,
                ProjectName = "Parser Development",
                Client = "Driveway, Inc.",
                Description = "Create a mobile application on iOS and Android devices."
            };

            var project4 = new ProjectModel
            {
                Id = 4,
                ProjectName = "Parser Development",
                Client = "Driveway, Inc.",
                Description = "Create a mobile application on iOS and Android devices."
            };

            var project5 = new ProjectModel
            {
                Id = 5,
                ProjectName = "Parser Development",
                Client = "Driveway, Inc.",
                Description = "Create a mobile application on iOS and Android devices."
            };

            var project6 = new ProjectModel
            {
                Id = 6,
                ProjectName = "Parser Development",
                Client = "Driveway, Inc.",
                Description = "Create a mobile application on iOS and Android devices."
            };

            var project7 = new ProjectModel
            {
                Id = 7,
                ProjectName = "Parser Development",
                Client = "Driveway, Inc.",
                Description = "Create a mobile application on iOS and Android devices."
            };

            var project8 = new ProjectModel
            {
                Id = 8,
                ProjectName = "Parser Development",
                Client = "Driveway, Inc.",
                Description = "Create a mobile application on iOS and Android devices."
            };

            var list = new List<ProjectModel> {
                project,
                project2,
                project3,
                project4,
                //project5,
                //project6,
                //project7,
                //project8,
            };

            ViewBag.isCreated = TempData["isCreated"];

            return View(list);
        }

        [HttpPost]
        public IActionResult Create(ProjectModel project)
        {
            Console.WriteLine(project.Description);
            if (project.Client != null) { 
                TempData["isCreated"] = true;
                return RedirectToAction("Index", "Home");
            }
            return View(project);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
