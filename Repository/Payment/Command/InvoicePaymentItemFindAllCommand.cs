using System.Collections.Generic;
using Npgsql;

namespace Repository.Payment.Command
{
    public class InvoicePaymentFindAllCommand
    {
        private const string Sql = "SELECT * FROM invoice_payment;";

        private readonly InvoicePaymentRowMapper _rowMapper;
        private readonly IDataSourceConfig _dataSource;

        public InvoicePaymentFindAllCommand(IDataSourceConfig dataSource)
        {
            _rowMapper = new InvoicePaymentRowMapper();
            _dataSource = dataSource;
        }

        public List<InvoicePaymentEntity> Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            var resultSet = command.ExecuteReader();
            var result = _rowMapper.FromResultSet(resultSet);
            _dataSource.CloseDbConnection();

            return result;
        }
    }
}
