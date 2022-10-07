using BusinessObjects.Entities;

namespace BusinessObjects.Interfaces.Facades
{
    public interface ICardFacade
    {
        public Task<IEnumerable<CardEntity>> GetAll();
        public Task<CardEntity> GetById(int id);
        public Task<int> Insert(CardEntity cardEntity);
        public Task<int> Update(CardEntity cardEntity);
        public Task<int> DeleteById(int id);
    }
}
