
using BusinessObjects.Models;

namespace BusinessObjects.Interfaces.Facades
{
    public interface IUserFacade
    {
        public Task<IEnumerable<User>> GetAll();
        public Task<User> GetById(int id);
        public Task<int> Insert(User user);
        public Task<int> Update(User user);
        public Task<int> Delete(int id);
    }
}
