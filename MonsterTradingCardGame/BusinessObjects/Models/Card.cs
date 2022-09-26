using System.Dynamic;
using BusinessObjects.Base;
using BusinessObjects.Enums;
using BusinessObjects.Interfaces;

namespace BusinessObjects.Models
{
    public abstract class Card : Entity, IAggregateRoot
    {
        public string Name { get; }
        public int Damage { get; }
        public CardType CardType { get; }
        public ElementType ElementType { get; }

        protected Card(string name, int damage, CardType cardType, ElementType elementType)
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
