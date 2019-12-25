using InvoiceManagementStudio.Core.Domain;
using InvoiceManagementStudio.Core.Domain.Payment;

namespace InvoiceManagementStudio.Core.Application.Payment
{

    public interface IInvoicePaymentRepository : ICrudRepository<ulong, IInvoicePaymentDefinition>
    {
        
    }

}
