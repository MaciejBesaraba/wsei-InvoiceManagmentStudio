using System.Collections.Generic;
using System.Collections.ObjectModel;
using Npgsql;

namespace Repository.Invoice.Command
{
    public class InvoiceFindAllItemsCommand
    {
        private const string Sql = "SELECT item_id FROM invoice_items WHERE invoice_id = @id";

        private readonly IDataSourceConfig _dataSource;
        private readonly ulong _invoiceId;

        public InvoiceFindAllItemsCommand(IDataSourceConfig dataSource, ulong invoiceId)
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
