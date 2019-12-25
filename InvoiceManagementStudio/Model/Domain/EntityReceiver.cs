using InvoiceManagementStudio.Core.Definition;
using InvoiceManagementStudio.Core.Definition.BillingInfo;
using InvoiceManagementStudio.Core.Definition.ContactInfo;


namespace InvoiceManagementStudio.Model.Domain
{

    public class EntityReceiver : Entity
    {

        public EntityReceiver(
            IObjectIdentifier<ulong> id,
            IBillingInfoDefinition billingInfo,
            IContactInfoDefinition contactInfo
        ) : base(id, billingInfo, contactInfo)
        {
            
        }

    }

}
