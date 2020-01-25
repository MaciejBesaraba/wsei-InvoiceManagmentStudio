using Npgsql;

namespace Repository.Entity.Receiver.Command
{
    public class ReceiverDeleteCommand
    {
        private const string Sql = "DELETE FROM receivier WHERE id = @Id;";
        
        private readonly ReceiverRowMapper _rowMapper;
        private readonly DataSourceConfig _dataSource;
        private readonly ulong _id;
        
        public ReceiverDeleteCommand(DataSourceConfig dataSource, ulong id)
        {
            _rowMapper = new ReceiverRowMapper();
            _dataSource = dataSource;
            _id = id;
        }

        // TODO ArBy returning id
        public bool Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            command.Parameters.AddWithValue("Id", _id);
            return command.ExecuteNonQuery() > 0;
        }
    }
}
