namespace Core.Application.Invoice
{

    public interface IInvoiceRepository : ICrudRepository<ulong, Domain.Invoice.Invoice>
    {
        
    }

}
