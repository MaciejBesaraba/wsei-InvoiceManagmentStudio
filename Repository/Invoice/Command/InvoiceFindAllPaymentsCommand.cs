using System.Collections.Generic;
using Npgsql;

namespace Repository.Invoice.Command
{
    public class InvoiceFindAllPaymentsCommand
    {
        private const string Sql = "SELECT payment_id FROM invoice_payments WHERE invoice_id = @id";
        
        private readonly IDataSourceConfig _dataSource;
        private readonly ulong _invoiceId;

        public InvoiceFindAllPaymentsCommand(IDataSourceConfig dataSource, ulong invoiceId)
        {
            _dataSource = dataSource;
            _invoiceId = invoiceId;
        }

        
        public List<ulong> Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            command.Parameters.AddWithValue("id", (long)_invoiceId);

            var resultSet = command.ExecuteReader();
            var ids = new List<ulong>();
            while (resultSet.Read())
            {
                ids.Add((ulong)resultSet.GetInt64(0));
            }
            _dataSource.CloseDbConnection();
            
            return ids;
        }
    }
}
