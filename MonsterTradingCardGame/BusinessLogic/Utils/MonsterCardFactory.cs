using BusinessObjects.Entities;
using BusinessObjects.Enums;
using BusinessObjects.Models;

namespace BusinessLogic.Utils
{
    public class MonsterCardFactory : CardFactory
    {
        public override CardEntity GetCard(string name)
        {
            switch (name)
            {
                case "Dragon":
                    return new MonsterCard("Dragon", 5, CardType.Monster, ElementType.Normal);
                default:
                    return null;
            }
        }
    }
}
