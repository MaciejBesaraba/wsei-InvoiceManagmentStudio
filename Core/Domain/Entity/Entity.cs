using System;
using Core.Domain.BillingInfo;
using Core.Domain.ContactInfo;

namespace Core.Domain.Entity
{

    public abstract class Entity : IEntityDefinition, IEquatable<Entity>
    {
        public IObjectIdentifier<ulong> Id { get; }

        public IBillingInfoDefinition BillingInfo { get; }

        public IContactInfoDefinition ContactInfo { get; }


        protected Entity(
            IObjectIdentifier<ulong> id,
            IBillingInfoDefinition billingInfo,
            IContactInfoDefinition contactInfo
        )
        {
            Id = id;
            BillingInfo = billingInfo;
            ContactInfo = contactInfo;
        }


        public override string ToString()
        {
            return "Entity(" +
                       $"id={Id}, " +
                       $"billing info={BillingInfo}, " +
                       $"contact info=[{ContactInfo}]" +
                   ")";
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
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((Entity) obj);
        }

        public bool Equals(Entity other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(Id, other.Id) && Equals(BillingInfo, other.BillingInfo) && Equals(ContactInfo, other.ContactInfo);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingInfo != null ? BillingInfo.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ContactInfo != null ? ContactInfo.GetHashCode() : 0);
                return hashCode;
            }
        }
        public static Entity Create(
            IBillingInfoDefinition billingInfo,
            IContactInfoDefinition contactInfo
        )
        {
            return new Entity(null, billingInfo, contactInfo);
        }
    }

}
