using System;
using Core.Domain.BillingInfo;
using Core.Domain.ContactInfo;


namespace Core.Domain.Entity
{
    public abstract class EntityDto : IEquatable<EntityDto>
    {
        private readonly IObjectIdentifier<ulong> _id;
        private readonly BillingInfoDto _billingInfo;
        private readonly ContactInfoDto _contactInfo;

        public IObjectIdentifier<ulong> Id => _id;
        public BillingInfoDto BillingInfo => _billingInfo;
        public ContactInfoDto ContactInfo => _contactInfo;

        protected EntityDto(
            IObjectIdentifier<ulong> id,
            BillingInfoDto billingInfo,
            ContactInfoDto contactInfo
        )
        {
            _id = id;
            _billingInfo = billingInfo;
            _contactInfo = contactInfo;
        }

        public override string ToString() => $"{GetType().Name}(id={Id}, billingInfo={BillingInfo}, contactInfo={ContactInfo})";

        public bool Equals(EntityDto other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(_id, other._id) &&
                   IBillingInfoDefinition.Equals(_billingInfo, other._billingInfo) &&
                   IContactInfoDefinition.Equals(_contactInfo, other._contactInfo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return obj.GetType() == this.GetType() && Equals((EntityDto)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_id != null ? _id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_billingInfo != null ? _billingInfo.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_contactInfo != null ? _contactInfo.GetHashCode() : 0);
                return hashCode;
            }
        }
    }

}
