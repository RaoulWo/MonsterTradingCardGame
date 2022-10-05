using BusinessObjects.Base;
using BusinessObjects.Interfaces;

namespace BusinessObjects.Entities
{
    public class UserEntity : Entity, IAggregateRoot
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Coins { get; set; }

        public UserEntity()
        {

        }

        public UserEntity(int id, string username, string password, int coins)
        {
            Id = id;
            Username = username;
            Password = password;
            Coins = coins;
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
