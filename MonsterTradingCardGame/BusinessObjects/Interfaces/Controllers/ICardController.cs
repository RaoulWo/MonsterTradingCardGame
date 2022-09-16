using BusinessObjects.Enums;
using BusinessObjects.Models;

namespace BusinessObjects.Interfaces.Controllers
{
    public interface ICardController
    {
        public Card GetCard(CardType cardType);
    }
}
