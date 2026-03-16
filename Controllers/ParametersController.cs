using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using werehouse_api.Data;
using werehouse_api.Entities;
using werehouse_api.Wrappers;

namespace werehouse_api.Controllers
{
    public class ParametersController : BaseControllerApi
    {
        private readonly ApplicationDbContext _context;

        public ParametersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Departments")]
        public async Task<IActionResult> GetDepartments()
        {
            try
            {
                var departments = await _context.Departments.ToListAsync();

                return Ok(new Response<List<Department>>(departments));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>() { Message = ex.Message, Succeded = false });
            }
        }

        [HttpGet("Roles")]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var roles = await _context.Roles.ToListAsync();

                return Ok(new Response<List<Role>>(roles));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>() { Message = ex.Message, Succeded = false });
            }
        }
    }
}
