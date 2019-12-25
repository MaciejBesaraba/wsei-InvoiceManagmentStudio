using InvoiceManagementStudio.Core.Domain;
using InvoiceManagementStudio.Core.Domain.Invoice;

namespace InvoiceManagementStudio.Core.Application.Invoice
{

    public interface IInvoiceRepository : ICrudRepository<ulong, IInvoiceDefinition>
    {
        
    }

}
