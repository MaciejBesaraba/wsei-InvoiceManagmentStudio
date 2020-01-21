using System.Linq;
using Npgsql;

namespace Repository.Address.Command
{
    public class AddressSaveCommand
    {
        private const string Sql = "INSERT INTO address(country, city, street, state, building_number, flat_number) VALUES (@Country, @City, @Street, @State, @BuildingNumber, @FlatNumber) RETURNING id;";

        private readonly AddressRowMapper _rowMapper;
        private readonly DataSourceConfig _dataSource;
        private readonly AddressEntity _address;
        
        public AddressSaveCommand(DataSourceConfig dataSource, AddressEntity address)
        {
            _rowMapper = new AddressRowMapper();
            _dataSource = dataSource;
            _address = address;
        }

        public AddressEntity Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            command = _rowMapper.ToRow(command, _address);

            _address.Id = (ulong) command.ExecuteScalar();

            return _address;
        }
    }
}