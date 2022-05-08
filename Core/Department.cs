#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Department : BaseEntity
    {
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
    }
}
