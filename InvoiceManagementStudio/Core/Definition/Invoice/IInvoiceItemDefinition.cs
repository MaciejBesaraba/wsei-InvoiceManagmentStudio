namespace InvoiceManagementStudio.Core.Definition.Invoice
{

    public interface IInvoiceItemDefinition
    {
        IObjectIdentifier<ulong> Id { get; }

        string Name { get; }

        decimal UnitPrice { get; }

        EUnitType UnitType { get; }

        decimal Discount { get; }

        decimal Subtotal { get; }

        decimal Total { get; }
    }

}
