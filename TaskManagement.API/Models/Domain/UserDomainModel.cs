using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TaskManagement.API.Models.Domain
{
    [Table("User")]
    public class UserDomainModel
    {
        [Key]
        public int Id { get; set; }
        [Column("Username")]
        public string Username { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("Password")]
        [Required]
        [DisallowNull]
        public string Password { get; set; }
        [Column("Role")]
        public string Role { get; set; }
        [Column("IsDeleted")]
        public bool IsDeleted { get; set; }
    }
}
