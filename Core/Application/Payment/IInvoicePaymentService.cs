using Core.Domain.Payment;

namespace Core.Application.Payment
{

    public interface IInvoicePaymentService : ICrudService<ulong, IInvoicePaymentDefinition>
    {
        
    }

}
