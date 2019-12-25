using System;
using System.Globalization;

namespace Core.Domain.Payment
{

    public class InvoicePayment : IInvoicePaymentDefinition, IEquatable<InvoicePayment>
    {
        public IObjectIdentifier<ulong> Id { get; }
        public EPaymentType Type { get; }
        public DateTime Date { get; }
        public TimeZoneInfo TimeZone { get; }
        public decimal Amount { get; }


        public InvoicePayment(
            IObjectIdentifier<ulong> id,
            EPaymentType paymentPaymentType,
            DateTime date,
            TimeZoneInfo timezone,
            decimal amount
        )
        {
            Id = id;
            Type = paymentPaymentType;
            Date = date;
            TimeZone = timezone;
            Amount = amount;
        }
        

        public override string ToString()
        {
            return "InvoicePayment(" +
                       $"id={Id}, " +
                       $"paymentType={Type}," +
                       $"date={Date:yyyy-MM-dd}, " +
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
                   Equals(Type, other.Type) &&
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
                hashCode = (hashCode * 397) ^ (Type != null ? Type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Date.GetHashCode();
                hashCode = (hashCode * 397) ^ (TimeZone != null ? TimeZone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Amount != null ? Amount.GetHashCode() : 0);

                return hashCode;
            }
        }
    }
}
