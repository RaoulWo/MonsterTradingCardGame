using System.Data.SqlClient;
using BusinessObjects.Interfaces;
using BusinessObjects.Interfaces.Repositories;
using BusinessObjects.Models;

namespace DataAccess.Facades
{
    public class UserFacade
    {
        private IUserRepository _userRepository;
        private IUnitOfWork _unitOfWork;

        public UserFacade(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<User> GetAll()
        {
            string sqlStatement = "SELECT * FROM User";
            IEnumerable<User> users;

            try
            {
                users = _userRepository.GetAll(sqlStatement);
            }
            catch (Exception e)
            {
                throw e;
            }

            return users;
        }

        public User GetById(int id)
        {
            string sqlStatement = "SELECT * FROM User WHERE Id = @Id";
            User user = new User();

            try
            {
                user = _userRepository.GetById(id, sqlStatement);
            }
            catch (Exception e)
            {
                throw e;
            }

            return user;
        }

        public int Insert(User user)
        {
            string sqlStatement = "INSERT INTO Person (Username, Password) VALUES (@Username, @Password)";
            int rowsAffected = 0;

            try
            {
                SqlTransaction transaction = _unitOfWork.BeginTransaction();
                rowsAffected = _userRepository.Insert(user, sqlStatement, transaction);
                _unitOfWork.CommitTransaction();
            }
            catch (Exception e)
            {
                throw e;
            }

            return rowsAffected;
        }

        public int Update(User user)
        {
            string sqlStatement = "UPDATE User SET Username = @Username, Password = @Password WHERE Id = @Id";
            int rowsAffected = 0;

            try
            {
                SqlTransaction transaction = _unitOfWork.BeginTransaction();
                rowsAffected = _userRepository.Update(user, sqlStatement, transaction);
                _unitOfWork.CommitTransaction();
            }
            catch (Exception e)
            {
                throw e;
            }

            return rowsAffected;
        }

        public int Delete(int id)
        {
            string sqlStatement = "DELETE FROM User WHERE Id = @Id";
            int rowsAffected = 0;

            try
            {
                SqlTransaction transaction = _unitOfWork.BeginTransaction();
                rowsAffected = _userRepository.Delete(id, sqlStatement, transaction);
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
