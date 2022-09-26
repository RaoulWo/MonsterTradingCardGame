using BusinessObjects.Enums;
using BusinessObjects.Models;

namespace BusinessObjects.Interfaces
{
    public interface ICardFactory
    {
        public Card GetCard(string name);
    }
}
