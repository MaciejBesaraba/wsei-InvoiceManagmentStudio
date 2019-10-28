using System.Collections.Generic;

using InvoiceManagementStudio.Core.Definition.Entity;


namespace InvoiceManagementStudio.Core.Definition.Invoice
{

    public interface IInvoiceDefinition
    {
        IObjectIdentifier<ulong> Id { get; }
        List<IInvoiceItemDefinition> Items { get; }
        List<IInvoicePaymentDefinition> Payments { get; }
        IEntitySupplierDefinition Supplier { get; }
        IEntityReceiverDefinition Receiver { get; }
    }

}
