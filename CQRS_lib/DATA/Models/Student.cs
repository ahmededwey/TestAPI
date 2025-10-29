using System.ComponentModel.DataAnnotations;

namespace CQRS_lib.DATA.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(5, 90)]
        public int Age { get; set; }
        [Required]
        public string Address { get; set; }
        public string imageUrl { get; set; }

        [Required]
        public int DepartmentID { get; set; }

        public virtual Department? Department { get; set; }
    }
}
