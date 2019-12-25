using Core.Domain.ContactInfo;

namespace Core.Application.ContactInfo
{

    public interface IContactInfoService : ICrudService<ulong, IContactInfoDefinition>
    {
        
    }

}
