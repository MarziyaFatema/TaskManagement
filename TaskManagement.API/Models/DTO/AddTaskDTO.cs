using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TaskManagement.API.Models.Domain;

namespace TaskManagement.API.Models.DTO
{
    public class AddTaskDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string? Priority { get; set; }
        public string? Status { get; set; }
    }
}
