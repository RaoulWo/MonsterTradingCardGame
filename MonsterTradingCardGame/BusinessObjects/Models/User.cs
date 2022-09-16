using BusinessObjects.Interfaces;

namespace BusinessObjects.Models
{
    internal class User : IUser
    {
        public ICredentials Credentials { get; }

        public User(ICredentials credentials)
        {
            Credentials = credentials;
        }
    }
}
