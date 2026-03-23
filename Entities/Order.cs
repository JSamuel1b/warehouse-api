using System.ComponentModel.DataAnnotations;

namespace werehouse_api.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        [MaxLength(100)]
        public string? CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        [MaxLength(100)]
        public string? UpdatedBy { get; set; }
        [MaxLength(50)]
        public string Kind { get; set; }
        [MaxLength(50)]
        public string Status { get; set; }
        public string? RequestedUserUsername { get; set; }
        public User? RequestedUser { get; set; }
        public string? AssignedUserUsername { get; set; }
        public User? AssignedUser { get; set; }
        public string? ReceivedByName { get; set; }
        public string? ReceivedAt { get; set; }
        public string? PickedByName { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
