using BusinessObjects.Enums;

namespace BusinessObjects.Models
{
    public abstract class Card : Interfaces.ICard
    {
        public string Name { get; }
        public int Damage { get; }
        public ElementType ElementType { get; }

        protected Card(string name, int damage, ElementType elementType)
        {
            Name = name;
            Damage = damage;
            ElementType = elementType;
        }
    }
}
