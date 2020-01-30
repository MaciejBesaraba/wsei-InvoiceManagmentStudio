namespace Core.Application.BillingInfo
{

    public interface IBillingInfoRepository: ICrudRepository<ulong, Domain.BillingInfo.BillingInfo>
    {
        
    }

}
