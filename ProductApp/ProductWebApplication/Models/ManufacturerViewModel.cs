namespace ProductWebApplication.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ManufacturerViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Logo { get; set; }

        public byte[] LogoData { get; set; }
    }
}
