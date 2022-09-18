
using BusinessObjects.Models;

namespace BusinessObjects.Interfaces.Controllers
{
    public interface IUserController
    {
        IEnumerable<User> GetAll();
    }
}
