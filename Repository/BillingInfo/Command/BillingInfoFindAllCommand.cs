using System.Collections.Generic;
using Npgsql;

namespace Repository.BillingInfo.Command
{
    public class BillingInfoFindAllCommand
    {
        private const string Sql = "SELECT * FROM billing_info;";

        private readonly AbstractRowMapper<BillingInfoEntity> _rowMapper;
        private readonly IDataSourceConfig _dataSource;

        public BillingInfoFindAllCommand(IDataSourceConfig dataSource)
        {
            _rowMapper = new BillingInfoRowMapper();
            _dataSource = dataSource;
        }

        public List<BillingInfoEntity> Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            var resultSet = command.ExecuteReader();
            var result = _rowMapper.FromResultSet(resultSet);
            _dataSource.CloseDbConnection();

            return result;
        }
    }
}