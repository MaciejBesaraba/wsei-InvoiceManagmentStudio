using Core.Domain.Item;

namespace Core.Application.Item
{

    public interface IInvoiceItemService  : ICrudService<ulong, IInvoiceItemDefinition>
    {
        
    }

}
