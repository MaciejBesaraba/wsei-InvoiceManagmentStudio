using Core.Domain.BillingInfo;

namespace Core.Application.BillingInfo
{

    public interface IBillingInfoService : ICrudService<ulong, BillingInfoDto>
    {
        
    }

}
