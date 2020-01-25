using Core.Domain.Invoice;

namespace Core.Application.Invoice
{

    public interface IInvoiceRepository : ICrudRepository<ulong, IInvoiceDefinition>
    {
        
    }

}
