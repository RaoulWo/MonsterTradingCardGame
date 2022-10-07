
using BusinessObjects.Entities;

namespace BusinessObjects.Models
{
    public class Collection
    {
        public List<CardEntity> Cards { get; }

        public Collection(List<CardEntity> cards)
        {
            Cards = cards;
        }
    }
}
