using System;
using Core.Domain.Address;


namespace Core.Domain.BillingInfo
{
    public class BillingInfoDto : IBillingInfoDefinition, IEquatable<BillingInfoDto>
    {
        private readonly IObjectIdentifier<ulong> _id;
        private readonly string _companyName;
        private readonly string _zipCode;
        private readonly IAddressDefinition _billingAddress;
        //add backing fields







        public override string ToString()
        {
            return "BillingInfoDto(" +
                   $"id={Id}, " +
                   $"companyName={CompanyName}, " +
                   $"zipCode={ZipCode}, " +
                   $"billingAddress={BillingAddress}, " +
                   ")";
        }

        public bool Equals(BillingInfoDto other)
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
                   string.Equals(_companyName, other._companyName) &&
                   string.Equals(_zipCode, other._zipCode) &&
                   string.Equals(_billingAddress, other._billingAddress);

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
            return Equals((BillingInfoDto)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_id != null ? _id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_companyName != null ? _companyName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_zipCode != null ? _zipCode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_billingAddress != null ? _billingAddress.GetHashCode() : 0);
                return hashCode;
            }
        }


    }

}
