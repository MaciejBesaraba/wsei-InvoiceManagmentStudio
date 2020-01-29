using Npgsql;

namespace Repository.Entity.Supplier.Command
{
    public class SupplierSaveCommand
    {
        private const string Sql = "INSERT INTO supplier(billing_info_id, contact_info_id) VALUES (@billing_info_id, @contact_info_id) RETURNING id;";

        private readonly SupplierRowMapper _rowMapper;
        private readonly IDataSourceConfig _dataSource;
        private readonly SupplierEntity _supplier;
        
        public SupplierSaveCommand(IDataSourceConfig dataSource, SupplierEntity supplier)
        {
            _rowMapper = new SupplierRowMapper();
            _dataSource = dataSource;
            _supplier = supplier;
        }

        public SupplierEntity Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            command = _rowMapper.ToRow(command, _supplier);
            _supplier.Id = (ulong) command.ExecuteScalar();
            _dataSource.CloseDbConnection();

            return _supplier;
        }
    }
}