using WebApp.Models;

namespace WebApp.Services
{
    public interface IProjectService
    {
        bool Create(ProjectModel project);
        IEnumerable<ProjectModel> GetAllAsync(string userName);
        ProjectModel GetProject(string userName);
        bool Update(ProjectModel updatedEntity);
    }
}