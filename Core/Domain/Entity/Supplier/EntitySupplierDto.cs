using Core.Domain.BillingInfo;
using Core.Domain.ContactInfo;


namespace Core.Domain.Entity.Supplier
{
    public class EntitySupplierDto : EntityDto
    {
        private EntitySupplierDto(
            IObjectIdentifier<ulong> id,
            BillingInfoDto billingInfo,
            ContactInfoDto contactInfo
        ) : base(id, billingInfo, contactInfo) { }

        public static EntitySupplierDto FromDomain(EntitySupplier supplier)
        {
            return new EntitySupplierDto(
                supplier.Id,
                BillingInfoDto.FromDomain(supplier.BillingInfo),
                ContactInfoDto.FromDomain(supplier.ContactInfo)
            );
        }
    }
}
