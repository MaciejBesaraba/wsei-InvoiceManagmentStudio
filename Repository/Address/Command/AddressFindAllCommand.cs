using System.Collections.Generic;
using Npgsql;

namespace Repository.Address.Command
{
    public class AddressFindAllCommand
    {
        private const string Sql = "SELECT * FROM address;";

        private readonly AddressRowMapper _rowMapper;
        private readonly DataSourceConfig _dataSource;

        public AddressFindAllCommand(DataSourceConfig dataSource)
        {
            _rowMapper = new AddressRowMapper();
            _dataSource = dataSource;
        }

        public List<AddressEntity> Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            var resultSet = command.ExecuteReader();

            return _rowMapper.FromResultSet(resultSet);
        }
    }
}