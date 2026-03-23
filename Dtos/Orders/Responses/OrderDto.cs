namespace werehouse_api.Dtos.Orders.Responses
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Kind { get; set; }
        public string Status { get; set; }
        public string? RequestedId { get; set; }
        public string RequesterName { get; set; }
        public string RequesterRole { get; set; }
        public string RequesterDepartment { get; set; }
        public int RequesterDepartmentId { get; set; }
        public string? AssignedToId { get; set; }
        public string? AssignedToName { get; set; }
        public string? ReceivedByName { get; set; }
        public string? ReceivedAt { get; set; }
        public string? PickedByName { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }
}
