using InvoiceManagementStudio.Core.Definition.Invoice;


namespace InvoiceManagementStudio.Core.Definition.Repository.Payment
{

    public interface IInvoicePaymentRepository : ICrudRepository<ulong, IInvoicePaymentDefinition>
    {
        
    }

}
