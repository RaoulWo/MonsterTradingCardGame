using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public abstract class Card : Interfaces.ICard
    {
        public string Name { get; }
        public int Damage { get; }
        public ElementType ElementType { get; }

        public Card(string name, int damage, ElementType elementType)
        {
            Name = name;
            Damage = damage;
            ElementType = elementType;
        }
    }
}
