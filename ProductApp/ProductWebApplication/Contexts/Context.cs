namespace ProductWebApplication.Contexts
{
    using Microsoft.EntityFrameworkCore;
    using ProductWebApplication.Models;

    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>()
                .HasMany<Product>(x => x.Products)
                .WithOne(x => x.Manufacturer);

            modelBuilder.Entity<Product>()
                .HasOne<Manufacturer>(x => x.Manufacturer)
                .WithMany(x => x.Products);
        }

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
