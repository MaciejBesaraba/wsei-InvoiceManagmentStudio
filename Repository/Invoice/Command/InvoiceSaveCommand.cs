using Npgsql;

namespace Repository.Invoice.Command
{
    public class InvoiceSaveCommand
    {
        private const string Sql = "INSERT INTO invoice(issue_date, due_date, redemption_date, supplier_id, receiver_id) VALUES (@issue_date, @due_date, @redemption_date, @supplier_id, @receiver_id) RETURNING id;";

        private readonly InvoiceRowMapper _rowMapper;
        private readonly IDataSourceConfig _dataSource;
        private readonly InvoiceEntity _Invoice;
        
        public InvoiceSaveCommand(IDataSourceConfig dataSource, InvoiceEntity Invoice)
        {
            _rowMapper = new InvoiceRowMapper();
            _dataSource = dataSource;
            _Invoice = Invoice;
        }

        public InvoiceEntity Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            command = _rowMapper.ToRow(command, _Invoice);

            _Invoice.Id = (ulong) command.ExecuteScalar();
            _dataSource.CloseDbConnection();

            return _Invoice;
        }
    }
}