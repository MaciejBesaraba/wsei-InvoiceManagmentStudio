using System;
using System.Globalization;

namespace Core.Domain.Payment
{

    public class InvoicePaymentDto : IInvoicePaymentDefinition, IEquatable<InvoicePaymentDto>
    {
        private readonly IObjectIdentifier<ulong> _id;
        private readonly EPaymentType _type;
        private readonly DateTime _date;
        private readonly TimeZoneInfo _timeZone;
        private readonly decimal _amount;
        //add backing fields

        public IObjectIdentifier<ulong> Id => _id;
        public EPaymentType Type => _type;
        public DateTime Date => _date;
        public TimeZoneInfo TimeZone => _timeZone;
        public decimal Amount => _amount;

        private InvoicePaymentDto(
            IObjectIdentifier<ulong> id,
            EPaymentType type,
            DateTime date,
            TimeZoneInfo timeZone,
            decimal amount
            //add private constructor
        )
        {
            _id = id;
            _type = type;
            _date = date;
            _timeZone = timeZone;
            _amount = amount;
        }

        public override string ToString()
        {
            return "InvoicePayment(" +
                       $"id={Id}, " +
                       $"type={Type}," +
                       $"date={Date:yyyy-MM-dd}, " +
                       $"timeZone={TimeZone}, " +
                       $"amount={Amount.ToString(CultureInfo.InvariantCulture)}, " +
                   ")";
        }

        public bool Equals(InvoicePaymentDto other)
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

            return obj.GetType() == GetType() && Equals((InvoicePaymentDto)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_type != null ? _type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_date != null ? _date.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_timeZone != null ? _timeZone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_amount != null ? _amount.GetHashCode() : 0);

                return hashCode;
            }
        }
        public static InvoicePaymentDto FromDomain(InvoicePayment invoicePayment)
        {
            return new InvoicePaymentDto(
                invoicePayment.Id,
                invoicePayment.Type,
                invoicePayment.Date,
                invoicePayment.TimeZone,
                invoicePayment.Amount
            );
        }
    }
}
