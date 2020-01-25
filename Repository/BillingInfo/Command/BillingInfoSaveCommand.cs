using Npgsql;

namespace Repository.BillingInfo.Command
{
    public class BillingInfoSaveCommand
    {
        private const string Sql = "INSERT INTO billing_info(company_name, zip_code, address_id) VALUES (@company_name, @zip_code, @address_id) RETURNING id;";

        private readonly BillingInfoRowMapper _rowMapper;
        private readonly IDataSourceConfig _dataSource;
        private readonly BillingInfoEntity _billingInfo;
        
        public BillingInfoSaveCommand(IDataSourceConfig dataSource, BillingInfoEntity billingInfo)
        {
            _rowMapper = new BillingInfoRowMapper();
            _dataSource = dataSource;
            _billingInfo = billingInfo;
        }

        public BillingInfoEntity Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            command = _rowMapper.ToRow(command, _billingInfo);

            _billingInfo.Id = (ulong) command.ExecuteScalar();

            return _billingInfo;
        }
    }
}