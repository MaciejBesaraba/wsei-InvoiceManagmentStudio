namespace InvoiceManagementStudio.Core.Definition.Invoice
{
    /// <summary>
    /// Defines object model for invoice item 
    /// </summary>
    public interface IInvoiceItemDefinition
    {
        /// <summary>
        /// Unique logical identifier of invoice item
        /// </summary>
        IObjectIdentifier<ulong> Id { get; }

        /// <summary>
        /// Name of the item
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Price of the specified position on the invoice
        /// </summary>
        decimal UnitPrice { get; }

        /// <summary>
        /// Type of measurement of a single piece of item
        /// </summary>
        EUnitType UnitType { get; }

        /// <summary>
        /// Total sum of a discount on a specified product
        /// </summary>
        decimal Discount { get; }

        /// <summary>
        /// Full price of the payment (price*quantity)
        /// </summary>
        decimal Subtotal { get; }

        /// <summary>
        /// Full price of the payment (added discount)
        /// </summary>
        decimal Total { get; }
    }

}
