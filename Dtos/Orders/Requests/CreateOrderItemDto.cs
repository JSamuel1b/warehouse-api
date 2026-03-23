namespace werehouse_api.Dtos.Orders.Requests
{
    public class CreateOrderItemDto
    {
        public string SKU { get; set; }
        public int Quantity { get; set; }
    }
}
