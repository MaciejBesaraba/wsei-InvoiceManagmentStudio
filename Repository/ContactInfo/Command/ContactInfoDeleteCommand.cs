using Npgsql;

namespace Repository.ContactInfo.Command
{
    public class ContactInfoDeleteCommand
    {
        private const string Sql = "DELETE FROM contact_info WHERE id = @Id;";

        private readonly ContactInfoRowMapper _rowMapper;
        private readonly DataSourceConfig _dataSource;
        private readonly ulong _id;

        public ContactInfoDeleteCommand(DataSourceConfig dataSource, ulong id)
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
            return command.ExecuteNonQuery() > 0;
        }
    }
}
