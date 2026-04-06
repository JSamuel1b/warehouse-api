using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using werehouse_api.Auth;
using werehouse_api.Data;
using werehouse_api.Dtos.Users.Responses;
using werehouse_api.Enums;
using werehouse_api.Wrappers;

namespace werehouse_api.Controllers
{
    public class UsersController : BaseControllerApi
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("DeptHeads")]
        public async Task<IActionResult> GetDepartmentHeads([FromHeader] string secretKey)
        {
            try
            {
                if (secretKey != StringConstants.SecretKey)
                {
                    return Unauthorized(new Response<string>() { Message = "Unauthorized", Succeded = false });
                }

                var deptHeads = await _context.Users
                    .Include(u => u.Department)
                    .Include(u => u.Role)
                    .Where(u => u.RoleId == (int)RoleList.DeptHead)
                    .Select(x => new UserDto()
                    {
                        DepartmentId = x.DepartmentId,
                        DepartmentName = x.Department != null ? x.Department.Name : null,
                        RoleId = x.RoleId,
                        RoleName = x.Role.Name,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        IsActive = x.IsActive,
                        Username = x.Username,
                        DepartmentPinCode = x.Department != null ? x.Department.PinCode : null
                    })
                    .ToListAsync();

                return Ok(new Response<List<UserDto>>(deptHeads));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>() { Message = ex.Message, Succeded = false });
            }

            
        }
    }
}
