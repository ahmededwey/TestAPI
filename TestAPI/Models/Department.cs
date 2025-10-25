using System.ComponentModel.DataAnnotations;

namespace TestAPI.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(130)]
        public string Description { get; set; }
    }
}
