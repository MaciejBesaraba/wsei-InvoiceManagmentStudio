using Npgsql;

namespace Repository.ContactInfo.Command
{
    public class ContactInfoDeleteCommand
    {
        private const string Sql = "DELETE FROM contact_info WHERE id = @Id;";

        private readonly ContactInfoRowMapper _rowMapper;
        private readonly IDataSourceConfig _dataSource;
        private readonly ulong _id;

        public ContactInfoDeleteCommand(IDataSourceConfig dataSource, ulong id)
        {
            _rowMapper = new ContactInfoRowMapper();
            _dataSource = dataSource;
            _id = id;
        }

        // TODO ArBy returning id
        public bool Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            command.Parameters.AddWithValue("Id", _id);
            var result = command.ExecuteNonQuery() > 0;
            _dataSource.CloseDbConnection();

            return result;
        }
    }
}
