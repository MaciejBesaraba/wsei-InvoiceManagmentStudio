using InvoiceManagementStudio.Core.Definition;
using InvoiceManagementStudio.Core.Definition.BillingInfo;
using InvoiceManagementStudio.Core.Definition.ContactInfo;


namespace InvoiceManagementStudio.Model.Domain
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
