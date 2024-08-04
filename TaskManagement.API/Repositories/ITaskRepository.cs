using TaskManagement.API.Models.Domain;

namespace TaskManagement.API.Repositories
{
    public interface ITaskRepository
    {
        public Task<List<TaskDomainModel>> GetAllAsync();
        public Task<TaskDomainModel> GetByIdAsync(int id);
    }
}
