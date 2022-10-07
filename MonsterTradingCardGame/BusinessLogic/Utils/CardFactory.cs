using BusinessObjects.Entities;
using BusinessObjects.Enums;
using BusinessObjects.Interfaces;

namespace BusinessLogic.Utils
{
    public abstract class CardFactory : ICardFactory
    {
        public abstract CardEntity GetCard(string name);

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
