using InvoiceManagementStudio.Core.Domain;
using InvoiceManagementStudio.Core.Domain.Address;

namespace InvoiceManagementStudio.Core.Application.Address
{

    public interface IAddressService : ICrudService<ulong, IAddressDefinition>
    {
        
    }

}
