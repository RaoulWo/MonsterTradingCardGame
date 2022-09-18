using BusinessObjects.Interfaces.Services;
using BusinessObjects.Models;
using DataAccess.Facades;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private UserFacade _userFacade;

        public UserService(UserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> users;

            try
            {
                users = _userFacade.GetAll();
            }
            catch (Exception e)
            {
                throw;
            }

            return users;
        }
    }
}
