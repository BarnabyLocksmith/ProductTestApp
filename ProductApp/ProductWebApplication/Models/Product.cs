namespace ProductWebApplication.Models
{
    using System;

    public class Product
    {
        public Product()
        {
            this.Manufacturer = new Manufacturer();
        }

        public string Image { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public string Name { get; set; }

        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public Guid UpdatedBy { get; set; }
    }
}
