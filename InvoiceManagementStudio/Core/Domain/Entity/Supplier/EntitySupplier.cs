using InvoiceManagementStudio.Core.Domain.BillingInfo;
using InvoiceManagementStudio.Core.Domain.ContactInfo;

namespace InvoiceManagementStudio.Core.Domain.Entity.Supplier
{

    public class EntitySupplier : Entity
    {

        public EntitySupplier(
            IObjectIdentifier<ulong> id,
            IBillingInfoDefinition billingInfo,
            IContactInfoDefinition contactInfo
        ) : base(id, billingInfo, contactInfo)
        {
            
        }
        
    }

}
