using System.Collections.Generic;
using Npgsql;

namespace Repository.Invoice.Command
{
    public class InvoiceFindAllItemsCommand
    {
        private const string Sql = "SELECT item_id FROM invoice_items WHERE invoice_id = @id";

        private readonly IDataSourceConfig _dataSource;

        public InvoiceFindAllItemsCommand(IDataSourceConfig dataSource)
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
