using BusinessLogic.Services;
using BusinessObjects.Entities;
using BusinessObjects.Enums;
using BusinessObjects.Interfaces.Controllers;
using BusinessObjects.Interfaces.Services;
using BusinessObjects.Models;

namespace Presentation.Controllers
{

    public class CardController : ICardController
    {

        public static ICardController Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new CardController(CardService.Singleton);
                }

                return _singleton;
            }
        }

        private static ICardController _singleton = null;

        private ICardService _cardService;

        private CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        public async Task<string> GetAll(HttpRequest httpRequest)
        {
            IEnumerable<CardEntity> cards = null;

            try
            {
                cards = await _cardService.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(cards);
        }

        public async Task<string> GetById(HttpRequest httpRequest)
        {
            int id = Convert.ToInt32(httpRequest.Target.Substring(7));

            CardEntity card = null;

            try
            {
                card = await _cardService.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(card);
        }

        public async Task<string> Insert(HttpRequest httpRequest)
        {
            CardEntity card = Newtonsoft.Json.JsonConvert.DeserializeObject<CardEntity>(httpRequest.Body.Trim());

            int rowsAffected = 0;

            try
            {
                rowsAffected = await _cardService.Insert(card);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(new { rowsAffected = rowsAffected });
        }

        public async Task<string> Update(HttpRequest httpRequest)
        {
            CardEntity card = Newtonsoft.Json.JsonConvert.DeserializeObject<CardEntity>(httpRequest.Body.Trim());

            int rowsAffected = 0;

            try
            {
                rowsAffected = await _cardService.Update(card);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(new { rowsAffected = rowsAffected });
        }

        public async Task<string> DeleteById(HttpRequest httpRequest)
        {
            int id = Convert.ToInt32(httpRequest.Target.Substring(7));

            int rowsAffected = 0;

            try
            {
                rowsAffected = await _cardService.DeleteById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(new { rowsAffected = rowsAffected });
        }

    }

}
