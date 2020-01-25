using EntityDomain = Core.Domain.Entity.Entity;
using BillingInfoDomain = Core.Domain.BillingInfo.BillingInfo;
using ContactInfoDomain = Core.Domain.ContactInfo.ContactInfo;

namespace Repository.Entity
{
    public abstract class EntityEntity
    {
        public ulong? Id { get; set; }
        public ulong BillingInfoRef { get; set; }
        public ulong ContactInfoRef { get; set; }

        protected EntityEntity(ulong? id, ulong billingInfoRef, ulong contactInfoRef)
        {
            Id = id;
            BillingInfoRef = billingInfoRef;
            ContactInfoRef = contactInfoRef;
        }
    }
}
