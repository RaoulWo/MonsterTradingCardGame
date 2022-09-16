using BusinessObjects.Enums;
using BusinessObjects.Models;
using BusinessObjects.Interfaces.Controllers;
using BusinessObjects.Interfaces.Services;

namespace Presentation.Controllers
{
    public class CardController : ICardController
    {
        public ICardService CardService;

        public CardController(ICardService cardService)
        {
            this.CardService = cardService;
        }

        public Card GetCard(CardType cardType)
        {
            return this.CardService.GetCard(cardType);
        }
    }
}
