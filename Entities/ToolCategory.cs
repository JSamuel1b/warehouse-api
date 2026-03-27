using System.ComponentModel.DataAnnotations;

namespace werehouse_api.Entities
{
    public class ToolCategory
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
