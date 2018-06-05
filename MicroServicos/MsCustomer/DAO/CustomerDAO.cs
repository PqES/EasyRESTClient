using MsCustomer.entities;
using System.Collections.Generic;

namespace MsCustomer.DAO
{
    public interface CustomerDAO
    {
        Customer Save(Customer c);

        Customer FindByCpf(string cpf);

        Customer FindByName(string name);

        void Delete(Customer c);

        List<Customer> FindAll();
    }
}
