using InvoiceManagementStudio.Core.Domain;
using InvoiceManagementStudio.Core.Domain.ContactInfo;

namespace InvoiceManagementStudio.Core.Application.ContactInfo
{

    public interface IContactInfoService : ICrudService<ulong, IContactInfoDefinition>
    {
        
    }

}
