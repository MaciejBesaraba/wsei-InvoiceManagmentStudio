using InvoiceManagementStudio.Core.Domain.BillingInfo;
using InvoiceManagementStudio.Core.Domain.ContactInfo;

namespace InvoiceManagementStudio.Core.Domain.Entity.Receiver
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
