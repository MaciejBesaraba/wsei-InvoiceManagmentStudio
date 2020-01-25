using System.Collections.Generic;
using System.Linq;
using Npgsql;

namespace Repository.Address.Command
{
    public class AddressFindByIdCommand
    {
        private const string Sql = "SELECT * FROM address WHERE id = @Id;";

        private readonly AddressRowMapper _rowMapper;
        private readonly IDataSourceConfig _dataSource;
        private readonly ulong _queryParamId;
        
        public AddressFindByIdCommand(IDataSourceConfig dataSource, ulong id)
        {
            _rowMapper = new AddressRowMapper();
            _dataSource = dataSource;
            _queryParamId = id;
        }

        public AddressEntity Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            command.Parameters.AddWithValue("Id", _queryParamId);
            command.Prepare();
            
            var resultSet = command.ExecuteReader();

            return _rowMapper.FromResultSet(resultSet).FirstOrDefault();
        }
    }
}