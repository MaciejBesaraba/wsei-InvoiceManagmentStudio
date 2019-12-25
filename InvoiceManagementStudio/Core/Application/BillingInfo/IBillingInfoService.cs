using InvoiceManagementStudio.Core.Domain;
using InvoiceManagementStudio.Core.Domain.BillingInfo;

namespace InvoiceManagementStudio.Core.Application.BillingInfo
{

    public interface IBillingInfoService : ICrudService<ulong, IBillingInfoDefinition>
    {
        
    }

}
