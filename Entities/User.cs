using System.ComponentModel.DataAnnotations;

namespace werehouse_api.Entities
{
    public class User
    {
        [Key]
        [MaxLength(100)]
        public string Username { get; set; }
        public string Password { get; set; }
        [MaxLength(100)]
        public string? FirstName { get; set; }
        [MaxLength(100)]
        public string? LastName { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
