using BusinessObjects.Entities;
using BusinessObjects.Interfaces;
using BusinessObjects.Interfaces.Facades;
using BusinessObjects.Interfaces.Repositories;
using DataAccess.Repositories;
using Npgsql;

namespace DataAccess.Facades
{
    public class CardFacade : ICardFacade
    {
        public static CardFacade Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new CardFacade(CardRepository.Singleton, UnitOfWork.Singleton);
                }

                return _singleton;
            }
        }

        private static CardFacade _singleton = null;

        private ICardRepository _cardRepository;
        private IUnitOfWork _unitOfWork;

        private CardFacade(ICardRepository cardRepository, IUnitOfWork unitOfWork)
        {
            _cardRepository = cardRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CardEntity>> GetAll()
        {
            string sqlStatement = "SELECT * FROM card";
            IEnumerable<CardEntity> cards = null;

            try
            {
                cards = await _cardRepository.GetAll(sqlStatement);
            }
            catch (Exception e)
            {
                throw e;
            }

            return cards;
        }

        public async Task<CardEntity> GetById(int id)
        {
            string sqlStatement = "SELECT * FROM card WHERE Id = @Id";
            CardEntity card = null;

            try
            {
                card = await _cardRepository.GetById(id, sqlStatement);
            }
            catch (Exception e)
            {
                throw e;
            }

            return card;
        }

        public async Task<int> Insert(CardEntity card)
        {
            string sqlStatement = "INSERT INTO card (Name, Damage, CardType, ElementType) VALUES (@Name, @Damage, @CardType, @ElementType)";
            int rowsAffected = 0;

            try
            {
                NpgsqlTransaction transaction = _unitOfWork.BeginTransaction();
                rowsAffected = await _cardRepository.Insert(card, sqlStatement, transaction);
                _unitOfWork.CommitTransaction();
            }
            catch (Exception e)
            {
                throw e;
            }

            return rowsAffected;
        }

        public async Task<int> Update(CardEntity card)
        {
            string sqlStatement = "UPDATE card SET Name = @Name, Damage = @Damage, CardType = @CardType, ElementType = @ElementType WHERE Id = @Id";
            int rowsAffected = 0;

            try
            {
                NpgsqlTransaction transaction = _unitOfWork.BeginTransaction();
                rowsAffected = await _cardRepository.Update(card, sqlStatement, transaction);
                _unitOfWork.CommitTransaction();
            }
            catch (Exception e)
            {
                throw e;
            }

            return rowsAffected;
        }

        public async Task<int> DeleteById(int id)
        {
            string sqlStatement = "DELETE FROM card WHERE Id = @Id";
            int rowsAffected = 0;

            try
            {
                NpgsqlTransaction transaction = _unitOfWork.BeginTransaction();
                rowsAffected = await _cardRepository.DeleteById(id, sqlStatement, transaction);
                _unitOfWork.CommitTransaction();
            }
            catch (Exception e)
            {
                throw e;
            }

            return rowsAffected;
        }
    }
}
