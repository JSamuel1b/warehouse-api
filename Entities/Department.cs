using System.ComponentModel.DataAnnotations;

namespace werehouse_api.Entities
{
    public class Department
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(4)]
        public string? PinCode { get; set; }
        public bool IsActive { get; set; }
    }
}
