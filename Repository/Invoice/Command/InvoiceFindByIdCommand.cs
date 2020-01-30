using System.Linq;
using Npgsql;

namespace Repository.Invoice.Command
{
    public class InvoiceFIndByIdCommand
    {
        private const string Sql = "SELECT * FROM invoice WHERE id = @Id;";

        private readonly InvoiceRowMapper _rowMapper;
        private readonly IDataSourceConfig _dataSource;
        private readonly ulong _queryParamId;

        public InvoiceFIndByIdCommand(IDataSourceConfig dataSource, ulong id)
        {
            _rowMapper = new InvoiceRowMapper();
            _dataSource = dataSource;
            _queryParamId = id;
        }

        public InvoiceEntity Execute()
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