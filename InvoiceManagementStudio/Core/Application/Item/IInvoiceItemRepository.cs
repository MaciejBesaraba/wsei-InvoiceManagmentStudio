using InvoiceManagementStudio.Core.Domain;
using InvoiceManagementStudio.Core.Domain.Item;

namespace InvoiceManagementStudio.Core.Application.Item
{

    public interface IInvoiceItemRepository : ICrudRepository<ulong, IInvoiceItemDefinition>
    {
        
    }

}
