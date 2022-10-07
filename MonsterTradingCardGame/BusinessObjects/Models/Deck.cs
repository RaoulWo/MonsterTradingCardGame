
using BusinessObjects.Entities;

namespace BusinessObjects.Models
{
    public class Deck
    {
        public List<CardEntity> Cards { get; }

        public Deck(List<CardEntity> cards)
        {
            Cards = cards;
        }
    }
}
