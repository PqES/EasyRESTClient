using MsCustomer.entities;

namespace MsCustomer.DAO
{
    public class CustomerDAO : GenericRepository<Customer>, ICustomerDAO
    {
        private CatalogContext _dbContext;

        public CustomerDAO(CatalogContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Customer FindByCpf(string cpf)
        {
            return GetBy(c => c.Cpf == cpf);
        }

        public Customer FindByName(string name)
        {
            return GetBy(c => c.Name == name);
        }
    }
}