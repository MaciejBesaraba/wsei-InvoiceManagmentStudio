using InvoiceManagementStudio.Core.Domain;
using InvoiceManagementStudio.Core.Domain.Item;

namespace InvoiceManagementStudio.Core.Application.Item
{

    public interface IInvoiceItemService  : ICrudService<ulong, IInvoiceItemDefinition>
    {
        
    }

}
