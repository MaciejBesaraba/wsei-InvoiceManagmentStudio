using EntityDomain = Core.Domain.Entity.Entity;
using BillingInfoDomain = Core.Domain.BillingInfo.BillingInfo;
using ContactInfoDomain = Core.Domain.ContactInfo.ContactInfo;

namespace Repository.Entity
{
    public abstract class EntityEntity
    {
        public ulong? Id { get; set; }
        public ulong BillingInfo { get; set; }
        public ulong ContactInfo { get; set; }

        protected EntityEntity(ulong? id, ulong billingInfo, ulong contactInfo)
        {
            Id = id;
            BillingInfo = billingInfo;
            ContactInfo = contactInfo;
        }
    }
}
