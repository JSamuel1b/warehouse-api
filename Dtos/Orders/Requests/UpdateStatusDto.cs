namespace werehouse_api.Dtos.Orders.Requests
{
    public class UpdateStatusDto
    {
        public int OrderId { get; set; }
        public string Status { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
