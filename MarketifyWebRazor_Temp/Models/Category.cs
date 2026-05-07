using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MarketifyWebRazor_Temp.Models
{
    public sealed class Category
    {
        public int Id { get; set; }
        [DisplayName("Category Name")]
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(0, 100)]
        [Required]
        public int DisplayOrder { get; set; }
    }
}
