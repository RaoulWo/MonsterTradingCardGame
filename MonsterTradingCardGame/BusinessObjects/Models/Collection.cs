
namespace BusinessObjects.Models
{
    public class Collection
    {
        public List<Card> Cards { get; }

        public Collection(List<Card> cards)
        {
            Cards = cards;
        }
    }
}
