﻿using BusinessObjects.Enums;
using BusinessObjects.Models;

namespace BusinessObjects.Interfaces.Services
{
    public interface ICardService
    {
        public Card GetCard(CardType cardType);
    }
}
