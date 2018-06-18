using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MsCustomer.DAO;
using MsCustomer.entities;

namespace MsCustomer.Controllers
{
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private ICustomerDAO customerDAO;
        public CustomerController(ICustomerDAO _customerDAO)
        {
            customerDAO = _customerDAO;
        }

        public string Index()
        {
            return "gerenciador";
        }


        [HttpPost, Route("AddCustomer")]
        public string AddCustomer(string name, string cpf, string email)
        {
            string idCustomer = "";
            try
            {
                Customer c = new Customer(name, cpf, email);
                customerDAO.Create(c);
                idCustomer = c.Id.ToString();
            }
            catch (Exception ex)
            {
                return "Error creating the user: " + ex.ToString();
            }

            return "Sucess! ";
        }


        [HttpGet, Route("GetAllClientes")]
        public List<Customer> GetAllClientes()
        {
            var result = customerDAO.GetAll().ToList();
            return result;
        }


        [HttpGet, Route("GetClientePorCpf")]
        public Customer GetClientePorCpf(string cpf)
        {
            return customerDAO.FindByCpf(cpf);
        }


        [HttpGet, Route("Delete")]
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