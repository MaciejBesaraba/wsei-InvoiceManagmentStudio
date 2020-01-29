using System.Linq;
using Npgsql;

namespace Repository.Item.Command
{
    public class InvoiceItemFindByIdCommand
    {
        private const string Sql = "SELECT * FROM invoice_item WHERE id = @Id;";

        private readonly InvoiceItemRowMapper _rowMapper;
        private readonly IDataSourceConfig _dataSource;
        private readonly ulong _queryParamId;
        
        public InvoiceItemFindByIdCommand(IDataSourceConfig dataSource, ulong id)
        {
            _rowMapper = new InvoiceItemRowMapper();
            _dataSource = dataSource;
            _queryParamId = id;
        }

        public InvoiceItemEntity Execute()
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