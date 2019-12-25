using System;
using System.Collections.Generic;
using InvoiceManagementStudio.Core.Domain.Entity.Receiver;
using InvoiceManagementStudio.Core.Domain.Entity.Supplier;
using InvoiceManagementStudio.Core.Domain.Item;
using InvoiceManagementStudio.Core.Domain.Payment;

namespace InvoiceManagementStudio.Core.Domain.Invoice
{
    /// <summary>
    /// Defines object model for invoice
    /// </summary>
    public interface IInvoiceDefinition
    {
        /// <summary>
        /// Unique logical identifier of invoice
        /// </summary>
        IObjectIdentifier<ulong> Id { get; }

        /// <summary>
        /// Unique fiscal identifier of invoice
        /// </summary>
        string Serial { get; }

        /// <summary>
        /// Date when invoice was issued to Receiver
        /// </summary>
        DateTime IssueDate { get; }

        /// <summary>
        /// Date when invoice should be payed
        /// </summary>
        DateTime DueDate { get; }

        /// <summary>
        /// Date when invoice was fully paid of
        /// </summary>
        DateTime? RedemptionDate { get; }

        /// <summary>
        /// Is invoice already payed
        /// </summary>
        bool IsPayed { get; }

        /// <summary>
        /// Full payment of services, excluding any discounts
        /// </summary>
        decimal Subtotal { get; }

        /// <summary>
        /// Total amount discounted for invoice
        /// </summary>
        decimal Discount { get; }

        /// <summary>
        /// Final payment for invoice including discounts
        /// </summary>
        decimal Total { get; }

        /// <summary>
        /// Current amount payed by invoice receiver
        /// </summary>
        decimal Payed { get; }

        /// <summary>
        /// Amount left to pay by invoice receiver
        /// </summary>
        decimal Due { get; }

        /// <summary>
        /// List of invoice services and items shipped to receiver
        /// </summary>
        List<IInvoiceItemDefinition> Items { get; }

        /// <summary>
        /// List of payments to supplier issuing invoice
        /// </summary>
        List<IInvoicePaymentDefinition> Payments { get; }

        /// <summary>
        /// Entity issuing invoice
        /// </summary>
        IEntitySupplierDefinition Supplier { get; }

        /// <summary>
        /// Entity receiving invoice
        /// </summary>
        IEntityReceiverDefinition Receiver { get; }
    }

}
