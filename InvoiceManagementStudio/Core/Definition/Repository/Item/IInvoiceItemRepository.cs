using InvoiceManagementStudio.Core.Definition.Invoice;


namespace InvoiceManagementStudio.Core.Definition.Repository.Item
{

    public interface IInvoiceItemRepository : ICrudRepository<ulong, IInvoiceItemDefinition>
    {
        
    }

}
