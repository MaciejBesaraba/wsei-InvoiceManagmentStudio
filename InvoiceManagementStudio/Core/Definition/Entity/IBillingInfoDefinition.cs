namespace InvoiceManagementStudio.Core.Definition.Entity
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
        IAddressDefinition BillingAddress { get; }

    }

}
