using BusinessLogic.Utils;
using BusinessObjects.Enums;
using BusinessObjects.Interfaces.Services;
using BusinessObjects.Models;

namespace BusinessLogic.Services
{
    public class CardService : ICardService
    {
        public Utils.CardFactory CardFactory;

        public CardService(FactoryType factoryType)
        {
            this.CardFactory = CardFactory.CreateCardFactory(factoryType);
        }

        public Card GetCard(CardType cardType)
        {
            return CardFactory.GetCard(cardType);
        }
    }
}
