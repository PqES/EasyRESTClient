using System;

namespace MsCustomer.entities
{
    public class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }

        public Customer(long id, string name, string cpf, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Cpf = cpf;
            this.Email = email;
        }

        public Customer(long id)
        {
            this.Id = id;
        }

        public Customer(string name, string cpf, string email)
        {
            this.Name = name;
            this.Cpf = cpf;
            this.Email = email;
        }
        public Customer(string name, string cpf)
        {
            this.Name = name;
            this.Cpf = cpf;
        }

        public Customer() { }
        
        public string Tostring()
        {
            return String.Format("Cliente[id={0}, name='{1}', cpf='{2}' , email='{3}']", Id, Name, Cpf, Email);
        }

    }
}
