using System.Linq;
using Npgsql;

namespace Repository.BillingInfo.Command
{
    public class BillingInfoFIndByIdCommand
    {
        private const string Sql = "SELECT * FROM billing_info WHERE id = @Id;";

        private readonly BillingInfoRowMapper _rowMapper;
        private readonly IDataSourceConfig _dataSource;
        private readonly ulong _queryParamId;

        public BillingInfoFIndByIdCommand(IDataSourceConfig dataSource, ulong id)
        {
            _rowMapper = new BillingInfoRowMapper();
            _dataSource = dataSource;
            _queryParamId = id;
        }

        public BillingInfoEntity Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            command.Parameters.AddWithValue("Id", _queryParamId);
            command.Prepare();
            
            var resultSet = command.ExecuteReader();

            return _rowMapper.FromResultSet(resultSet).FirstOrDefault();
        }
    }
}