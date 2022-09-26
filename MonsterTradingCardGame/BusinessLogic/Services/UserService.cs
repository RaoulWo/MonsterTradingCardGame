using BusinessObjects.Interfaces.Facades;
using BusinessObjects.Interfaces.Services;
using BusinessObjects.Models;
using DataAccess.Facades;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {

        public static IUserService Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new UserService(UserFacade.Singleton);
                }

                return _singleton;
            }
        }

        private static IUserService _singleton = null;

        private IUserFacade _userFacade;

        private UserService(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            List<User> list = new List<User>();
            list.Add(new User("Admin", "1234"));
            list.Add(new User("User", "1234"));

            return list;

            try
            {
                return await _userFacade.GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<User> GetById(int id)
        {
            try
            {
                return await _userFacade.GetById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Insert(User user)
        {
            try
            {
                return await _userFacade.Insert(user);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Update(User user)
        {
            try
            {
                return await _userFacade.Update(user);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                return await _userFacade.Delete(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
