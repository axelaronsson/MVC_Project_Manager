using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Data.Entities;
using WebApp.Factories;
using WebApp.Models;

namespace WebApp.Services;

public class ProjectService(DataContext dataContext, UserManager<AppUser> userManager) : IProjectService
{
    private readonly DataContext _dataContext = dataContext;
    //private List<ProjectModel> _projects = [];

    public bool Create(ProjectModel project)
    {
        var projectEntity = ProjectFactory.Create(project);
        //_dataContext.Projects.All(x => x.Id == project.Id);
        _dataContext.Projects.Add(projectEntity);
        _dataContext.SaveChanges();
        return true;
    }

    public bool Update(ProjectModel updatedEntity)
    {
        var existingEntity = _dataContext.Projects.FirstOrDefault(p => p.Id == updatedEntity.Id);

        if (existingEntity != null)
        {
            //throw new InvalidOperationException("error blabla");
            _dataContext.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
            _dataContext.SaveChanges();
            return true;

        }
        return false;
    }

    public ProjectModel GetProject(string id)
    {
        var entity = _dataContext.Projects.FirstOrDefault(p => p.Id.ToString() == id)!;
        return ProjectFactory.Create(entity);
    }

    public IEnumerable<ProjectModel> GetAllAsync(string userName)
    {
        var entities = _dataContext.Projects.Where(p => p.UserName == userName);
        var projectDtos = entities.Select(p => ProjectFactory.Create(p));
        return projectDtos;
    }
}
