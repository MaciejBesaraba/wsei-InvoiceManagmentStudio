using System;
using System.Collections.Generic;

using InvoiceManagementStudio.Core.Definition.Entity;


namespace InvoiceManagementStudio.Core.Definition.Invoice
{

    public interface IInvoiceDefinition
    {
        IObjectIdentifier<ulong> Id { get; }
        string Serial { get; }
        DateTime IssueDate { get; }
        DateTime DueDate { get; }
        DateTime? RedemptionDate { get; }
        bool IsPayed { get; }
        decimal Subtotal { get; }
        decimal Discount { get; }
        decimal Total { get; }
        decimal Payed { get; }
        decimal Due { get; }
        List<IInvoiceItemDefinition> Items { get; }
        List<IInvoicePaymentDefinition> Payments { get; }
        IEntitySupplierDefinition Supplier { get; }
        IEntityReceiverDefinition Receiver { get; }
    }

}
