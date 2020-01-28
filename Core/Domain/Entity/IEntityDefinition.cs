using BillingInfoDomain = Core.Domain.BillingInfo.BillingInfo;
using ContactInfoDomain = Core.Domain.ContactInfo.ContactInfo;

namespace Core.Domain.Entity
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
        BillingInfoDomain BillingInfo { get; }

        /// <summary>
        /// Contact information provided by entity
        /// </summary>
        ContactInfoDomain ContactInfo { get; }
    }

}
