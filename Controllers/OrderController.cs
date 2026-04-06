using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using werehouse_api.Auth;
using werehouse_api.Data;
using werehouse_api.Dtos.Orders.Requests;
using werehouse_api.Dtos.Orders.Responses;
using werehouse_api.Entities;
using werehouse_api.Wrappers;

namespace werehouse_api.Controllers
{
    [Authorize]
    public class OrderController : BaseControllerApi
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            try
            {
                var order = await _context.Orders
                    .Include(x => x.Items).ThenInclude(x => x.InventoryItem)
                    .Include(x => x.RequestedUser).ThenInclude(x => x.Department)
                    .Include(x => x.RequestedUser).ThenInclude(x => x.Role)
                    .Include(x => x.AssignedUser)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (order == null)
                {
                    return NotFound(new Response<string>() { Message = $"Order with id {id} not found.", Succeded = false });
                }

                var orderDto = new OrderDto();

                orderDto.Id = order.Id;
                orderDto.CreatedAt = order.CreatedAt;
                orderDto.UpdatedAt = order.UpdatedAt;
                orderDto.Kind = order.Kind;
                orderDto.Status = order.Status;

                if (order.RequestedUser != null)
                {
                    orderDto.RequestedId = order.RequestedUser.Username;
                    orderDto.RequesterName = $"{order.RequestedUser.FirstName} {order.RequestedUser.LastName}";
                    orderDto.RequesterRole = order.RequestedUser.Role.Name;

                    if (order.RequestedUser.Department != null)
                    {
                        orderDto.RequesterDepartment = order.RequestedUser.Department.Name;
                        orderDto.RequesterDepartmentId = order.RequestedUser.DepartmentId.Value;
                    }
                }

                if (order.AssignedUser != null)
                {
                    orderDto.AssignedToId = order.AssignedUser.Username;
                    orderDto.AssignedToName = $"{order.AssignedUser.FirstName} {order.AssignedUser.LastName}";
                }

                orderDto.ReceivedAt = order.ReceivedAt;
                orderDto.ReceivedByName = order.ReceivedByName;

                orderDto.Items = order.Items.Select(x => new OrderItemDto
                {
                    Id = x.Id,
                    OrderId = x.OrderId,
                    InventoryItemSKU = x.InventoryItem.SKU,
                    InventoryItemId = x.InventoryItemId,
                    InventoryItemName = x.InventoryItem.Name,
                    Quantity = x.Quantity
                }).ToList();


                return Ok(new Response<OrderDto>(orderDto));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>() { Message = ex.Message, Succeded = false });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var orders = await _context.Orders
                    .Include(x => x.Items).ThenInclude(x => x.InventoryItem)
                    .Include(x => x.RequestedUser).ThenInclude(x => x.Department)
                    .Include(x => x.RequestedUser).ThenInclude(x => x.Role)
                    .Include(x => x.AssignedUser)
                    .ToListAsync();

                var ordersDto = new List<OrderDto>();

                foreach (var item in orders)
                {
                    OrderDto newOrderDto = new OrderDto();

                    newOrderDto.Id = item.Id;
                    newOrderDto.CreatedAt = item.CreatedAt;
                    newOrderDto.UpdatedAt = item.UpdatedAt;
                    newOrderDto.Kind = item.Kind;
                    newOrderDto.Status = item.Status;

                    if (item.RequestedUser != null)
                    {
                        newOrderDto.RequestedId = item.RequestedUser.Username;
                        newOrderDto.RequesterName = $"{item.RequestedUser.FirstName} {item.RequestedUser.LastName}";
                        newOrderDto.RequesterRole = item.RequestedUser.Role.Name;

                        if (item.RequestedUser.Department != null)
                        {
                            newOrderDto.RequesterDepartment = item.RequestedUser.Department.Name;
                            newOrderDto.RequesterDepartmentId = item.RequestedUser.DepartmentId.Value;
                        }
                    }

                    if (item.AssignedUser != null)
                    {
                        newOrderDto.AssignedToId = item.AssignedUser.Username;
                        newOrderDto.AssignedToName = $"{item.AssignedUser.FirstName} {item.AssignedUser.LastName}";
                    }

                    newOrderDto.ReceivedAt = item.ReceivedAt;
                    newOrderDto.ReceivedByName = item.ReceivedByName;

                    newOrderDto.Items = item.Items.Select(x => new OrderItemDto
                    {
                        Id = x.Id,
                        OrderId = x.OrderId,
                        InventoryItemSKU = x.InventoryItem.SKU,
                        InventoryItemId = x.InventoryItemId,
                        InventoryItemName = x.InventoryItem.Name,
                        Quantity = x.Quantity
                    }).ToList();

                    ordersDto.Add(newOrderDto);
                }

                return Ok(new Response<List<OrderDto>>(ordersDto));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>() { Message = ex.Message, Succeded = false });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto request, [FromHeader] string secretKey)
        {
            try
            {
                if (secretKey != StringConstants.SecretKey)
                {
                    return Unauthorized(new Response<string>() { Message = "Unauthorized", Succeded = false });
                }

                var newOrder = new Order();

                newOrder.CreatedAt = request.CreatedAt;
                newOrder.UpdatedAt = request.CreatedAt;
                newOrder.Kind = request.Kind;
                newOrder.Status = request.Status;
                newOrder.RequestedUserUsername = request.RequestedId;
                newOrder.AssignedUserUsername = request.AssignedToId;
                newOrder.ReceivedAt = request.ReceivedAt;
                newOrder.ReceivedByName = request.ReceivedByName;

                var orderItems = new List<OrderItem>();

                foreach (var item in request.Items)
                {
                    var inventoryItem = await _context.InventoryItems.FirstOrDefaultAsync(x => x.SKU == item.SKU);

                    if (inventoryItem == null)
                    {
                        return BadRequest(new Response<string>() { Message = $"Inventory item with SKU {item.SKU} not found.", Succeded = false });
                    }

                    var orderItem = new OrderItem()
                    {
                        InventoryItemId = inventoryItem.Id,
                        Quantity = item.Quantity
                    };

                    orderItems.Add(orderItem);
                }

                newOrder.Items = orderItems;

                _context.Orders.Add(newOrder);
                await _context.SaveChangesAsync();

                return Ok(new Response<int>(newOrder.Id));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>() { Message = ex.Message, Succeded = false });
            }
        }

        [HttpPut("AssignOrder")]
        public async Task<IActionResult> AssignOrderToUser([FromBody] AssignOrderDto request)
        {
            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == request.OrderId);

                if (order == null)
                {
                    return NotFound(new Response<string>() { Message = $"Order with id {request.OrderId} not found.", Succeded = false });
                }

                order.AssignedUserUsername = request.Username;
                order.UpdatedAt = request.UpdatedAt;
                order.UpdatedBy = request.UpdatedBy;
                order.Status = "processing";

                await _context.SaveChangesAsync();

                return Ok(new Response<bool>(true));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>() { Message = ex.Message, Succeded = false });
            }
        }

        [HttpPut("UnassignOrder")]
        public async Task<IActionResult> UnassignOrderToUser([FromBody] UnassignOrderDto request)
        {
            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == request.OrderId);

                if (order == null)
                {
                    return NotFound(new Response<string>() { Message = $"Order with id {request.OrderId} not found.", Succeded = false });
                }

                order.AssignedUserUsername = null;
                order.UpdatedAt = request.UpdatedAt;
                order.UpdatedBy = request.UpdatedBy;
                order.Status = "pending";

                await _context.SaveChangesAsync();

                return Ok(new Response<bool>(true));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>() { Message = ex.Message, Succeded = false });
            }
        }

        [HttpPut("UpdateStatus")]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateStatusDto request)
        {
            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == request.OrderId);

                if (order == null)
                {
                    return NotFound(new Response<string>() { Message = $"Order with id {request.OrderId} not found.", Succeded = false });
                }

                
                order.UpdatedAt = request.UpdatedAt;
                order.UpdatedBy = request.UpdatedBy;
                order.Status = request.Status;

                await _context.SaveChangesAsync();

                return Ok(new Response<bool>(true));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>() { Message = ex.Message, Succeded = false });
            }
        }

        [HttpPut("ConfirmOrderReceived")]
        public async Task<IActionResult> ConfirmOrderReceived([FromBody] ConfirmOrderReceivedDto request)
        {
            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == request.OrderId);

                if (order == null)
                {
                    return NotFound(new Response<string>() { Message = $"Order with id {request.OrderId} not found.", Succeded = false });
                }

                order.UpdatedAt = request.UpdatedAt;
                order.UpdatedBy = request.UpdatedBy;
                order.ReceivedByName = request.ReceivedByName;
                order.Status = "delivered";

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
