using System.Data;
using Core.Domain;
using BillingInfoDomain = Core.Domain.BillingInfo.BillingInfo;
using ContactInfoDomain = Core.Domain.ContactInfo.ContactInfo;
using SupplierDomain = Core.Domain.Entity.Supplier.EntitySupplier;

namespace Repository.Entity.Supplier
{
    public class SupplierEntity : EntityEntity
    {
        public SupplierEntity(ulong? id, ulong billingInfo, ulong contactInfo) : base(id, billingInfo, contactInfo) { }

        public SupplierDomain ToDomain(BillingInfoDomain billingInfo, ContactInfoDomain contactInfo)
        {
            return new SupplierDomain(
                new SimpleObjectIdentifier(Id ?? throw new DataException("ReceiverEntity Id is null")),
                billingInfo,
                contactInfo
            );
        }

        public static SupplierEntity FromDomain(SupplierDomain domain)
        {
            return new SupplierEntity(
                domain.Id.Value,
                domain.BillingInfo.Id.Value,
                domain.ContactInfo.Id.Value
            );
        }
    }
}