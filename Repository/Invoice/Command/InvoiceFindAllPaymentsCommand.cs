using System.Collections.Generic;
using Npgsql;

namespace Repository.Invoice.Command
{
    public class InvoiceFindAllPaymentsCommand
    {
        private const string Sql = "SELECT payment_id FROM invoice_payments WHERE invoice_id = @id";
        
        private readonly IDataSourceConfig _dataSource;

        public InvoiceFindAllPaymentsCommand(IDataSourceConfig dataSource)
        {
            _dataSource = dataSource;
        }

        
        public List<ulong> Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            var resultSet = command.ExecuteReader();
            
            var ids = new List<ulong>();
            while (resultSet.Read())
            {
                ids.Add((ulong)resultSet.GetInt64(0));
            }
            return ids;
        }
    }
}
