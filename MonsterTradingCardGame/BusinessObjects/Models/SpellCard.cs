using BusinessObjects.Enums;

namespace BusinessObjects.Models
{
    public class SpellCard : Card
    {
        public SpellCard(string name, int damage, CardType cardType, ElementType elementType)
            : base(name, damage, cardType, elementType)
        { }
    }
}
