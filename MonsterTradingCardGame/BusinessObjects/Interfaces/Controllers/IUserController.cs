
using BusinessObjects.Models;

namespace BusinessObjects.Interfaces.Controllers
{
    public interface IUserController
    {
        public Task<string> GetAll(HttpRequest httpRequest);
        public Task<string> GetById(HttpRequest httpRequest);
        public Task<string> GetByName(HttpRequest httpRequest);
        public Task<string> Insert(HttpRequest httpRequest);
        public Task<string> Update(HttpRequest httpRequest);
        public Task<string> DeleteById(HttpRequest httpRequest);
        public Task<string> DeleteByName(HttpRequest httpRequest);
    }
}
