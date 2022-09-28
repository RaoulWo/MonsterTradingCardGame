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
            list.Add(new User(1, "Admin", "Admin", 20, null, null));
            list.Add(new User(2, "User1", "User1", 20, null, null));
            list.Add(new User(3, "User2", "User2", 20, null, null));
            list.Add(new User(4, "User3", "User3", 20, null, null));
            list.Add(new User(5, "User4", "User4", 20, null, null));
            list.Add(new User(6, "User5", "User5", 20, null, null));

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
            IEnumerable<User> list = await GetAll();

            foreach (User user in list)
            {
                if (user.Id == id) return user;
            }

            return null;

            try
            {
                return await _userFacade.GetById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<User> GetByName(string name)
        {
            IEnumerable<User> list = await GetAll();

            foreach (User user in list)
            {
                if (user.Username == name) return user;
            }

            return null;

            try
            {
                return await _userFacade.GetByName(name);
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
