
namespace werehouse_api.Dtos.Orders.Requests
{
    public class ConfirmOrderReceivedDto
    {
        public int OrderId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public string? ReceivedByName { get; set; }
    }
}
