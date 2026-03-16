using werehouse_api.Entities;

namespace werehouse_api.Dtos.Auth.Requests
{
    public class RegisterUserRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int RoleId { get; set; }
        public int? DepartmentId { get; set; }
    }
}
