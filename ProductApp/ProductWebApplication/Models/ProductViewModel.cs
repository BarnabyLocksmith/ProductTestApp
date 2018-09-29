namespace ProductWebApplication.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Image { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
