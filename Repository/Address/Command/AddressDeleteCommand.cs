using Npgsql;

namespace Repository.Address.Command
{
    public class AddressDeleteCommand
    {
        private const string Sql = "DELETE FROM address WHERE id = @Id;";
        
        private readonly AddressRowMapper _rowMapper;
        private readonly IDataSourceConfig _dataSource;
        private readonly ulong _id;
        
        public AddressDeleteCommand(IDataSourceConfig dataSource, ulong id)
        {
            _rowMapper = new AddressRowMapper();
            _dataSource = dataSource;
            _id = id;
        }

        // TODO ArBy returning id
        public bool Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            command.Parameters.AddWithValue("Id", _id);
            var result = command.ExecuteNonQuery() > 0;
            _dataSource.CloseDbConnection();

            return result;
        }
    }
}