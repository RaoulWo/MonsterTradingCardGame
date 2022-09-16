using BusinessLogic.Controllers;
using BusinessLogic.Services;
using BusinessObjects.Enums;
using BusinessObjects.Interfaces.Controllers;
using BusinessObjects.Models;

namespace Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICardController controller = new CardController(new CardService(FactoryType.Monster));
            Card dragon = controller.GetCard(CardType.Dragon);

            Console.WriteLine($"Name: {dragon.Name}");
            Console.WriteLine($"Damage: {dragon.Damage}");
            Console.WriteLine($"ElementType: {dragon.ElementType}");
        }
    }
}