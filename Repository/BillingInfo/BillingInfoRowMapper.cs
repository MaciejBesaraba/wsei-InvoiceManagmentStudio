using Npgsql;

namespace Repository.BillingInfo
{
    public class BillingInfoRowMapper : AbstractRowMapper<BillingInfoEntity>
    {
        public const string TableName = "billing_info";

        private const int IdColumn = 0;
        private const int CompanyNameColumn = 1;
        private const int ZipCodeColumn = 2;
        private const int AddressColumn = 3;
        
        private const string IdColumnName = "id";
        private const string CompanyNameColumnName = "company_name";
        private const string ZipCodeColumnName = "zip_code";
        private const string AddressColumnName = "address_id";

        protected override BillingInfoEntity FromRow(NpgsqlDataReader resultSet)
        {
            return new BillingInfoEntity(
                (ulong) resultSet.GetInt64(IdColumn),
                resultSet.GetString(CompanyNameColumn),
                resultSet.GetString(ZipCodeColumn),
                (ulong) resultSet.GetInt64(AddressColumn)
            );
        }

        public override NpgsqlCommand ToRow(NpgsqlCommand command, BillingInfoEntity entity)
        {
            command.Parameters.AddWithValue(CompanyNameColumnName, entity.CompanyName);
            command.Parameters.AddWithValue(ZipCodeColumnName, entity.ZipCode);
            command.Parameters.AddWithValue(AddressColumnName, entity.BillingAddressRef);
            command.Prepare();

            return command;
        }
    }
}