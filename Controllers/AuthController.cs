using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using werehouse_api.Auth;
using werehouse_api.Data;
using werehouse_api.Dtos.Auth.Requests;
using werehouse_api.Dtos.Auth.Responses;
using werehouse_api.Entities;
using werehouse_api.Enums;
using werehouse_api.Helpers;
using werehouse_api.Wrappers;

namespace werehouse_api.Controllers
{
    public class AuthController : BaseControllerApi
    {
        private readonly TokenProvider _tokenProvider;
        private readonly ApplicationDbContext _context;

        public AuthController(TokenProvider tokenProvider, ApplicationDbContext context)
        {
            _tokenProvider = tokenProvider;
            _context = context;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequestDto request)
        {
            try
            {
                var checkUsername = await _context.Users.AnyAsync(x => x.Username == request.Username);

                if (checkUsername)
                {
                    return BadRequest(new Response<string>() { Message = "Username already exists.", Succeded = false });
                }

                if (request.RoleId == (int)RoleList.DeptHead && !request.DepartmentId.HasValue)
                {
                    return BadRequest(new Response<string>() { Message = "You must select a department for the role Dept Head.", Succeded = false });
                }

                PasswordHasher hasher = new PasswordHasher();

                var newUser = new User()
                {
                    Username = request.Username,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    IsActive = true,
                    RoleId = request.RoleId,
                    DepartmentId = request.DepartmentId,
                    Password = hasher.HashPassword(request.Password)
                };

                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                var user = await _context.Users
                    .Include(x => x.Role)
                    .Include(x => x.Department)
                    .FirstOrDefaultAsync(x => x.Username == request.Username);

                if (user != null)
                {
                    LoginResponseDto response = new()
                    {
                        UserName = user.Username,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        IsActive = user.IsActive,
                        RoleId = user.RoleId,
                        RoleName = user.Role.Name,
                        JwtToken = _tokenProvider.Create(user)
                    };

                    if (user.Department != null)
                    {
                        response.DepartmentId = user.DepartmentId;
                        response.DepartmentName = user.Department.Name;
                    }

                    return Ok(new Response<LoginResponseDto>(response));
                }
                else
                {
                    return BadRequest(new Response<string>() { Message = "User creation failed.", Succeded = false });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>() { Message = ex.Message, Succeded = false });
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            try
            {
                var user = await _context.Users
                    .Include(x => x.Role)
                    .Include(x => x.Department)
                    .FirstOrDefaultAsync(x => x.Username == request.Username);

                if (user == null)
                {
                    return Unauthorized(new Response<string>() { Message = "Wrong Username or Password", Succeded = false });
                }

                PasswordHasher hasher = new PasswordHasher();

                if (string.IsNullOrEmpty(request.Password))
                {
                    return Unauthorized(new Response<string>() { Message = "Wrong Username or Password", Succeded = false });
                }

                var isValid = hasher.Verify(request.Password, user.Password);

                if (!isValid)
                {
                    return Unauthorized(new Response<string>() { Message = "Wrong Username or Password", Succeded = false });
                }

                LoginResponseDto response = new()
                {
                    UserName = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsActive = user.IsActive,
                    RoleId = user.RoleId,
                    RoleName = user.Role.Name,
                    JwtToken = _tokenProvider.Create(user)
                };

                if (user.Department != null)
                {
                    response.DepartmentId = user.DepartmentId;
                    response.DepartmentName = user.Department.Name;
                }

                return Ok(new Response<LoginResponseDto>(response));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>() { Message = ex.Message, Succeded = false });
            }
        }

        [Authorize]
        [HttpGet("Refresh")]
        public async Task<IActionResult> RefreshToken()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;

                if (identity == null)
                {
                    return Unauthorized(new Response<string>() { Message = "Session closed. Login again", Succeded = false });
                }

                var username = identity.FindFirst("username")!.Value;

                if (string.IsNullOrEmpty(username))
                {
                    return Unauthorized(new Response<string>() { Message = "Session closed. Login again", Succeded = false });
                }

                var user = await _context.Users
                    .Include(x => x.Role)
                    .Include(x => x.Department)
                    .FirstOrDefaultAsync(x => x.Username == username);

                if (user == null)
                {
                    return Unauthorized(new Response<string>() { Message = "Invalid token.", Succeded = false });
                }

                LoginResponseDto response = new()
                {
                    UserName = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsActive = user.IsActive,
                    RoleId = user.RoleId,
                    RoleName = user.Role.Name,
                    JwtToken = _tokenProvider.Create(user)
                };

                if (user.Department != null)
                {
                    response.DepartmentId = user.DepartmentId;
                    response.DepartmentName = user.Department.Name;
                }

                return Ok(new Response<LoginResponseDto>(response));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>() { Message = ex.Message, Succeded = false });
            }
        }
    }
}
