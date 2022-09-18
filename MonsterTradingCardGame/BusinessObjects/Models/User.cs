using BusinessObjects.Base;
using BusinessObjects.Interfaces;

namespace BusinessObjects.Models
{
    public class User : Entity, IAggregateRoot
    {
        public string Username { get; set; }

        public string Password { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
