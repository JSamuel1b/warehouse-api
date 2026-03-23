namespace werehouse_api.Dtos.Orders.Requests
{
    public class AssignOrderDto
    {
        public int OrderId { get; set; }
        public string Username { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
