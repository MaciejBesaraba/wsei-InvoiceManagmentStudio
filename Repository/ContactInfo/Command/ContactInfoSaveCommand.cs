using Npgsql;

namespace Repository.ContactInfo.Command
{
    public class ContactInfoSaveCommand
    {
        private const string Sql = "INSERT INTO contact_info(email, phone, mobile, title, gender, name, surname) VALUES (@email, @phone, @mobile, @title, @gender, @name, @surname) RETURNING id";

        private readonly ContactInfoRowMapper _rowMapper;
        private readonly IDataSourceConfig _dataSource;
        private ContactInfoEntity _contactInfo;
        
        public ContactInfoSaveCommand(IDataSourceConfig dataSource, ContactInfoEntity contactInfo)
        {
            _rowMapper = new ContactInfoRowMapper();
            _dataSource = dataSource;
            _contactInfo = contactInfo;
        }

        public ContactInfoEntity Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            command = _rowMapper.ToRow(command, _contactInfo);
            _contactInfo.Id = (ulong) command.ExecuteScalar();
            _dataSource.CloseDbConnection();
            
            return _contactInfo;
        }
    }
}
