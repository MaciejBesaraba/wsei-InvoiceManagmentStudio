using Npgsql;

namespace Repository.BillingInfo.Command
{
    public class BillingInfoDeleteCommand
    {
        private const string Sql = "DELETE FROM billing_info WHERE id = @Id;";
        
        private readonly BillingInfoRowMapper _rowMapper;
        private readonly DataSourceConfig _dataSource;
        private readonly ulong _id;
        
        public BillingInfoDeleteCommand(DataSourceConfig dataSource, ulong id)
        {
            _rowMapper = new BillingInfoRowMapper();
            _dataSource = dataSource;
            _id = id;
        }

        // TODO ArBy returning id
        public bool Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            command.Parameters.AddWithValue("Id", _id);
            return command.ExecuteNonQuery() > 0;
        }
    }
}
