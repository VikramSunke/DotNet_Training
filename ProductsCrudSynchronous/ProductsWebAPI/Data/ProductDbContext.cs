using Microsoft.EntityFrameworkCore;
using ProductsWebAPI.Modals;
using System.Collections.Generic;

namespace ProductsWebAPI.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> contextOptions) : base(contextOptions)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Costumer> Costumers { get; set; }

        public DbSet<CostumerProduct> CostumerProducts { get; set; }
    }
}
