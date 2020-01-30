using Core.Domain.Item;

namespace Core.Application.Item
{

    public interface IInvoiceItemRepository : ICrudRepository<ulong, InvoiceItem>
    {
        
    }

}
