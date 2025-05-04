using WebApp.Data.Entities;
using WebApp.Models;

namespace WebApp.Factories;

public class ProjectFactory
{
    public static ProjectEntity Create(ProjectModel projectModel) => new()
    {
        Id = projectModel.Id,
        UserName = projectModel.UserName,
        ProjectName = projectModel.ProjectName,
        Client = projectModel.Client,
        Description = projectModel.Description,
        StartDate = projectModel.StartDate,
        EndDate = projectModel.EndDate,
        Completed = projectModel.Completed,
        Budget = projectModel.Budget
    };

    public static ProjectModel Create(ProjectEntity projectEntity) => new()
    {
        Id = projectEntity.Id,
        UserName = projectEntity.UserName,
        ProjectName = projectEntity.ProjectName,
        Client = projectEntity.Client,
        Description = projectEntity.Description,
        StartDate = projectEntity.StartDate,
        EndDate = projectEntity.EndDate,
        Completed = projectEntity.Completed,
        Budget = projectEntity.Budget
    };
}
