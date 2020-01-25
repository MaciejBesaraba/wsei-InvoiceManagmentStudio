using System.Collections.Generic;
using Npgsql;
using Repository.Entity.Supplier;

namespace Repository.Entity.Supplier.Command
{
    public class SupplierFindAllCommand
    {
        private const string Sql = "SELECT * FROM supplier;";

        private readonly AbstractRowMapper<SupplierEntity> _rowMapper;
        private readonly IDataSourceConfig _dataSource;

        public SupplierFindAllCommand(IDataSourceConfig dataSource)
        {
            _rowMapper = new SupplierRowMapper();
            _dataSource = dataSource;
        }

        public List<SupplierEntity> Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            var resultSet = command.ExecuteReader();

            return _rowMapper.FromResultSet(resultSet);
        }
    }
}