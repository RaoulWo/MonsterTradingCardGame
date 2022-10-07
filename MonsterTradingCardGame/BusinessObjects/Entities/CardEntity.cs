using BusinessObjects.Base;
using BusinessObjects.Enums;
using BusinessObjects.Interfaces;

namespace BusinessObjects.Entities
{
    public class CardEntity : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public CardType CardType { get; set; }
        public ElementType ElementType { get; set; }

        public CardEntity()
        {

        }

        public CardEntity(string name, int damage, CardType cardType, ElementType elementType)
        {
            Name = name;
            Damage = damage;
            CardType = cardType;
            ElementType = elementType;
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
