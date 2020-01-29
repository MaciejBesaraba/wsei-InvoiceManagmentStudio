using System.Collections.Generic;
using Npgsql;

namespace Repository.Item.Command
{
    public class InvoiceItemFindAllCommand
    {
        private const string Sql = "SELECT * FROM invoice_item;";

        private readonly InvoiceItemRowMapper _rowMapper;
        private readonly IDataSourceConfig _dataSource;

        public InvoiceItemFindAllCommand(IDataSourceConfig dataSource)
        {
            _rowMapper = new InvoiceItemRowMapper();
            _dataSource = dataSource;
        }

        public List<InvoiceItemEntity> Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            var resultSet = command.ExecuteReader();
            var result = _rowMapper.FromResultSet(resultSet);
            _dataSource.CloseDbConnection();

            return result;
        }
    }
}
