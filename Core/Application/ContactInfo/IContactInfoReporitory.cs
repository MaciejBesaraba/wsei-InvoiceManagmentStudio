namespace Core.Application.ContactInfo
{

    public interface IContactInfoRepository: ICrudRepository<ulong, Domain.ContactInfo.ContactInfo>
    {
        
    }

}
