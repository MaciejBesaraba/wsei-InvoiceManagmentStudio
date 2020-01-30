using Core.Domain.Payment;

namespace Core.Application.Payment
{

    public interface IInvoicePaymentRepository : ICrudRepository<ulong, InvoicePayment>
    {
        
    }

}
