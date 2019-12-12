using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using InvoiceManagementStudio.Core.Definition;
using InvoiceManagementStudio.Core.Definition.Entity.Receiver;
using InvoiceManagementStudio.Core.Definition.Entity.Supplier;
using InvoiceManagementStudio.Core.Definition.Invoice;
using InvoiceManagementStudio.Core.Definition.Item;
using InvoiceManagementStudio.Core.Definition.Payment;


namespace InvoiceManagementStudio.Model.Domain
{

    public class InvoicePayment : IInvoicePaymentDefinition, IEquatable<InvoicePayment>
    {
        public IObjectIdentifier<ulong> Id { get; }
        public EType PaymentType { get; }
        public DateTime Date { get; }
        public TimeZoneInfo TimeZone { get; }
        public decimal Amount { get; }
        

        public InvoicePayment(
        IObjectIdentifier<ulong> id,
        EType paymentType,
        DateTime date,
        TimeZoneInfo timezone,
        decimal amount
        )
        {
            Id = id;
            PaymentType = paymentType;
            Date = date;
            TimeZone = timezone;
            Amount = amount;

        }

        public override string ToString()
        {
            var formattedDate = Date.ToString("yyyy-MM-dd");

            return "InvoicePayment(" +
                       $"id={Id}, " +
                       $"paymentType={PaymentType}," +
                       $"date={formattedDate}, " +
                       $"timeZone={TimeZone}, " +
                       $"amount={Amount.ToString(CultureInfo.InvariantCulture)}, " +
                   ")";
        }

        


    }

}