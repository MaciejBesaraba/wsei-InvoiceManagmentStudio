using System.Collections.Generic;
using Npgsql;

namespace Repository.Invoice.Command
{
    public class InvoiceFindAllCommand
    {
        private const string Sql = "SELECT * FROM invoice;";

        private readonly AbstractRowMapper<InvoiceEntity> _rowMapper;
        private readonly IDataSourceConfig _dataSource;

        public InvoiceFindAllCommand(IDataSourceConfig dataSource)
        {
            _rowMapper = new InvoiceRowMapper();
            _dataSource = dataSource;
        }

        public List<InvoiceEntity> Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            var resultSet = command.ExecuteReader();

            return _rowMapper.FromResultSet(resultSet);
        }
    }
}