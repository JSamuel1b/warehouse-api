namespace werehouse_api.Dtos.Auth.Responses
{
    public class LoginResponseDto
    {
        public string UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string JwtToken { get; set; }
    }
}
