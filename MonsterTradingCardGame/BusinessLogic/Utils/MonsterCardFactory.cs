using BusinessObjects.Enums;
using BusinessObjects.Models;

namespace BusinessLogic.Utils
{
    public class MonsterCardFactory : CardFactory
    {
        public override Card GetCard(CardType cardType)
        {
            switch (cardType)
            {
                case CardType.Dragon:
                    return new MonsterCard("Dragon", 5, ElementType.Normal);
                default:
                    return null;
            }
        }
    }
}
