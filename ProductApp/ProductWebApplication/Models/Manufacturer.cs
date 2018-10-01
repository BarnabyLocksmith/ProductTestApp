namespace ProductWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Manufacturer
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public string Logo { get; set; }

        public List<Product> Products { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public Guid UpdatedBy { get; set; }

        public byte[] LogoData { get; set; }
    }
}
