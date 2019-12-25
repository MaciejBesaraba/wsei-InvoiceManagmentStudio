namespace InvoiceManagementStudio.Core.Domain.Payment
{

    public interface IInvoicePaymentRepository : ICrudRepository<ulong, IInvoicePaymentDefinition>
    {
        
    }

}
