using Npgsql;

namespace Repository.BillingInfo.Command
{
    public class BillingInfoDeleteCommand
    {
        private const string Sql = "DELETE FROM billing_info WHERE id = @Id;";
        
        private readonly BillingInfoRowMapper _rowMapper;
        private readonly IDataSourceConfig _dataSource;
        private readonly ulong _id;
        
        public BillingInfoDeleteCommand(IDataSourceConfig dataSource, ulong id)
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
            var result =  command.ExecuteNonQuery() > 0;
            _dataSource.CloseDbConnection();

            return result;
        }
    }
}
