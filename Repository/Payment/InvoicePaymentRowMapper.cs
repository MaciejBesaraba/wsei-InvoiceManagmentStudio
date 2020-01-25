using Npgsql;

namespace Repository.Payment
{
    public class InvoicePaymentRowMapper : AbstractRowMapper<InvoicePaymentEntity>
    {
        public const string TableName = "invoice_payment";
        
        private const int IdColumn = 0;
        private const int TypeColumn = 1;
        private const int DateColumn = 2;
        private const int TimeZoneColumn = 3;
        private const int AmountColumn = 4;
        
        private const string IdColumnName = "id";
        private const string TypeColumnName = "type";
        private const string DateColumnName = "date";
        private const string TimeZoneColumnName = "time_zone";
        private const string AmountColumnName = "amount";

        public override NpgsqlCommand ToRow(NpgsqlCommand command, InvoicePaymentEntity entity)
        {
            command.Parameters.AddWithValue(TypeColumnName, entity.Type);
            command.Parameters.AddWithValue(DateColumnName, entity.Date);
            command.Parameters.AddWithValue(TimeZoneColumnName, entity.TimeZone);
            command.Parameters.AddWithValue(AmountColumnName, entity.Amount);
            command.Prepare();

            return command;
        }

        protected override InvoicePaymentEntity FromRow(NpgsqlDataReader resultSet)
        {
            return new InvoicePaymentEntity(
                (ulong)resultSet.GetInt64(IdColumn),
                resultSet.GetString(TypeColumn),
                resultSet.GetDateTime(DateColumn),
                resultSet.GetString(TimeZoneColumn),
                resultSet.GetDecimal(AmountColumn)
            );
        }
    }
}
