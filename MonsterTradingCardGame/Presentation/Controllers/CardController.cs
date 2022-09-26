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
    }
}
