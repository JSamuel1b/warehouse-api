using werehouse_api.Entities;

namespace werehouse_api.Dtos.Orders.Responses
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int InventoryItemId { get; set; }
        public string InventoryItemSKU { get; set; }
        public string InventoryItemName { get; set; }
        public int Quantity { get; set; }
    }
}
