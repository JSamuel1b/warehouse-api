namespace werehouse_api.Dtos.Tools.Requests
{
    public class ConfirmToolReturnDto
    {
        public int ToolId { get; set; }
        public bool Clean { get; set; }
        public string StaffUsername { get; set; }
        public DateTime At { get; set; }
    }
}
