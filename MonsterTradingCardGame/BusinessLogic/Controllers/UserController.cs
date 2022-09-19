using BusinessObjects.Interfaces.Controllers;
using BusinessObjects.Interfaces.Services;
using BusinessObjects.Models;

namespace BusinessLogic.Controllers
{
    public class UserController : IUserController
    {
        public IUserService UserService;

        public UserController(IUserService userService)
        {
            this.UserService = userService;
        }

        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> users = null;

            try
            {
                users = UserService.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return users;
        }
    }
}
