using Core.Domain.BillingInfo;
using Core.Domain.ContactInfo;


namespace Core.Domain.Entity.Receiver
{
    public class EntityReceiverDto : EntityDto
    {
        private EntityReceiverDto(
            IObjectIdentifier<ulong> id,
            IBillingInfoDefinition billingInfo,
            IContactInfoDefinition contactInfo
        ) : base(id, billingInfo, contactInfo) { }

        public static EntityReceiverDto FromDomain(Entity entity) =>
            new EntityReceiverDto(entity.Id, entity.BillingInfo, entity.ContactInfo);
    }
}
