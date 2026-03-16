using System.ComponentModel.DataAnnotations;

namespace werehouse_api.Entities
{
    public class Role
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
