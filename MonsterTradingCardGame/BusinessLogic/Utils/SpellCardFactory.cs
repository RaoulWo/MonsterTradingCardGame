using BusinessObjects.Enums;
using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Utils
{
    public class SpellCardFactory : CardFactory
    {
        public override Card GetCard(CardType cardType)
        {
            switch (cardType)
            {
                case CardType.Spell:
                    return new SpellCard("Spell", 5, ElementType.Normal);
                default:
                    return null;
            }
        }
    }
}
