using System.Linq;
using Npgsql;

namespace Repository.Item.Command
{
    public class InvoiceItemFindByIdCommand
    {
        private const string Sql = "SELECT * FROM invoice_item WHERE id = @Id;";

        private readonly InvoiceItemRowMapper _rowMapper;
        private readonly DataSourceConfig _dataSource;
        private readonly ulong _queryParamId;
        
        public InvoiceItemFindByIdCommand(DataSourceConfig dataSource, ulong id)
        {
            _rowMapper = new InvoiceItemRowMapper();
            _dataSource = dataSource;
            _queryParamId = id;
        }

        public InvoiceItemEntity Execute()
        {
            var command = new NpgsqlCommand(Sql, _dataSource.DbConnection);
            command.Parameters.AddWithValue("Id", _queryParamId);
            command.Prepare();
            
            var resultSet = command.ExecuteReader();

            return _rowMapper.FromResultSet(resultSet).FirstOrDefault();
        }
    }
}