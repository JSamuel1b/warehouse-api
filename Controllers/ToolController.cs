using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using werehouse_api.Data;
using werehouse_api.Dtos.Tools.Requests;
using werehouse_api.Dtos.Tools.Responses;
using werehouse_api.Entities;
using werehouse_api.Wrappers;

namespace werehouse_api.Controllers
{
    public class ToolController : BaseControllerApi
    {
        private readonly ApplicationDbContext _context;

        public ToolController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTools()
        {
            try
            {
                var tools = await _context.Tools
                    .Include(t => t.ToolCategory)
                    .Include(x => x.Owner).ThenInclude(d => d.Department)
                    .Include(x => x.CurrentHolder)
                    .Include(x => x.ToolHistories)
                    .ToListAsync();

                var dtos = tools.Select(x => new ToolDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ToolCategoryId = x.ToolCategoryId,
                    ToolCategoryName = x.ToolCategory.Name,
                    Status = x.Status,
                    CurrentHolderUsername = x.CurrentHolderUsername,
                    CurrentHolderName = x.CurrentHolder != null ? $"{x.CurrentHolder.FirstName} {x.CurrentHolder.LastName}" : null,
                    OwnerUsername = x.OwnerUsername,
                    OwnerName = x.Owner != null ? $"{x.Owner.FirstName} {x.Owner.LastName}" : null,
                    OwnerDepartmentId = x.Owner != null ? x.Owner.DepartmentId : null,
                    OwnerDepartmentName = x.Owner != null ? x.Owner.Department.Name : null,
                    CheckedOutAt = x.CheckedOutAt,
                    DueAt = x.DueAt,
                    LocationOfUse = x.LocationOfUse,
                    ExpectedDuration = x.ExpectedDuration,
                    Histories = x.ToolHistories.Select(h => new ToolHistoryDto()
                    {
                        Id = h.Id,
                        ToolId = h.ToolId,
                        Type = h.Type,
                        At = h.At,
                        ByUserUsername = h.ByUserUsername,
                        ByName = h.ByUser != null ? $"{h.ByUser.FirstName} {h.ByUser.LastName}" : null,
                        LocationOfUse = h.LocationOfUse,
                        ExpectedDuration = h.ExpectedDuration,
                        StaffUserUsername = h.StaffUserUsername,
                        StaffUserName = h.StaffUser != null ? $"{h.StaffUser.FirstName} {h.StaffUser.LastName}" : null,
                        BorrowerUserUsername = h.BorrowerUserUsername,
                        BorrowerName = h.BorrowerUser != null ? $"{h.BorrowerUser.FirstName} {h.BorrowerUser.LastName}" : null,
                        Clean = h.Clean
                    }).ToList()
                }).ToList();

                return Ok(new Response<List<ToolDto>>(dtos));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>() { Message = ex.Message, Succeded = false });
            }
        }

        [HttpPost("CheckOut")]
        public async Task<IActionResult> CheckOutTool([FromBody] CheckOutToolDto request)
        {
            try
            {
                var tool = await _context.Tools.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (tool == null)
                {
                    return NotFound(new Response<string>() { Message = $"Tool with id {request.Id} not found.", Succeded = false });
                }

                tool.Status = "checkout";
                tool.CurrentHolderUsername = request.CurrentHolderUsername;
                tool.OwnerUsername = request.OwnerUsername;
                tool.CheckedOutAt = request.CheckedOutAt;
                tool.DueAt = request.DueAt;
                tool.LocationOfUse = request.LocationOfUse;
                tool.ExpectedDuration = request.ExpectedDuration;

                var hitory = new ToolHistory()
                {
                    ToolId = request.Id,
                    Type = "checkout",
                    At = request.CheckedOutAt,
                    ByUserUsername = request.CurrentHolderUsername,
                    LocationOfUse = request.LocationOfUse,
                    ExpectedDuration = request.ExpectedDuration,
                };

                _context.ToolHistories.Add(hitory);
                await _context.SaveChangesAsync();

                return Ok(new Response<bool>(true));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>() { Message = ex.Message, Succeded = false });
            }
        }

        [HttpPut("InitiateReturn")]
        public async Task<IActionResult> InitiateToolReturn([FromBody] InitiateReturnDto request)
        {
            try
            {
                var tool = await _context.Tools.FirstOrDefaultAsync(x => x.Id == request.ToolId);

                if (tool == null)
                {
                    return NotFound(new Response<string>() { Message = $"Tool with id {request.ToolId} not found.", Succeded = false });
                }

                tool.Status = "return_pending";

                var history = new ToolHistory()
                {
                    ToolId = request.ToolId,
                    Type = "return_initiated",
                    At = request.At,
                    ByUserUsername = request.ByUsername,
                };

                _context.ToolHistories.Add(history);
                await _context.SaveChangesAsync();

                return Ok(new Response<bool>(true));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>() { Message = ex.Message, Succeded = false });
            }
        }

        [HttpPut("ConfirmReturn")]
        public async Task<IActionResult> ConfirmReturnTool([FromBody] ConfirmToolReturnDto request)
        {
            try
            {
                var tool = await _context.Tools.FirstOrDefaultAsync(x => x.Id == request.ToolId);

                if (tool == null)
                {
                    return NotFound(new Response<string>() { Message = $"Tool with id {request.ToolId} not found.", Succeded = false });
                }

                var history = new ToolHistory()
                {
                    ToolId = request.ToolId,
                    Type = "return_confirmed",
                    At = request.At,
                    StaffUserUsername = request.StaffUsername,
                    Clean = request.Clean,
                    BorrowerUserUsername = tool.CurrentHolderUsername
                };

                tool.Status = "available";
                tool.CurrentHolderUsername = null;
                tool.CheckedOutAt = null;
                tool.DueAt = null;
                tool.OwnerUsername = null;
                tool.LocationOfUse = null;
                tool.ExpectedDuration = null;
                
                _context.ToolHistories.Add(history);
                await _context.SaveChangesAsync();

                return Ok(new Response<bool>(true));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>() { Message = ex.Message, Succeded = false });
            }
        }
    }
}
