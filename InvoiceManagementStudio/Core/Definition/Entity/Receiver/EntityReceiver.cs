using InvoiceManagementStudio.Core.Definition.BillingInfo;
using InvoiceManagementStudio.Core.Definition.ContactInfo;

namespace InvoiceManagementStudio.Core.Definition.Entity.Receiver
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
