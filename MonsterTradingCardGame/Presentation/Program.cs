
using BusinessObjects.Interfaces.Controllers;
using BusinessObjects.Models;
using Presentation.Controllers;

namespace Presentation
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IUserController userController = UserController.Singleton;

            IEnumerable<User> users = await userController.GetAll();

            foreach (User user in users)
            {
                Console.WriteLine(user.Username);
                Console.WriteLine(user.Password);
                Console.WriteLine("");
            }

        }
    }
}