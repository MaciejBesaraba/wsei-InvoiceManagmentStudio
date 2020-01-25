using Npgsql;

namespace Repository.Item.Command
{
    public class InvoiceItemDeleteCommand
    {
        private const string Sql = "DELETE FROM invoice_item WHERE id = @Id;";
        
        private readonly InvoiceItemRowMapper _rowMapper;
        private readonly DataSourceConfig _dataSource;
        private readonly ulong _id;
        
        public InvoiceItemDeleteCommand(DataSourceConfig dataSource, ulong id)
        {
            _rowMapper = new InvoiceItemRowMapper();
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
