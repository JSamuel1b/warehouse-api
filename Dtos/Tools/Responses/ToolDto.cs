
namespace werehouse_api.Dtos.Tools.Responses
{
    public class ToolDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ToolCategoryId { get; set; }
        public string ToolCategoryName { get; set; }
        public string Status { get; set; }
        public string? CurrentHolderUsername { get; set; }
        public string CurrentHolderName { get; set; }
        public string? KioskId { get; set; }
        public string? KioskName { get; set; }
        public string? OwnerUsername { get; set; }
        public string OwnerName { get; set; }
        public int? OwnerDepartmentId { get; set; }
        public string OwnerDepartmentName { get; set; }
        public DateTime? CheckedOutAt { get; set; }
        public DateTime? DueAt { get; set; }
        public string? LocationOfUse { get; set; }
        public string? ExpectedDuration { get; set; }
        public bool? IsKioskCheckout { get; set; }
        public List<ToolHistoryDto> Histories { get; set; }
    }
}
