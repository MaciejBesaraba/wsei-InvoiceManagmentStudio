using Npgsql;

namespace Repository.Item.Command
{
    public class InvoiceItemSaveCommand
    {
        private const string Sql = "INSERT INTO invoice_item(name, unit_price, unit_type, discount, quantity) VALUES (@id, @name, @unit_price, @unit_type, @discount, @quantity) RETURNING id;";

        private readonly InvoiceItemRowMapper _rowMapper;
        private readonly IDataSourceConfig _dataSource;
        private readonly InvoiceItemEntity _InvoiceItem;
        
        public InvoiceItemSaveCommand(IDataSourceConfig dataSource, InvoiceItemEntity InvoiceItem)
        {
            _rowMapper = new InvoiceItemRowMapper();
            _dataSource = dataSource;
            _InvoiceItem = InvoiceItem;
        }

        public InvoiceItemEntity Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            command = _rowMapper.ToRow(command, _InvoiceItem);

            _InvoiceItem.Id = (ulong) command.ExecuteScalar();

            return _InvoiceItem;
        }
    }
}