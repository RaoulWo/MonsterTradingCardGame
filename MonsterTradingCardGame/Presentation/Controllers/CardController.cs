using BusinessObjects.Enums;
using BusinessObjects.Models;
using BusinessObjects.Interfaces.Controllers;
using BusinessObjects.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Controllers
{
    public class CardController : ICardController
    {
        public ICardService cardService;

        public CardController(ICardService cardService)
        {
            this.cardService = cardService;
        }

        public Card GetCard(CardType cardType)
        {
            return this.cardService.GetCard(cardType);
        }
    }
}
