using BusinessObjects.Enums;
using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Interfaces.Services
{
    public interface ICardService
    {
        public Card GetCard(CardType cardType);
    }
}
