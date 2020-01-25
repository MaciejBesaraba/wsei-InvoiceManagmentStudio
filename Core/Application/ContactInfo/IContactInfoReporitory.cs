using Core.Domain.ContactInfo;

namespace Core.Application.ContactInfo
{

    public interface IContactInfoRepository: ICrudRepository<ulong, IContactInfoDefinition>
    {
        
    }

}
