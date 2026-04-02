
namespace werehouse_api.Dtos.Users.Responses
{
    public class UserDto
    {
        public string Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string? DepartmentPinCode { get; set; }
    }
}
