using System.ComponentModel.DataAnnotations;

namespace werehouse_api.Entities
{
    public class ToolHistory
    {
        [Key]
        public int Id { get; set; }
        public int ToolId { get; set; }
        public Tool Tool { get; set; }
        [MaxLength(50)]
        public string Type { get; set; }
        public DateTime At { get; set; }
        [MaxLength(100)]
        public string? ByUserUsername { get; set; }
        public User? ByUser { get; set; }
        public string? LocationOfUse { get; set; }
        public string? ExpectedDuration { get; set; }
        public bool? Clean { get; set; }
        [MaxLength(100)]
        public string? StaffUserUsername { get; set; }
        public User? StaffUser { get; set; }
        [MaxLength(100)]
        public string? BorrowerUserUsername { get; set; }
        public User? BorrowerUser { get; set; }
        public bool? IsKioskCheckout { get; set; }
        [MaxLength(100)]
        public string? KioskId { get; set; }
        [MaxLength(150)]
        public string? KioskName { get; set; }
    }
}
