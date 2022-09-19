
using BusinessObjects.Models;

namespace BusinessObjects.Interfaces.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
    }
}
