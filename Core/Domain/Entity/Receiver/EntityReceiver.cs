using Core.Domain.BillingInfo;
using Core.Domain.ContactInfo;


namespace Core.Domain.Entity.Receiver
{
    public class EntityReceiver : Entity
    {
        public EntityReceiver(
            IObjectIdentifier<ulong> id,
            IBillingInfoDefinition billingInfo,
            IContactInfoDefinition contactInfo
        ) : base(id, billingInfo, contactInfo) { }
        
        public static EntityReceiver Create(
            IBillingInfoDefinition billingInfo,
            IContactInfoDefinition contactInfo
        )
        {
            return new EntityReceiver(null, billingInfo, contactInfo);
        }
    }
}

