using BusinessObjects.Interfaces.Controllers;
using BusinessObjects.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Controllers
{
    public class UserController : IUserController
    {
        public IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
    }
}
