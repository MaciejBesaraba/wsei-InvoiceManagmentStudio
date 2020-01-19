using Core.Domain.Invoice;


namespace Core.Application.Invoice
{

    public interface IInvoiceService  : ICrudService<ulong, InvoiceDto>
    {
        
    }

}
