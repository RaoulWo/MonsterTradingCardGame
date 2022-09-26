
namespace BusinessObjects.Models
{
    public class Deck
    {
        public List<Card> Cards { get; }

        public Deck(List<Card> cards)
        {
            Cards = cards;
        }
    }
}
