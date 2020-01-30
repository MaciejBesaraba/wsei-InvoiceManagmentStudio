using BillingInfoDomain = Core.Domain.BillingInfo.BillingInfo;
using ContactInfoDomain = Core.Domain.ContactInfo.ContactInfo;

namespace Core.Domain.Entity.Receiver
{
    public class EntityReceiver : Entity
    {
        public EntityReceiver(
            IObjectIdentifier<ulong> id,
            BillingInfoDomain billingInfo,
            ContactInfoDomain contactInfo
        ) : base(id, billingInfo, contactInfo) { }
        
        public static EntityReceiver Create(
            BillingInfoDomain billingInfo,
            ContactInfoDomain contactInfo
        )
        {
            return new EntityReceiver(null, billingInfo, contactInfo);
        }
    }
}

