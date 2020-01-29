using System.Linq;
using Npgsql;

namespace Repository.ContactInfo.Command
{
    public class ContactInfoFindByIdCommand
    {
        private const string Sql = "SELECT * FROM contact_info WHERE id = @Id;";
        
        private readonly ContactInfoRowMapper _rowMapper;
        private readonly IDataSourceConfig _dataSource;
        private readonly ulong _queryParamId;
        
        public ContactInfoFindByIdCommand(IDataSourceConfig dataSource, ulong id)
        {
            _rowMapper = new ContactInfoRowMapper();
            _dataSource = dataSource;
            _queryParamId = id;
        }
        
        public ContactInfoEntity Execute()
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