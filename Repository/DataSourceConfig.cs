using Core.Domain.Exception;
using Npgsql;

namespace Repository
{
    public class DataSourceConfig : IDataSourceConfig
    {
        private readonly string _dataSource; // = @"127.0.0.1";
        private readonly string _username;   // = "postgres";
        private readonly string _password;   // = "postgres";
        private readonly string _database;   // = "ivms";
        private readonly NpgsqlConnection _dbConnection;
        
        private bool _isDbConnectionOpen;

        public DataSourceConfig(string dataSource, string database, string username, string password)
        {
            _dataSource = dataSource;
            _database = database;
            _username = username;
            _password = password;
            _dbConnection = new NpgsqlConnection(ConnectionString);
        }
        
        private string ConnectionString => $"Host={_dataSource};" +
                                           $"Username={_username};" +
                                           $"Password={_password};" +
                                           $"Database={_database}";
        
        public NpgsqlConnection DbConnection
        {
            get
            {
                if (_isDbConnectionOpen)
                {
                    throw new DbAccessException("Attempt to work on open database connection");
                }
                _isDbConnectionOpen = true;
                _dbConnection.Open();
                return _dbConnection;
            }
        }

        public void CloseDbConnection()
        {
            _dbConnection.Close();
            _isDbConnectionOpen = false;
        }
    }
}