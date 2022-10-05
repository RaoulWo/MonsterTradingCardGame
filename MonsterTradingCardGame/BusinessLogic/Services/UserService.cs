using BusinessObjects.Entities;
using BusinessObjects.Interfaces.Facades;
using BusinessObjects.Interfaces.Services;
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

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            try
            {
                return await _userFacade.GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<UserEntity> GetById(int id)
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

        public async Task<UserEntity> GetByName(string name)
        {
            try
            {
                return await _userFacade.GetByName(name);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Insert(UserEntity user)
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

        public async Task<int> Update(UserEntity user)
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

        public async Task<int> DeleteById(int id)
        {
            try
            {
                return await _userFacade.DeleteById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> DeleteByName(string name)
        {
            try
            {
                return await _userFacade.DeleteByName(name);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }

}
