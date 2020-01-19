using Core.Domain.BillingInfo;
using Core.Domain.ContactInfo;


namespace Core.Domain.Entity.Supplier
{
    public class EntitySupplierDto : EntityDto
    {
        private EntitySupplierDto(
            IObjectIdentifier<ulong> id,
            IBillingInfoDefinition billingInfo,
            IContactInfoDefinition contactInfo
        ) : base(id, billingInfo, contactInfo) { }

        public static EntitySupplierDto FromDomain(Entity entity) => new EntitySupplierDto(entity.Id, entity.BillingInfo, entity.ContactInfo);
    }
}
