using System.ComponentModel.DataAnnotations;

namespace werehouse_api.Entities
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int InventoryItemId { get; set; }
        public InventoryItem InventoryItem { get; set; }
        public int Quantity { get; set; }
    }
}
