using System;
using System.Collections.Generic;
using Core.Domain.Entity.Receiver;
using Core.Domain.Entity.Supplier;
using Core.Domain.Item;
using Core.Domain.Payment;

namespace Core.Domain.Invoice
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
        List<InvoiceItem> Items { get; }

        /// <summary>
        /// List of payments to supplier issuing invoice
        /// </summary>
        List<InvoicePayment> Payments { get; }

        /// <summary>
        /// Entity issuing invoice
        /// </summary>
        EntitySupplier Supplier { get; }

        /// <summary>
        /// Entity receiving invoice
        /// </summary>
        EntityReceiver Receiver { get; }
    }

}
