using BusinessLogic.Services;
using BusinessObjects.Interfaces.Controllers;
using BusinessObjects.Interfaces.Services;
using BusinessObjects.Models;

namespace Presentation.Controllers
{
    public class UserController : IUserController
    {
        public static IUserController Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new UserController(UserService.Singleton);
                }

                return _singleton;
            }
        }

        private static IUserController _singleton = null;
        
        private IUserService _userService;

        private UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<string> GetAll(HttpRequest httpRequest)
        {
            IEnumerable<User> users = null;

            try
            {
                users = await _userService.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(users);
        }

        public async Task<string> GetById(HttpRequest httpRequest)
        {
            int id = Convert.ToInt32(httpRequest.Target.Substring(7));

            User user = null;

            try
            {
                user = await _userService.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(user);
        }

        public async Task<string> Insert(HttpRequest httpRequest)
        {
            User user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(httpRequest.Body);

            int rowsAffected = 0;

            try
            {
                rowsAffected = await _userService.Insert(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(new { rowsAffected = rowsAffected });
        }

        public async Task<string> Update(HttpRequest httpRequest)
        {
            User user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(httpRequest.Body);

            int rowsAffected = 0;

            try
            {
                rowsAffected = await _userService.Update(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(new { rowsAffected = rowsAffected });
        }

        public async Task<string> Delete(HttpRequest httpRequest)
        {
            int id = Convert.ToInt32(httpRequest.Target.Substring(7));

            int rowsAffected = 0;

            try
            {
                rowsAffected = await _userService.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(new { rowsAffected = rowsAffected });
        }
    }
}
