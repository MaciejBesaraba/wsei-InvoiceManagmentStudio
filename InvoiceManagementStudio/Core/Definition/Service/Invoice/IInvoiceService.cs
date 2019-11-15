using InvoiceManagementStudio.Core.Definition.Invoice;


namespace InvoiceManagementStudio.Core.Definition.Service.Invoice
{

    public interface IInvoiceService  : ICrudService<ulong, IInvoiceDefinition>
    {
        
    }

}
