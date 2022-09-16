using BusinessObjects.Enums;

namespace BusinessObjects.Models
{
    public class MonsterCard : Card
    {
        public MonsterCard(string name, int damage, ElementType elementType)
            : base(name, damage, elementType)
        { }
    }
}
