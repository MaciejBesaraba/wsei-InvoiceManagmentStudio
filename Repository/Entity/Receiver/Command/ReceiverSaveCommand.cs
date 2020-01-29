using Npgsql;

namespace Repository.Entity.Receiver.Command
{
    public class ReceiverSaveCommand
    {
        private const string Sql = "INSERT INTO receiver(billing_info_id, contact_info_id) VALUES (@billing_info_id, @contact_info_id) RETURNING id;";

        private readonly ReceiverRowMapper _rowMapper;
        private readonly IDataSourceConfig _dataSource;
        private readonly ReceiverEntity _receiver;
        
        public ReceiverSaveCommand(IDataSourceConfig dataSource, ReceiverEntity receiver)
        {
            _rowMapper = new ReceiverRowMapper();
            _dataSource = dataSource;
            _receiver = receiver;
        }

        public ReceiverEntity Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            command = _rowMapper.ToRow(command, _receiver);
            _receiver.Id = (ulong) command.ExecuteScalar();
            _dataSource.CloseDbConnection();

            return _receiver;
        }
    }
}