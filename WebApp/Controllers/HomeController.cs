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
                Name = "Website Redesign",
                Company = "GitLab Inc.",
                Description = "It is necessary to develop a website redesign in a corporate style."
            };

            var project2 = new ProjectModel
            {
                Id = 2,
                Name = "Landing Page",
                Company = "Bitbucket, Inc.",
                Description = "It is necessary to create a landing together with the development of design."
            };

            var project3 = new ProjectModel
            {
                Id = 3,
                Name = "Parser Development",
                Company = "Driveway, Inc.",
                Description = "Create a mobile application on iOS and Android devices."
            };

            var project4 = new ProjectModel
            {
                Id = 4,
                Name = "Parser Development",
                Company = "Driveway, Inc.",
                Description = "Create a mobile application on iOS and Android devices."
            };

            var project5 = new ProjectModel
            {
                Id = 5,
                Name = "Parser Development",
                Company = "Driveway, Inc.",
                Description = "Create a mobile application on iOS and Android devices."
            };

            var project6 = new ProjectModel
            {
                Id = 6,
                Name = "Parser Development",
                Company = "Driveway, Inc.",
                Description = "Create a mobile application on iOS and Android devices."
            };

            var project7 = new ProjectModel
            {
                Id = 7,
                Name = "Parser Development",
                Company = "Driveway, Inc.",
                Description = "Create a mobile application on iOS and Android devices."
            };

            var project8 = new ProjectModel
            {
                Id = 8,
                Name = "Parser Development",
                Company = "Driveway, Inc.",
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

            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
