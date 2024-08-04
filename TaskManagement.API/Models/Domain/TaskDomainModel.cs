using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.API.Models.Domain
{

    [Table("Task")]
    public class TaskDomainModel
    {
        [Key]
        public int Id { get; set; }
        [Column("Title")]
        public string Title { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("DueDate")]
        public DateTime DueDate { get; set; }
        [Column("Priority")]
        public string? Priority { get; set; }
        [Column("Status")]
        public string? Status { get; set; }
    }
}
