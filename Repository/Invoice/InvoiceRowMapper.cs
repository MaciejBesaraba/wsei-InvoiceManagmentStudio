using Npgsql;

namespace Repository.Invoice
{
    public class InvoiceRowMapper : AbstractRowMapper<InvoiceEntity>
    {
        public const string TableName = "invoice";

        private const int IdColumn = 0;
        private const int IssueDateColumn = 1;
        private const int DueDateColumn = 2;
        private const int RedemptionDateColumn = 3;
        private const int SupplierRefColumn = 4;
        private const int ReceiverRefColumn = 5;
        
        private const string IdColumnName = "id";
        private const string IssueDateColumnName = "issue_date";
        private const string DueDateColumnName = "due_date";
        private const string RedemptionDateColumnName = "redemption_date";
        private const string SupplierRefColumnName = "supplier_id";
        private const string ReceiverRefColumnName = "receiver_id";
        
        public override NpgsqlCommand ToRow(NpgsqlCommand command, InvoiceEntity entity)
        {
            command.Parameters.AddWithValue(IssueDateColumnName, entity.IssueDate);
            command.Parameters.AddWithValue(DueDateColumnName, entity.DueDate);
            command.Parameters.AddWithValue(RedemptionDateColumnName, entity.RedemptionDate);
            command.Parameters.AddWithValue(SupplierRefColumnName, entity.SupplierRef);
            command.Parameters.AddWithValue(SupplierRefColumnName, entity.ReceiverRef);
            command.Prepare();

            return command;
        }

        protected override InvoiceEntity FromRow(NpgsqlDataReader resultSet)
        {
            return new InvoiceEntity(
                (ulong)resultSet.GetInt64(IdColumn),
                resultSet.GetDateTime(DueDateColumn),
                resultSet.GetDateTime(IssueDateColumn),
                resultSet.GetDateTime(RedemptionDateColumn),
                (ulong)resultSet.GetInt64(SupplierRefColumn),
                (ulong)resultSet.GetInt64(ReceiverRefColumn)
            );
        }
    }
}
