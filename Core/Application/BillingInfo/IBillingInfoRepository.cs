using Core.Domain.BillingInfo;

namespace Core.Application.BillingInfo
{

    public interface IBillingInfoRepository: ICrudRepository<ulong, IBillingInfoDefinition>
    {
        
    }

}
