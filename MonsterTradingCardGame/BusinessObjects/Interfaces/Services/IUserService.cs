using BusinessObjects.Entities;

namespace BusinessObjects.Interfaces.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<UserEntity>> GetAll();
        public Task<UserEntity> GetById(int id);
        public Task<UserEntity> GetByName(string name);
        public Task<int> Insert(UserEntity user);
        public Task<int> Update(UserEntity user);
        public Task<int> DeleteById(int id);
        public Task<int> DeleteByName(string name);
    }
}
