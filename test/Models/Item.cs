using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models
{
    public class Item
    {
        [Key]
        public int id { get; set; }
        [Required]
        [DisplayName("Name")]
        public string? name { get; set; }
        [Required]
        [Range(1, 100000,ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [DisplayName("Price")]
        public decimal price { get; set; }
        [DisplayName("Created Date")]
        public DateTime createdDate { get; set; } = DateTime.Now;
        [Required]
        [DisplayName("Category")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public string? ImagePathe { get; set; }
        [NotMapped]
        public IFormFile clientFile { get; set; }
    }
}
