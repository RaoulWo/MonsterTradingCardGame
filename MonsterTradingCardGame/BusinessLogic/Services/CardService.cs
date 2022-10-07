using BusinessObjects.Entities;
using BusinessObjects.Interfaces.Facades;
using BusinessObjects.Interfaces.Services;
using DataAccess.Facades;

namespace BusinessLogic.Services
{

    public class CardService : ICardService
    {

        public static ICardService Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new CardService(CardFacade.Singleton);
                }

                return _singleton;
            }
        }

        private static ICardService _singleton = null;

        private ICardFacade _cardFacade;

        private CardService(ICardFacade cardFacade)
        {
            _cardFacade = cardFacade;
        }

        public async Task<IEnumerable<CardEntity>> GetAll()
        {
            try
            {
                return await _cardFacade.GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<CardEntity> GetById(int id)
        {
            try
            {
                return await _cardFacade.GetById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Insert(CardEntity card)
        {
            try
            {
                return await _cardFacade.Insert(card);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Update(CardEntity card)
        {
            try
            {
                return await _cardFacade.Update(card);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> DeleteById(int id)
        {
            try
            {
                return await _cardFacade.DeleteById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }

}
