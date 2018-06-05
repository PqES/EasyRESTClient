using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MsCustomer.DAO;
using MsCustomer.entities;

namespace MsCustomer.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {

        private CustomerDAO customerDAO;

        public string Index()
        {
            return "gerenciador";
        }

        // POST api/AddCustomer
        [HttpPost]
        public string AddCustomer(string name, string cpf, string email)
        {
            string idCustomer = "";
            try
            {
                Customer c = new Customer(name, cpf, email);
                customerDAO.Save(c);
                idCustomer = c.Id.ToString();
            }
            catch (Exception ex)
            {
                return "Error creating the user: " + ex.ToString();
            }

            return "Sucess! ";
        }


        // GET api/GetAllClientes
        [HttpGet]
        public List<Customer> GetAllClientes()
        {
            List<Customer> customers = new List<Customer>();
            foreach (Customer customer in customerDAO.FindAll())
            {
                customers.Add(customer);
            }

            return customers;
        }


        // GET api/GetClientePorCpf
        [HttpGet]
        public Customer GetClientePorCpf(string cpf)
        {
            Customer c = customerDAO.FindByCpf(cpf);
            return c;
        }


        // GET api/GetClientePorCpf
        [HttpGet]
        public string Delete(string cpf)
        {
            Customer c = customerDAO.FindByCpf(cpf);
            try
            {
                customerDAO.Delete(c);
            }
            catch (Exception ex)
            {
                return "Error deleting the user:" + ex.ToString();
            }

            return "Customer deleted!";
        }

    }
}