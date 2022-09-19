using BusinessObjects.Enums;
using BusinessObjects.Interfaces;
using BusinessObjects.Models;

namespace BusinessLogic.Utils
{
    public abstract class CardFactory : ICardFactory
    {
        public abstract Card GetCard(CardType cardType);

        public static ICardFactory CreateCardFactory(FactoryType factoryType)
        {
            switch (factoryType)
            {
                case FactoryType.Monster:
                    return new MonsterCardFactory();
                case FactoryType.Spell:
                    return new SpellCardFactory();
                default:
                    return null;
            }
        }
    }
}
