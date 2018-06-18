using MsCustomer.entities;
using System.Collections.Generic;

namespace MsCustomer.DAO
{
    public interface ICustomerDAO : IGenericRepository<Customer>
    {
        Customer FindByCpf(string cpf);
        Customer FindByName(string name);
    }
}
