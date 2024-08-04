using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagement.API.Models.Domain;

namespace TaskManagement.API.Data
{
    public class TaskManagementDBContext : DbContext
    {
        public TaskManagementDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
                
        }
        public DbSet<TaskDomainModel> Tasks { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<TaskAssignment> TaskAssignments { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskManagementDBContext).Assembly);

        //    var taskPriorityConverter = new EnumToStringConverter<TaskPriority>();
        //    var taskStatusConverter = new EnumToStringConverter<Models.Domain.TaskStatus>();

        //    modelBuilder.Entity<TaskDetails>()
        //        .Property(e => e.Priority)
        //        .HasConversion(taskPriorityConverter);

        //    modelBuilder.Entity<TaskDetails>()
        //        .Property(e => e.Status)
        //        .HasConversion(taskStatusConverter);
        //}
    }
}
