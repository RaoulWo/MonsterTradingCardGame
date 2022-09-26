using BusinessObjects.Enums;

namespace BusinessObjects.Models
{
    public class MonsterCard : Card
    {
        public MonsterCard(string name, int damage, CardType cardType, ElementType elementType)
            : base(name, damage, cardType, elementType)
        { }
    }
}
