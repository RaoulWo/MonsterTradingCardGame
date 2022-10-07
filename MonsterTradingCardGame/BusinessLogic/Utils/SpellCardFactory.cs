using BusinessObjects.Entities;
using BusinessObjects.Enums;
using BusinessObjects.Models;

namespace BusinessLogic.Utils
{
    public class SpellCardFactory : CardFactory
    {
        public override CardEntity GetCard(string name)
        {
            switch (name)
            {
                case "Spell":
                    return new SpellCard("Spell", 5, CardType.Spell, ElementType.Normal);
                default:
                    return null;
            }
        }
    }
}
