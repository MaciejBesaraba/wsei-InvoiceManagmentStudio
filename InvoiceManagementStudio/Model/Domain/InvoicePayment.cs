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

        public bool Equals(InvoicePayment other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(Id, other.Id) &&
                   Equals(PaymentType, other.PaymentType) &&
                   Date.Equals(other.Date) &&
                   TimeZone.Equals(other.TimeZone) &&
                   Equals(Amount, other.Amount);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((InvoicePayment)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PaymentType != null ? PaymentType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Date.GetHashCode();

                //hashCode = (hashCode * 397) ^ (TimeZoneInfo != null ? TimeZoneInfo.GetHashCode() : 0);  
                //TimeZoneInfo is defined at the start -> should it be implemented here?

                hashCode = (hashCode * 397) ^ (Amount != null ? Amount.GetHashCode() : 0);

                return hashCode;
            }
        }

    }

}