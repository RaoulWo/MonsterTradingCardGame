using BusinessObjects.Entities;
using BusinessObjects.Enums;
using BusinessObjects.Interfaces;
using BusinessObjects.Interfaces.Repositories;
using Npgsql;

namespace DataAccess.Repositories
{
    public class CardRepository : Repository<CardEntity>, ICardRepository
    {
        public static CardRepository Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new CardRepository(DataAccess.UnitOfWork.Singleton);
                }

                return _singleton;
            }
        }

        private static CardRepository _singleton = null;

        private CardRepository(IUnitOfWork unitofWork)
            : base(unitofWork)
        { }

        /// <summary>
        /// Maps data for populating all statement.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override List<CardEntity> Maps(NpgsqlDataReader reader)
        {
            List<CardEntity> cards = new List<CardEntity>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CardEntity card = new CardEntity();

                    card.Id = Convert.ToInt32(reader["Id"].ToString());
                    card.Name = reader["Name"].ToString();
                    card.Damage = Convert.ToInt32(reader["Damage"].ToString());

                    CardType cardType;
                    Enum.TryParse(reader["CardType"].ToString(), out cardType);
                    card.CardType = cardType;

                    ElementType elementType;
                    Enum.TryParse(reader["ElementType"].ToString(), out elementType);
                    card.ElementType = elementType;

                    cards.Add(card);
                }
            }

            return cards;
        }

        /// <summary>
        /// Maps data for populating by key statement.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override CardEntity Map(NpgsqlDataReader reader)
        {
            CardEntity card = new CardEntity();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    card.Id = Convert.ToInt32(reader["Id"].ToString());
                    card.Name = reader["Name"].ToString();
                    card.Damage = Convert.ToInt32(reader["Damage"].ToString());

                    CardType cardType;
                    Enum.TryParse(reader["CardType"].ToString(), out cardType);
                    card.CardType = cardType;

                    ElementType elementType;
                    Enum.TryParse(reader["ElementType"].ToString(), out elementType);
                    card.ElementType = elementType;
                }
            }

            return card;
        }

        /// <summary>
        /// Passes the parameters for populating by key statement.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cmd"></param>
        protected override void GetByIdCommandParameters(int id, NpgsqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Id", id);
        }

        /// <summary>
        /// Passes the parameters for insert statement.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void InsertCommandParameters(CardEntity entity, NpgsqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Name", entity.Name);
            cmd.Parameters.AddWithValue("@Damage", entity.Damage);
            cmd.Parameters.AddWithValue("@CardType", entity.CardType.ToString());
            cmd.Parameters.AddWithValue("@ElementType", entity.ElementType.ToString());
        }

        /// <summary>
        /// Passes the parameters for update statement.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void UpdateCommandParameters(CardEntity entity, NpgsqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Id", entity.Id);
            cmd.Parameters.AddWithValue("@Name", entity.Name);
            cmd.Parameters.AddWithValue("@Damage", entity.Damage);
            cmd.Parameters.AddWithValue("@CardType", entity.CardType.ToString());
            cmd.Parameters.AddWithValue("@ElementType", entity.ElementType.ToString());
        }

        /// <summary>
        /// Passes the parameters for delete statement.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cmd"></param>
        protected override void DeleteByIdCommandParameters(int id, NpgsqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Id", id);
        }
    }
}
