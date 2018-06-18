using Microsoft.AspNetCore.Mvc;
using MsProduct.DAO;
using MsProduct.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace MsProduct.Controllers
{

    [Route("[controller]")]
    public class ProductController : Controller
    {
        private IProductDAO productDAO;
        public ProductController(IProductDAO _productDAO)
        {
            productDAO = _productDAO;
        }

        public string Index()
        {
            return "index";
        }

        [Route("FallbackMethod")]
        public string FallbackMethod()
        {
            return "fallback method";
        }


        [HttpPost, Route("AddProduct")]
        public string AddProduct(string name, string description, int number, double value)
        {
            string idProduct = "";
            try
            {
                Product p = new Product(name, description, number, value);
                productDAO.Create(p);
                idProduct = p.Id.ToString();
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }

            return "Sucess";
        }

        [HttpGet, Route("GetAllProducts")]
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            products = productDAO.GetAll().Where(p => p.Number > 0).ToList();
            return products;
        }

        [HttpGet, Route("UpdateStock")]
        public string UpdateStock(string[] id, string[] qt)
        {

            int[] estoque = new int[id.Length];
            Product[] products = new Product[id.Length];
            for (int i = 0; i < estoque.Length; i++)
            {
                products[i] = productDAO.GetById(int.Parse(id[i])).Result;
                estoque[i] = products[i].Number - int.Parse(qt[i]);
                if (estoque[i] < 0)
                {
                    return "fail";
                }
            }
            for (int i = 0; i < estoque.Length; i++)
            {
                products[i].Number = estoque[i];
                productDAO.Create(products[i]);
            }
            return "sucess";
        }
    }
}