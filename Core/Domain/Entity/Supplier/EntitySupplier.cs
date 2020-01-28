using BillingInfoDomain = Core.Domain.BillingInfo.BillingInfo;
using ContactInfoDomain = Core.Domain.ContactInfo.ContactInfo;

namespace Core.Domain.Entity.Supplier
{
    public class EntitySupplier : Entity
    {
        public EntitySupplier(
            IObjectIdentifier<ulong> id,
            BillingInfoDomain billingInfo,
            ContactInfoDomain contactInfo
        ) : base(id, billingInfo, contactInfo) { }
        
        public static EntitySupplier Create(
            BillingInfoDomain billingInfo,
            ContactInfoDomain contactInfo
        )
        {
            return new EntitySupplier(null, billingInfo, contactInfo);
        }
    }
}
