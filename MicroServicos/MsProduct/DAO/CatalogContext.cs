using Microsoft.EntityFrameworkCore;
using MsProduct.Entities;

namespace MsProduct.DAO
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {

        }

        public DbSet<Product> CatalogItems { get; set; }
    }

}
