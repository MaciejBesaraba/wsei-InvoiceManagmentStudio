using System;
using System.Collections.Generic;

namespace InvoiceManagementStudio.Core.Definition.Payment
{
    /// <summary>
    /// Defines object details for the payments
    /// </summary>
    public interface IInvoicePaymentDefinition
    {
        /// <summary>
        /// Unique logical identifier of invoice (connects to InvoicePaymentDefinition)
        /// </summary>
        IObjectIdentifier<ulong> Id { get; }

        /// <summary>
        /// Specifies payment methods
        /// </summary>
        EType PaymentType { get; }

        /// <summary>
        /// The date payment was posted
        /// </summary>
        DateTime PaymentDate { get; }

        /// <summary>
        /// Specifies Time zone
        /// </summary>
        string LocalTime { get; }

        /// <summary>
        /// Amount of the money posted (need to be compared with Total payment)
        /// </summary>
        decimal PaymentAmount { get; }

        /// <summary>
        /// Brand of the credit card used to issue payment
        /// </summary>
        string CreditCardType { get; }


    }

}
