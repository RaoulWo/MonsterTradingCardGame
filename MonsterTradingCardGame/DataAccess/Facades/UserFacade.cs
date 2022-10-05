using BusinessObjects.Entities;
using BusinessObjects.Interfaces;
using BusinessObjects.Interfaces.Facades;
using BusinessObjects.Interfaces.Repositories;
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

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            string sqlStatement = "SELECT * FROM public.\"user\"";
            IEnumerable<UserEntity> users = null;

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

        public async Task<UserEntity> GetById(int id)
        {
            string sqlStatement = "SELECT * FROM public.\"user\" WHERE Id = @Id";
            UserEntity user = null;

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
        public async Task<UserEntity> GetByName(string name)
        {
            string sqlStatement = "SELECT * FROM public.\"user\" WHERE Username = @Username";
            UserEntity user = null;

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

        public async Task<int> Insert(UserEntity user)
        {
            string sqlStatement = "INSERT INTO public.\"user\" (Username, Password) VALUES (@Username, @Password)";
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

        public async Task<int> Update(UserEntity user)
        {
            string sqlStatement = "UPDATE public.\"user\" SET Username = @Username, Password = @Password WHERE Id = @Id";
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
            string sqlStatement = "DELETE FROM public.\"user\" WHERE Id = @Id";
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
            string sqlStatement = "DELETE FROM public.\"user\" WHERE Username = @Username";
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
