namespace werehouse_api.Dtos.Orders.Requests
{
    public class CreateOrderDto
    {
        public DateTime CreatedAt { get; set; }
        public string Kind { get; set; }
        public string Status { get; set; }
        public string? RequestedId { get; set; }
        public string? AssignedToId { get; set; }
        public string? ReceivedByName { get; set; }
        public string? ReceivedAt { get; set; }
        public string? PickedByName { get; set; }
        public List<CreateOrderItemDto> Items { get; set; }
    }
}
