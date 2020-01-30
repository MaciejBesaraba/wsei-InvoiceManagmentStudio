using Core.Domain.BillingInfo;
using Core.Domain.ContactInfo;

namespace Core.Domain.Entity.Receiver
{
    public class EntityReceiverDto : EntityDto
    {
        private EntityReceiverDto(
            IObjectIdentifier<ulong> id,
            BillingInfoDto billingInfo,
            ContactInfoDto contactInfo
        ) : base(id, billingInfo, contactInfo) { }

        public static EntityReceiverDto FromDomain(EntityReceiver receiver)
        {
            return new EntityReceiverDto(
                receiver.Id,
                BillingInfoDto.FromDomain(receiver.BillingInfo),
                ContactInfoDto.FromDomain(receiver.ContactInfo)
            );
        }
    }
}
