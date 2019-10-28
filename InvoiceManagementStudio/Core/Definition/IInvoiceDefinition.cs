using System.Collections.Generic;


namespace InvoiceManagementStudio.Core.Definition
{

    public interface IInvoiceDefinition
    {
        IObjectIdentifier<ulong> Id { get; }
        List<IInvoiceItemDefinition> Items { get; }
        List<IInvoicePaymentDefinition> Payments { get; }
    }

}
