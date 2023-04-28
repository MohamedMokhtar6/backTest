


using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string? Name { get; set; }
        public ICollection<Item>?Items { get; set; }
    }
}
