using MsProduct.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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