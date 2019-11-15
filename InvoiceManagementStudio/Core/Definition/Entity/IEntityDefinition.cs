using InvoiceManagementStudio.Core.Definition.BillingInfo;
using InvoiceManagementStudio.Core.Definition.ContactInfo;


namespace InvoiceManagementStudio.Core.Definition.Entity
{
    /// <summary>
    /// Represents an Entity-Company able to receive or issue an invoice
    /// </summary>
    public interface IEntityDefinition
    {
        /// <summary>
        /// Unique identifier for entity instance
        /// </summary>
        IObjectIdentifier<ulong> Id { get; }

        /// <summary>
        /// Data set necessary to issue an invoice
        /// </summary>
        IBillingInfoDefinition BillingInfo { get; }

        /// <summary>
        /// Contact information provided by entity
        /// </summary>
        IContactInfoDefinition ContactInfo { get; }
    }

}
