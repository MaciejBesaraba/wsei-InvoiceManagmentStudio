using Npgsql;

namespace Repository.Payment.Command
{
    public class InvoicePaymentDeleteCommand
    {
        private const string Sql = "DELETE FROM invoice_payment WHERE id = @Id;";
        
        private readonly InvoicePaymentRowMapper _rowMapper;
        private readonly IDataSourceConfig _dataSource;
        private readonly ulong _id;
        
        public InvoicePaymentDeleteCommand(IDataSourceConfig dataSource, ulong id)
        {
            _rowMapper = new InvoicePaymentRowMapper();
            _dataSource = dataSource;
            _id = id;
        }

        // TODO ArBy returning id
        public bool Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            command.Parameters.AddWithValue("Id", (long)_id);
            var result = command.ExecuteNonQuery() > 0;
            _dataSource.CloseDbConnection();

            return result;
        }
    }
}
