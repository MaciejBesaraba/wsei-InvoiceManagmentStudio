using Core.Domain.BillingInfo;
using Core.Domain.ContactInfo;


namespace Core.Domain.Entity.Supplier
{
    public class EntitySupplier : Entity
    {
        public EntitySupplier(
            IObjectIdentifier<ulong> id,
            IBillingInfoDefinition billingInfo,
            IContactInfoDefinition contactInfo
        ) : base(id, billingInfo, contactInfo) { }
        
        public static EntitySupplier Create(
            IBillingInfoDefinition billingInfo,
            IContactInfoDefinition contactInfo
        )
        {
            return new EntitySupplier(null, billingInfo, contactInfo);
        }
    }
}
