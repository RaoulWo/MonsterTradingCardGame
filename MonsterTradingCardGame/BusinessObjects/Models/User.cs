using BusinessObjects.Base;
using BusinessObjects.Interfaces;

namespace BusinessObjects.Models
{
    public class User : Entity, IAggregateRoot
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Coins { get; set; }
        public Collection Collection { get; set; }
        public Deck Deck { get; set; }

        public User()
        {

        }

        public User(int id, string username, string password, int coins, Collection collection, Deck deck)
        {
            Id = id;    
            Username = username;
            Password = password;
            Coins = coins;
            Collection = collection;
            Deck = deck;

        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
