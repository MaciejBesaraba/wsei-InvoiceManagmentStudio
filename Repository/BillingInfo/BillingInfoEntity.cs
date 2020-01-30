using System.Data;
using Core.Domain;
using BillingInfoDomain = Core.Domain.BillingInfo.BillingInfo;
using AddressDomain = Core.Domain.Address.Address;
    
namespace Repository.BillingInfo
{
    public class BillingInfoEntity
    {
        public ulong? Id { get; set; }
        public string CompanyName { get; set; }
        public string ZipCode { get; set; }
        public ulong BillingAddressRef { get; set; }

        public BillingInfoEntity(ulong? id, string companyName, string zipCode, ulong billingAddressRef)
        {
            Id = id;
            CompanyName = companyName;
            ZipCode = zipCode;
            BillingAddressRef = billingAddressRef;
        }

        public BillingInfoDomain ToDomain(AddressDomain address)
        {
            return new BillingInfoDomain(
                new SimpleObjectIdentifier(Id ?? throw new DataException("BillingInfo Id is null")),
                CompanyName,
                ZipCode,
                address
            );
        }

        public static BillingInfoEntity FromDomain(BillingInfoDomain domain)
        {
            return new BillingInfoEntity(
                domain.Id.Value,
                domain.CompanyName,
                domain.ZipCode,
                domain.BillingAddress.Id.Value
            );
        }
    }
}