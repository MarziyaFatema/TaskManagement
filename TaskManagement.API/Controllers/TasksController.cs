using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.API.Data;
using TaskManagement.API.Models.Domain;
using TaskManagement.API.Models.DTO;
using TaskManagement.API.Repositories;

namespace TaskManagement.API.Controllers
{
    //http://localhost:portnumber/api/task
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : Controller
    {
        private readonly TaskManagementDBContext dbContext;
        private readonly ITaskRepository taskRepository;

        public TasksController(TaskManagementDBContext dbContext, ITaskRepository taskRepository)
        {
            this.dbContext = dbContext;
            this.taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                //Get data from database - domain models
                var taskDomain = await dbContext.Tasks.ToListAsync();

                //Map domain models to DTOs
                var taskDTO = new List<TaskDTO>();
                foreach (var task in taskDomain)
                {
                    taskDTO.Add(new TaskDTO() { 
                        Id = task.Id,
                        Title = task.Title,
                        Description = task.Description,
                        DueDate = task.DueDate,
                        Priority = task.Priority,
                        Status = task.Status
                    });  
                }    
                
                //Return DTOs
                return Ok(taskDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var taskDomain = await dbContext.Tasks.FirstOrDefaultAsync(x=>x.Id==id);

            if (taskDomain == null)
            {
                return NotFound();
            }

            var taskDTO = new TaskDTO
            {
                Id = taskDomain.Id,
                Title = taskDomain.Title,
                Description = taskDomain.Description,
                DueDate = taskDomain.DueDate,
                Priority = taskDomain.Priority,
                Status = taskDomain.Status
            };

            return Ok(taskDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddTaskDTO addTaskDTO)
        {
            var taskDomainModel = new TaskDomainModel
            {
                Title = addTaskDTO.Title,
                Description = addTaskDTO.Description,
                DueDate = addTaskDTO.DueDate,
                Priority = addTaskDTO.Priority,
                Status = addTaskDTO.Status
            };

            await dbContext.Tasks.AddAsync(taskDomainModel);
            await dbContext.SaveChangesAsync();

            var taskDTO = new TaskDTO
            {
                Id = taskDomainModel.Id,
                Title = taskDomainModel.Title,
                Description = taskDomainModel.Description,
                DueDate = taskDomainModel.DueDate,
                Priority = taskDomainModel.Priority,
                Status = taskDomainModel.Status
            };

            return CreatedAtAction(nameof(GetById), new { id = taskDTO.Id }, taskDTO);
            
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTaskDTO updateTaskDto)
        {
            var taskDomainModel = await dbContext.Tasks.FirstOrDefaultAsync(x=>x.Id == id);
            if (taskDomainModel == null)
            {
                return NotFound();
            }
            taskDomainModel.Title = updateTaskDto.Title;
            taskDomainModel.Description = updateTaskDto.Description;
            taskDomainModel.DueDate = updateTaskDto.DueDate;
            taskDomainModel.Priority = updateTaskDto.Priority;
            taskDomainModel.Status = updateTaskDto.Status;
            await dbContext.SaveChangesAsync();

            var taskDTO = new TaskDTO
            {
                Id = taskDomainModel.Id,
                Title = taskDomainModel.Title,
                Description = taskDomainModel.Description,
                DueDate = taskDomainModel.DueDate,
                Priority = taskDomainModel.Priority,
                Status = taskDomainModel.Status
            };

            return Ok(taskDTO);
        }

        [HttpDelete()]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var taskDomainModel = await dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (taskDomainModel == null)
            {
                return NotFound();
            }
            dbContext.Tasks.Remove(taskDomainModel);
            await dbContext.SaveChangesAsync();

            var taskDTO = new TaskDTO
            {
                Id = taskDomainModel.Id,
                Title = taskDomainModel.Title,
                Description = taskDomainModel.Description,
                DueDate = taskDomainModel.DueDate,
                Priority = taskDomainModel.Priority,
                Status = taskDomainModel.Status
            };

            return Ok(taskDTO);
        }
    }
}
