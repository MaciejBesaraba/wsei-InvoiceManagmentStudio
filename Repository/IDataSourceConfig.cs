using Npgsql;

namespace Repository
{
    public interface IDataSourceConfig
    {
        NpgsqlConnection DbConnection { get; }

        void CloseDbConnection();
    }
}
