
namespace werehouse_api.Dtos.Tools.Responses
{
    public class ToolHistoryDto
    {
        public int Id { get; set; }
        public int ToolId { get; set; }
        public string Type { get; set; }
        public DateTime At { get; set; }
        public string? ByUserUsername { get; set; }
        public string? ByName { get; set; }
        public string? LocationOfUse { get; set; }
        public string? ExpectedDuration { get; set; }
        public bool? Clean { get; set; }
        public string? StaffUserUsername { get; set; }
        public string? StaffUserName { get; set; }
        public string? BorrowerUserUsername { get; set; }
        public string? BorrowerName { get; set; }
    }
}
