using BusinessObjects.Entities;

namespace BusinessObjects.Interfaces.Services
{
    public interface ICardService
    {
        public Task<IEnumerable<CardEntity>> GetAll();
        public Task<CardEntity> GetById(int id);
        public Task<int> Insert(CardEntity card);
        public Task<int> Update(CardEntity card);
        public Task<int> DeleteById(int id);
    }
}
