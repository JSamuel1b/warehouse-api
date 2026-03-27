using Microsoft.EntityFrameworkCore.Update.Internal;

namespace werehouse_api.Dtos.Tools.Requests
{
    public class CheckOutToolDto
    {
        public int Id { get; set; }
        public string CurrentHolderUsername { get; set; }
        public string OwnerUsername { get; set; }
        public DateTime CheckedOutAt { get; set; }
        public DateTime DueAt { get; set; }
        public string LocationOfUse { get; set; }
        public string ExpectedDuration { get; set; }
    }
}
