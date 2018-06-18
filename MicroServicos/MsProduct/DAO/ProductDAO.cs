using MsProduct.Entities;

namespace MsProduct.DAO
{
    public class ProductDAO : GenericRepository<Product>, IProductDAO
    {
        public ProductDAO(CatalogContext dbContext)
            : base(dbContext)
        {
        }
    }
}