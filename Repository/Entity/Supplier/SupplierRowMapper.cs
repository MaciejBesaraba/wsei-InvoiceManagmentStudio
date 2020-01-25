using Npgsql;

namespace Repository.Entity.Supplier
{
    public class SupplierRowMapper : AbstractRowMapper<SupplierEntity>
    {
        public const string TableName = "supplier";

        private const int IdColumn = 0;
        private const int BillingInfoColumn = 1;
        private const int ContactInfoColumn = 2;
        
        private const string IdColumnName = "id";
        private const string BillingInfoColumnName = "billing_info_id";
        private const string ContactInfoColumnName = "contact_info_id";
        
        public override NpgsqlCommand ToRow(NpgsqlCommand command, SupplierEntity entity)
        {
            command.Parameters.AddWithValue(BillingInfoColumnName, entity.BillingInfoRef);
            command.Parameters.AddWithValue(ContactInfoColumnName, entity.ContactInfoRef);
            command.Prepare();

            return command;
        }

        protected override SupplierEntity FromRow(NpgsqlDataReader resultSet)
        {
            return new SupplierEntity(
                (ulong) resultSet.GetInt64(IdColumn),
                (ulong) resultSet.GetInt64(BillingInfoColumn),
                (ulong) resultSet.GetInt64(ContactInfoColumn)
            );
        }
    }
}