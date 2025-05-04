using WebApp.Models;

namespace WebApp.Services
{
    public interface IProjectService
    {
        Task<bool> Create(ProjectModel project);
        Task<IEnumerable<ProjectModel>> GetAllAsync(string userName);
        Task<ProjectModel> GetProject(string userName);
        Task<bool> Update(ProjectModel updatedEntity);
    }
}