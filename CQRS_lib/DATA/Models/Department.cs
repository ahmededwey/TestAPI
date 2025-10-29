using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CQRS_lib.DATA.Models
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
        [Required]
        public DateTime OpenDate { get; set; }
    }
}
