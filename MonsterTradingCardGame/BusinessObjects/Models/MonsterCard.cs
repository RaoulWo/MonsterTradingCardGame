using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public class MonsterCard : Card
    {
        public MonsterCard(string name, int damage, ElementType elementType)
            : base(name, damage, elementType)
        { }
    }
}
