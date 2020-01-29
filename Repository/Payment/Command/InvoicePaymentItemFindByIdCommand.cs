using System.Linq;
using Npgsql;

namespace Repository.Payment.Command
{
    public class InvoicePaymentFindByIdCommand
    {
        private const string Sql = "SELECT * FROM invoice_payment WHERE id = @Id;";

        private readonly InvoicePaymentRowMapper _rowMapper;
        private readonly IDataSourceConfig _dataSource;
        private readonly ulong _queryParamId;
        
        public InvoicePaymentFindByIdCommand(IDataSourceConfig dataSource, ulong id)
        {
            _rowMapper = new InvoicePaymentRowMapper();
            _dataSource = dataSource;
            _queryParamId = id;
        }

        public InvoicePaymentEntity Execute()
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
