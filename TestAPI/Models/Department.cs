using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace TestAPI.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Department
    {
        [Key]
        public int DeptID { get; set; }
        [Required]
        [StringLength(100)]
        //unique
     
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
