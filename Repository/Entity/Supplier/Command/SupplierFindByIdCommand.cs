using System.Linq;
using Npgsql;

namespace Repository.Entity.Supplier.Command
{
    public class SupplierFIndByIdCommand
    {
        private const string Sql = "SELECT * FROM supplier WHERE id = @Id;";

        private readonly SupplierRowMapper _rowMapper;
        private readonly IDataSourceConfig _dataSource;
        private readonly ulong _queryParamId;

        public SupplierFIndByIdCommand(IDataSourceConfig dataSource, ulong id)
        {
            _rowMapper = new SupplierRowMapper();
            _dataSource = dataSource;
            _queryParamId = id;
        }

        public SupplierEntity Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            command.Parameters.AddWithValue("Id", (long)_queryParamId);
            command.Prepare();
            
            var resultSet = command.ExecuteReader();
            var result = _rowMapper.FromResultSet(resultSet).FirstOrDefault();
            _dataSource.CloseDbConnection();

            return result;
        }
    }
}