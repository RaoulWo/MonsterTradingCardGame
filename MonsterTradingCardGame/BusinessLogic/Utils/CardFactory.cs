using BusinessObjects.Enums;
using BusinessObjects.Interfaces;
using BusinessObjects.Models;

namespace BusinessLogic.Utils
{
    public abstract class CardFactory : ICardFactory
    {
        public abstract Card GetCard(string name);

        public static ICardFactory CreateCardFactory(CardType cardType)
        {
            switch (cardType)
            {
                case CardType.Monster:
                    return new MonsterCardFactory();
                case CardType.Spell:
                    return new SpellCardFactory();
                default:
                    return null;
            }
        }
    }
}
