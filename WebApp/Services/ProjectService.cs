using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Data.Entities;
using WebApp.Factories;
using WebApp.Models;

namespace WebApp.Services;

public class ProjectService(DataContext dataContext) : IProjectService
{
    private readonly DataContext _dataContext = dataContext;

    public async Task<bool> Create(ProjectModel project)
    {
        try
        {
            var projectEntity = ProjectFactory.Create(project);
            await _dataContext.Projects.AddAsync(projectEntity);
            await _dataContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }

    }

    public async Task<bool> Update(ProjectModel updatedProject)
    {
        try
        {
            var existingEntity = await _dataContext.Projects.FirstOrDefaultAsync(p => p.Id == updatedProject.Id);

            if (existingEntity != null)
            {
                _dataContext.Entry(existingEntity).CurrentValues.SetValues(updatedProject);
                await _dataContext.SaveChangesAsync();
                return true;

            }
            return false;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }

    }

    public async Task<ProjectModel> GetProject(string id)
    {
        try
        {
            var entity = await _dataContext.Projects.FirstOrDefaultAsync(p => p.Id.ToString() == id)!;
            if (entity != null)
                return ProjectFactory.Create(entity);

            return null!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return null!;
        }

    }

    public async Task<IEnumerable<ProjectModel>> GetAllAsync(string userName)
    {

        var entities = await _dataContext.Projects.Where(p => p.UserName == userName).ToListAsync();
        var projects = entities.Select(p => ProjectFactory.Create(p));
        return projects;
    }
}
