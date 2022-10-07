using BusinessObjects.Entities;
using BusinessObjects.Enums;

namespace BusinessObjects.Models
{
    public class MonsterCard : CardEntity
    {
        public MonsterCard(string name, int damage, CardType cardType, ElementType elementType)
            : base(name, damage, cardType, elementType)
        { }
    }
}
