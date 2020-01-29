using System;
using Npgsql;

namespace Repository.Address
{
    public class AddressRowMapper : AbstractRowMapper<AddressEntity>
    {
        public const string TableName = "address";

        private const int IdColumn = 0;
        private const int CountryColumn = 1;
        private const int CityColumn = 2;
        private const int StreetColumn = 3;
        private const int StateColumn = 4;
        private const int BuildingNumber = 5;
        private const int FlatNumberColumn = 6;

        private const string IdColumnName = "id";
        private const string CountryColumnName = "country";
        private const string CityColumnName = "city";
        private const string StreetColumnName = "street";
        private const string StateColumnName = "state";
        private const string BuildingNumberColumnName = "building_number";
        private const string FlatNumberColumnName = "flat_number";

        protected override AddressEntity FromRow(NpgsqlDataReader resultSet)
        {
            Console.WriteLine(resultSet);
            var id = (ulong) resultSet.GetInt64(IdColumn);
            var country = resultSet.GetString(CountryColumn);
            var city = resultSet.GetString(CityColumn);
            var street = resultSet.GetString(StreetColumn);
            var state = resultSet.GetString(StateColumn);
            var building = resultSet.GetString(BuildingNumber);
            var flat = resultSet.GetString(FlatNumberColumn);
            return new AddressEntity(id, country, city, street, state, building, flat);
//            return new AddressEntity(
//                (ulong) resultSet.GetInt64(IdColumn),
//                resultSet.GetString(CountryColumn),
//                resultSet.GetString(CityColumn),
//                resultSet.GetString(StreetColumn),
//                resultSet.GetString(StateColumn),
//                resultSet.GetString(BuildingNumber),
//                resultSet.GetString(FlatNumberColumn)
//            );
        }

        public override NpgsqlCommand ToRow(NpgsqlCommand command, AddressEntity address)
        {
            command.Parameters.AddWithValue(CountryColumnName, address.Country);
            command.Parameters.AddWithValue(CityColumnName, address.City);
            command.Parameters.AddWithValue(StreetColumnName, address.Street);
            command.Parameters.AddWithValue(StateColumnName, address.State);
            command.Parameters.AddWithValue(BuildingNumberColumnName, address.BuildingNumber);
            command.Parameters.AddWithValue(FlatNumberColumnName, address.FlatNumber);
            command.Prepare();

            return command;
        }
    }
}