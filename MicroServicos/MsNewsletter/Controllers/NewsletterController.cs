using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MsNewsletter.Entities;
using MsNewsletter.DAO;
using MsNewsletter.Email;

namespace MsNewsletter.Controllers
{
    [Route("[controller]")]
    public class NewsletterController : Controller
    {

        [HttpPost("Subscribe")]
        public bool Subscribe(string cpf, string email)
        {
            return UserDAO.RegisterUser(new User(cpf, email));
        }


        [HttpGet("Publish")]
        public bool Publish()
        {
            LinkedList<User> users = UserDAO.GetAllUsers();
			foreach(User user in users){
				EmailManager.sendEmail(user);
			}
			return true;
        }
    }
}
