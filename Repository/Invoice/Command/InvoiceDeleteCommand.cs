using Npgsql;

namespace Repository.Invoice.Command
{
    public class InvoiceDeleteCommand
    {
        private const string Sql = "DELETE FROM invoice WHERE id = @Id;";
        
        private readonly InvoiceRowMapper _rowMapper;
        private readonly IDataSourceConfig _dataSource;
        private readonly ulong _id;
        
        public InvoiceDeleteCommand(IDataSourceConfig dataSource, ulong id)
        {
            _rowMapper = new InvoiceRowMapper();
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
