namespace InvoiceManagementStudio.Core.Domain.Invoice
{

    public interface IInvoiceRepository : ICrudRepository<ulong, IInvoiceDefinition>
    {
        
    }

}
