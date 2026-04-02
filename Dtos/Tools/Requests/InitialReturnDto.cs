namespace werehouse_api.Dtos.Tools.Requests
{
    public class InitiateReturnDto
    {
        public int ToolId { get; set; }
        public string ByUsername { get; set; }
        public string? KioskId { get; set; }
        public string? KioskName { get; set; }
        public DateTime At { get; set; }
    }
}
