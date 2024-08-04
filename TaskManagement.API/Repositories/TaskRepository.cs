using Microsoft.EntityFrameworkCore;
using TaskManagement.API.Data;
using TaskManagement.API.Models.Domain;

namespace TaskManagement.API.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagementDBContext _dbContext;

        public TaskRepository(TaskManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TaskDomainModel>> GetAllAsync()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<TaskDomainModel> GetByIdAsync(int id)
        {
            return await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}