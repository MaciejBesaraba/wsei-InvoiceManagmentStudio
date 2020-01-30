using AddressDomain = Core.Domain.Address.Address;

namespace Core.Domain.BillingInfo
{
    /// <summary>
    /// Represents company billing data needed to issue a invoice
    /// </summary>
    public interface IBillingInfoDefinition
    {
        /// <summary>
        /// Unique identifier for BillingInfo instance
        /// </summary>
        IObjectIdentifier<ulong> Id { get; }

        /// <summary>
        /// Name of company issuing/issued invoice
        /// </summary>
        string CompanyName { get; }

        // TODO Localization
        /// <summary>
        /// Postal code associated with address
        /// </summary>
        string ZipCode { get; }

        /// <summary>
        /// Official address related to billing data
        /// </summary>
        AddressDomain BillingAddress { get; }
    }

}
