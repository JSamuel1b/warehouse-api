using System.ComponentModel.DataAnnotations;

namespace werehouse_api.Entities
{
    public class InventoryItem
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string SKU { get; set; }
        [MaxLength(240)]
        public string Name { get; set; }
        public int Stock { get; set; }
        [MaxLength(200)]
        public string Location { get; set; }
        [MaxLength(100)]
        public string Unit { get; set; }
        public DateTime? LastRestocked { get; set; }
    }
}
