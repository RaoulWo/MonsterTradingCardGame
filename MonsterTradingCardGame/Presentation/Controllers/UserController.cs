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

        public async Task<IEnumerable<User>> GetAll()
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

            return users;
        }

        public async Task<User> GetById(int id)
        {
            User user = null;

            try
            {
                user = await _userService.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return user;
        }

        public async Task<User> GetByName(string name)
        {
            User user = null;

            try
            {
                user = await _userService.GetByName(name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return user;
        }

        public async Task<int> Insert(User user)
        {
            int rowsAffected = 0;

            try
            {
                rowsAffected = await _userService.Insert(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return rowsAffected;
        }

        public async Task<int> Update(User user)
        {
            int rowsAffected = 0;

            try
            {
                rowsAffected = await _userService.Update(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return rowsAffected;
        }

        public async Task<int> Delete(int id)
        {
            int rowsAffected = 0;

            try
            {
                rowsAffected = await _userService.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return rowsAffected;
        }

        public async Task<int> Delete(string name)
        {
            int rowsAffected = 0;

            try
            {
                rowsAffected = await _userService.Delete(name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return rowsAffected;
        }
    }
}
