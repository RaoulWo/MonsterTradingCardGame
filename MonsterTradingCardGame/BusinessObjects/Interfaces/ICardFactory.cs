using BusinessObjects.Entities;
using BusinessObjects.Enums;

namespace BusinessObjects.Interfaces
{
    public interface ICardFactory
    {
        public CardEntity GetCard(string name);
    }
}
