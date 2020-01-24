using System.Collections.Generic;
using Npgsql;

namespace Repository.ContactInfo.Command
{
    public class ContactInfoFindAllCommand
    {
        private const string Sql = "SELECT * FROM contact_info;";
        
        private readonly ContactInfoRowMapper _rowMapper;
        private readonly DataSourceConfig _dataSource;
        
        public ContactInfoFindAllCommand(DataSourceConfig dataSource)
        {
            _rowMapper = new ContactInfoRowMapper();
            _dataSource = dataSource;
        }
        
        public List<ContactInfoEntity> Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            var resultSet = command.ExecuteReader();

            return _rowMapper.FromResultSet(resultSet);
        }
    }
}
