using BusinessObjects.Entities;

namespace BusinessObjects.Interfaces.Facades
{
    public interface IUserFacade
    {
        public Task<IEnumerable<UserEntity>> GetAll();
        public Task<UserEntity> GetById(int id);
        public Task<UserEntity> GetByName(string name);
        public Task<int> Insert(UserEntity userEntity);
        public Task<int> Update(UserEntity userEntity);
        public Task<int> DeleteById(int id);
        public Task<int> DeleteByName(string name);
    }
}
