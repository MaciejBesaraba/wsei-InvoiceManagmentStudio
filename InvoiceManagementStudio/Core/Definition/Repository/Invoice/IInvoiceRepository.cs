using InvoiceManagementStudio.Core.Definition.Invoice;


namespace InvoiceManagementStudio.Core.Definition.Repository.Invoice
{

    public interface IInvoiceRepository : ICrudRepository<ulong, IInvoiceDefinition>
    {
        
    }

}
