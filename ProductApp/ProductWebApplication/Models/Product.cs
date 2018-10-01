namespace ProductWebApplication.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public Product()
        {
            this.Manufacturer = new Manufacturer();
        }

        public string Image { get; set; }

        public Manufacturer Manufacturer { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public Guid UpdatedBy { get; set; }

        public byte[] ImageData { get; set; }
    }
}
