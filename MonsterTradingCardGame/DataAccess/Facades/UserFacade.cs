using BusinessObjects.Interfaces;
using BusinessObjects.Interfaces.Facades;
using BusinessObjects.Interfaces.Repositories;
using BusinessObjects.Models;
using DataAccess.Repositories;
using Npgsql;

namespace DataAccess.Facades
{
    public class UserFacade : IUserFacade
    {
        public static UserFacade Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new UserFacade(UserRepository.Singleton, UnitOfWork.Singleton);
                }

                return _singleton;
            }
        }

        private static UserFacade _singleton = null;

        private IUserRepository _userRepository;
        private IUnitOfWork _unitOfWork;

        private UserFacade(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            string sqlStatement = "SELECT * FROM public.\"User\"";
            IEnumerable<User> users = null;

            try
            {
                users = await _userRepository.GetAll(sqlStatement);
            }
            catch (Exception e)
            {
                throw e;
            }

            return users;
        }

        public async Task<User> GetById(int id)
        {
            string sqlStatement = "SELECT * FROM public.\"User\" WHERE Id = @Id";
            User user = null;

            try
            {
                user = await _userRepository.GetById(id, sqlStatement);
            }
            catch (Exception e)
            {
                throw e;
            }

            return user;
        }
        public async Task<User> GetByName(string name)
        {
            string sqlStatement = "SELECT * FROM public.\"User\" WHERE Username = @Username";
            User user = null;

            try
            {
                user = await _userRepository.GetByName(name, sqlStatement);
            }
            catch (Exception e)
            {
                throw e;
            }

            return user;
        }

        public async Task<int> Insert(User user)
        {
            string sqlStatement = "INSERT INTO public.\"User\" (Username, Password) VALUES (@Username, @Password)";
            int rowsAffected = 0;

            try
            {
                NpgsqlTransaction transaction = _unitOfWork.BeginTransaction();
                rowsAffected = await _userRepository.Insert(user, sqlStatement, transaction);
                _unitOfWork.CommitTransaction();
            }
            catch (Exception e)
            {
                throw e;
            }

            return rowsAffected;
        }

        public async Task<int> Update(User user)
        {
            string sqlStatement = "UPDATE public.\"User\" SET Username = @Username, Password = @Password WHERE Id = @Id";
            int rowsAffected = 0;

            try
            {
                NpgsqlTransaction transaction = _unitOfWork.BeginTransaction();
                rowsAffected = await _userRepository.Update(user, sqlStatement, transaction);
                _unitOfWork.CommitTransaction();
            }
            catch (Exception e)
            {
                throw e;
            }

            return rowsAffected;
        }

        public async Task<int> DeleteById(int id)
        {
            string sqlStatement = "DELETE FROM public.\"User\" WHERE Id = @Id";
            int rowsAffected = 0;

            try
            {
                NpgsqlTransaction transaction = _unitOfWork.BeginTransaction();
                rowsAffected = await _userRepository.DeleteById(id, sqlStatement, transaction);
                _unitOfWork.CommitTransaction();
            }
            catch (Exception e)
            {
                throw e;
            }

            return rowsAffected;
        }

        public async Task<int> DeleteByName(string name)
        {
            string sqlStatement = "DELETE FROM public.\"User\" WHERE Username = @Username";
            int rowsAffected = 0;

            try
            {
                NpgsqlTransaction transaction = _unitOfWork.BeginTransaction();
                rowsAffected = await _userRepository.DeleteByName(name, sqlStatement, transaction);
                _unitOfWork.CommitTransaction();
            }
            catch (Exception e)
            {
                throw e;
            }

            return rowsAffected;
        }
    }
}
