namespace werehouse_api.Dtos.Orders.Requests
{
    public class UnassignOrderDto
    {
        public int OrderId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
