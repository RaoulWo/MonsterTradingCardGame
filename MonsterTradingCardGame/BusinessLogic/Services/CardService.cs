using BusinessLogic.Utils;
using BusinessObjects.Enums;
using BusinessObjects.Interfaces.Services;
using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CardService : ICardService
    {
        public Utils.CardFactory cardFactory;

        public CardService(FactoryType factoryType)
        {
            this.cardFactory = CardFactory.CreateCardFactory(factoryType);
        }

        public Card GetCard(CardType cardType)
        {
            return cardFactory.GetCard(cardType);
        }
    }
}
