using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAPI.Models
{
    public class Item
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
       
        public string Notes { get; set; }

         [MaxLength(200)]
        public string Description { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public byte[]? Image { get; set; }
        //navigation Property
        public Category Category { get; set; }
    }
}
