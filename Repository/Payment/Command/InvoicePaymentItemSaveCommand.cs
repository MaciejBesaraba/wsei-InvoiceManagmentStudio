using Npgsql;

namespace Repository.Payment.Command
{
    public class InvoicePaymentSaveCommand
    {
        private const string Sql = "INSERT INTO invoice_payment(type, date, time_zone, amount) VALUES (@type, @date, @time_zone, @amount) RETURNING id;";

        private readonly InvoicePaymentRowMapper _rowMapper;
        private readonly IDataSourceConfig _dataSource;
        private readonly InvoicePaymentEntity _InvoicePayment;
        
        public InvoicePaymentSaveCommand(IDataSourceConfig dataSource, InvoicePaymentEntity InvoicePayment)
        {
            _rowMapper = new InvoicePaymentRowMapper();
            _dataSource = dataSource;
            _InvoicePayment = InvoicePayment;
        }

        public InvoicePaymentEntity Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            command = _rowMapper.ToRow(command, _InvoicePayment);

            _InvoicePayment.Id = (ulong) command.ExecuteScalar();
            _dataSource.CloseDbConnection();

            return _InvoicePayment;
        }
    }
}
