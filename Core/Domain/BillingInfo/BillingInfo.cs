using System;
using AddressDomain = Core.Domain.Address.Address;

namespace Core.Domain.BillingInfo
{
    public class BillingInfo : IBillingInfoDefinition, IEquatable<BillingInfo>
    {
        public IObjectIdentifier<ulong> Id { get; }
        public string CompanyName { get; }
        public string ZipCode { get; }
        public AddressDomain BillingAddress { get; }


        public BillingInfo(
            IObjectIdentifier<ulong> id,
            string companyName,
            string zipCode,
            AddressDomain billingAddress
        )
        {
            Id = id;
            CompanyName = companyName;
            ZipCode = zipCode;
            BillingAddress = billingAddress;
        }

        public override string ToString()
        {
            return "BillingInfo(" +
                       $"id={Id}, " +
                       $"companyName={CompanyName}, " +
                       $"zipCode={ZipCode}, " +
                       $"billingAddress={BillingAddress}" +
                   ")";
        }

        public bool Equals(BillingInfo other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(Id, other.Id) &&
                   Equals(CompanyName, other.CompanyName) &&
                   Equals(ZipCode, other.ZipCode) &&
                   Equals(BillingAddress, other.BillingAddress);
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
            return obj.GetType() == GetType() && Equals((BillingInfo)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CompanyName != null ? CompanyName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ZipCode != null ? ZipCode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingAddress != null ? BillingAddress.GetHashCode() : 0);

                return hashCode;
            }
        }
        public static BillingInfo Create(
            string companyName,
            string zipCode,
            AddressDomain billingAddress
        )
        {
            return new BillingInfo(null, companyName, zipCode, billingAddress);
        }
    }
}
