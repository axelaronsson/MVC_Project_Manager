using WebApp.Data;
using WebApp.Models;

namespace WebApp.Services;

public class ProjectService(DataContext dataContext)
{
    private readonly DataContext _dataContext = dataContext;

    public bool Create(ProjectModel project)
    {
        //_dataContext.Projects.All(x => x.Id == project.Id);
        _dataContext.Projects.Add(project);
        _dataContext.SaveChanges();
        return true;
    }

    public IEnumerable<ProjectModel> GetAllAsync()
    {
        var project = new ProjectModel
        {
            Id = 1,
            ProjectName = "Website Redesign",
            Client = "GitLab Inc.",
            Description = "It is necessary to develop a website redesign in a corporate style.",
            Completed = true
        };

        var project2 = new ProjectModel
        {
            Id = 2,
            ProjectName = "Landing Page",
            Client = "Bitbucket, Inc.",
            Description = "It is necessary to create a landing together with the development of design.",
            Completed = true
        };

        var project3 = new ProjectModel
        {
            Id = 3,
            ProjectName = "Parser Development",
            Client = "Driveway, Inc.",
            Description = "Create a mobile application on iOS and Android devices.",
            Completed = false
        };

        var project4 = new ProjectModel
        {
            Id = 4,
            ProjectName = "Parser Development",
            Client = "Driveway, Inc.",
            Description = "Create a mobile application on iOS and Android devices.",
            Completed = false
        };

        var project5 = new ProjectModel
        {
            Id = 5,
            ProjectName = "Parser Development",
            Client = "Driveway, Inc.",
            Description = "Create a mobile application on iOS and Android devices.",
            Completed = true
        };

        var project6 = new ProjectModel
        {
            Id = 6,
            ProjectName = "Parser Development",
            Client = "Driveway, Inc.",
            Description = "Create a mobile application on iOS and Android devices.",
            Completed = false
        };

        var project7 = new ProjectModel
        {
            Id = 7,
            ProjectName = "Parser Development",
            Client = "Driveway, Inc.",
            Description = "Create a mobile application on iOS and Android devices.",
            Completed = true
        };

        //var project8 = new ProjectModel
        //{
        //    Id = 8,
        //    ProjectName = "Parser Development",
        //    Client = "Driveway, Inc.",
        //    Description = "Create a mobile application on iOS and Android devices.",
        //    Completed = false
        //};

        var list = new List<ProjectModel> {
                project,
                project2,
                project3,
                project4,
                project5,
                project6,
                project7,
                //project8,
            };

        return list;
    }
}
