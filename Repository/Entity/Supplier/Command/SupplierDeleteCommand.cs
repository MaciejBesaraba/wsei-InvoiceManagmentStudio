using Npgsql;

namespace Repository.Entity.Supplier.Command
{
    public class SupplierDeleteCommand
    {
        private const string Sql = "DELETE FROM supplier WHERE id = @Id;";
        
        private readonly SupplierRowMapper _rowMapper;
        private readonly IDataSourceConfig _dataSource;
        private readonly ulong _id;
        
        public SupplierDeleteCommand(IDataSourceConfig dataSource, ulong id)
        {
            _rowMapper = new SupplierRowMapper();
            _dataSource = dataSource;
            _id = id;
        }

        // TODO ArBy returning id
        public bool Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            command.Parameters.AddWithValue("Id", (long)_id);
            var result = command.ExecuteNonQuery() > 0;
            _dataSource.CloseDbConnection();

            return result;
        }
    }
}
