using BusinessObjects.Enums;
using BusinessObjects.Models;

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
