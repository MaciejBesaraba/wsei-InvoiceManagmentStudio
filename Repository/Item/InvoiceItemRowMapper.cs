using Npgsql;
using Repository.Entity.Receiver;

namespace Repository.Item
{
    public class InvoiceItemRowMapper : AbstractRowMapper<InvoiceItemEntity>
    {
        public const string TableName = "invoice_item";

        private const int IdColumn = 0;
        private const int NameColumn = 1;
        private const int UnitPriceColumn = 2;
        private const int UnitTypeColumn = 3;
        private const int DiscountColumn = 4;
        private const int QuantityColumn = 5;
        
        private const string IdColumnName = "id";
        private const string NameColumnName = "name";
        private const string UnitPriceColumnName = "unit_price";
        private const string UnitTypeColumnName = "unit_type";
        private const string DiscountColumnName = "discount";
        private const string QuantityColumnName = "quantity";
        
        public override NpgsqlCommand ToRow(NpgsqlCommand command, InvoiceItemEntity entity)
        {
            command.Parameters.AddWithValue(NameColumnName, entity.Name);
            command.Parameters.AddWithValue(UnitPriceColumnName, entity.UnitPrice);
            command.Parameters.AddWithValue(UnitTypeColumnName, entity.UnitType);
            command.Parameters.AddWithValue(DiscountColumnName, entity.Discount);
            command.Parameters.AddWithValue(QuantityColumnName, entity.Quantity);
            command.Prepare();

            return command;
        }
        
        protected override InvoiceItemEntity FromRow(NpgsqlDataReader resultSet)
        {
            return new InvoiceItemEntity(
                (ulong)resultSet.GetInt64(IdColumn),
                resultSet.GetString(NameColumn),
                resultSet.GetDecimal(UnitPriceColumn),
                resultSet.GetString(UnitTypeColumn),
                resultSet.GetDecimal(DiscountColumn),
                resultSet.GetDouble(QuantityColumn)
            );
        }
    }
}
