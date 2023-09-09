using EntityFrameWorkCodeFirstAPP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameWorkCodeFirstAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _userContext;

        public UsersController(UserContext userContext)
        {
            _userContext = userContext;
        }

        [HttpGet]
        [Route("GetUsers")]
        public List<Users> GetUsers()
        {
            return _userContext.Users.ToList();
        }

        [HttpGet]
        [Route("GetUser")]
        public Users GetUser(int id)
        {
            return _userContext.Users.Where(x => x.UserId==id).ToList().FirstOrDefault();
        }

        [HttpPost]
        [Route("AddUsers")]
        public string AddUsers(Users users)
        {
            string response = string.Empty;
            _userContext.Users.Add(users);
            _userContext.SaveChanges();
            return "User Added";
        }

        [HttpPut]
        [Route("UpdateUser")]
        public string UpdateUsers(Users user)
        {
            _userContext.Entry(user).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            _userContext.SaveChanges();
            return "UserUpdated";


        }

        [HttpDelete]
        [Route("DeleteUser")]
        public string DeleteUsers(int id)
        {
            Users user = _userContext.Users.Where(u => u.UserId==id).ToList().FirstOrDefault();
            
            if (user != null) {
                _userContext.Users.Remove(user);
                _userContext.SaveChanges();
                return "UserDeleted";
            }
            else{ return "NoUserDeleted"; }
            
        }
    }
}
