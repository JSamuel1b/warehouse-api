using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using werehouse_api.Auth;
using werehouse_api.Data;
using werehouse_api.Entities;
using werehouse_api.Wrappers;

namespace werehouse_api.Controllers
{
    public class InventoryItemController : BaseControllerApi
    {
        private readonly ApplicationDbContext _context;

        public InventoryItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetInventoryItemList([FromHeader] string secretKey)
        {
            try
            {
                if (secretKey != StringConstants.SecretKey)
                {
                    return Unauthorized(new Response<string>() { Message = "Unauthorized", Succeded = false });
                }

                var items = await _context.InventoryItems.ToListAsync();

                return Ok(new Response<List<InventoryItem>>(items));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>() { Message = ex.Message, Succeded = false });
            }
        }
    }
}
