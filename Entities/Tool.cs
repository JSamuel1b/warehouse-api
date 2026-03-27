using System.ComponentModel.DataAnnotations;

namespace werehouse_api.Entities
{
    public class Tool
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ToolCategoryId { get; set; }
        public ToolCategory ToolCategory { get; set; }
        [MaxLength(20)]
        public string Status { get; set; }
        [MaxLength(100)]
        public string? CurrentHolderUsername { get; set; }
        public User? CurrentHolder { get; set; }
        [MaxLength(100)]
        public string? OwnerUsername { get; set; }
        public User? Owner { get; set; }
        public DateTime? CheckedOutAt { get; set; }
        public DateTime? DueAt { get; set; }
        public string? LocationOfUse { get; set; }
        public string? ExpectedDuration { get; set; }
        public List<ToolHistory> ToolHistories { get; set; }
    }
}
