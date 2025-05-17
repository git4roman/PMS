using System.ComponentModel.DataAnnotations;

namespace PMS.Web.Models.Products
{
    public class ProductUpdateViewModel
    {
        
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public IFormFile? Image { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Price { get; set; }
        
    }
}
