namespace Core.Domain.Address
{
    // TODO Localization
    /// <summary>
    /// Represents physical address
    /// </summary>
    public interface IAddressDefinition
    {
        /// <summary>
        /// Unique identifier of address instance
        /// </summary>
        IObjectIdentifier<ulong> Id { get; }

        // TODO Localization
        /// <summary>
        /// Name of country where address is located
        /// </summary>
        string Country { get; }

        /// <summary>
        /// Name of city within given country
        /// </summary>
        string City { get; }

        /// <summary>
        /// Name of street
        /// </summary>
        string Street { get; }

        // TODO Localization
        /// <summary>
        /// Represents part of country territory considered as an organized political community
        /// </summary>
        string State { get; }

        /// <summary>
        /// Name/number of address located on given street
        /// </summary>
        string BuildingNumber { get; }

        /// <summary>
        /// Name/Number within given building identification number/name
        /// Set to null will assume it is not necessary to differentiate within building
        /// </summary>
        string FlatNumber { get; }
    }

}
