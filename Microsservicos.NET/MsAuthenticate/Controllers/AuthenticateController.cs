using Microsoft.AspNetCore.Mvc;
using MsAuthentication.DAO;
using MsAuthentication.Entities;
namespace MsAuthentication.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticateController : Controller
    {
        [HttpPost]
        public bool Authenticate(string username, string password)
        {
            string userLine  = UserDAO.GetUserByUsername(username);
            if(userLine != null){
                string[] userSplited = userLine.Split(';');
                User user = new User(userSplited[0], userSplited[1]);
                return user.Password == password;
            }
			return false;
        }
    }
}
