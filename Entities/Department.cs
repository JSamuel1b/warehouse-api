using System.ComponentModel.DataAnnotations;

namespace werehouse_api.Entities
{
    public class Department
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
