using System.Collections.Generic;
using Npgsql;

namespace Repository
{
    public interface IRowMapper<T>
    {
        List<T> FromResultSet(NpgsqlDataReader resultSet);

        NpgsqlCommand ToRow(NpgsqlCommand command, T entity);

        T FromRow(NpgsqlDataReader resultSet);
    }
    
    public abstract class AbstractRowMapper<T>
    {
        protected AbstractRowMapper() { }

        public List<T> FromResultSet(NpgsqlDataReader resultSet)
        {
            var entities = new List<T>();
            while (resultSet.Read())
            {
                entities.Add(FromRow(resultSet));
            }
            return entities;
        }
        
        public abstract NpgsqlCommand ToRow(NpgsqlCommand command, T entity);

        protected abstract T FromRow(NpgsqlDataReader resultSet);
    }
}
