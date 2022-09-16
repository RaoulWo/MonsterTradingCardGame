using BusinessObjects.Interfaces.Controllers;
using BusinessObjects.Interfaces.Services;

namespace Presentation.Controllers
{
    public class UserController : IUserController
    {
        public IUserService UserService;

        public UserController(IUserService userService)
        {
            this.UserService = userService;
        }
    }
}
