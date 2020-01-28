using System;
using System.Data;
using Core.Domain;
using Core.Domain.Payment;

namespace Repository.Payment
{
    // TODO ArBy timeZone
    public class InvoicePaymentEntity
    {
        public ulong? Id { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string TimeZone { get; set; }
        public decimal Amount { get; set; }

        public InvoicePaymentEntity(
            ulong? id,
            string type,
            DateTime date,
            string timeZone,
            decimal amount
        )
        {
            Id = id;
            Type = type;
            Date = date;
            TimeZone = timeZone;
            Amount = amount;
        }

        public InvoicePayment ToDomain()
        {
            return new InvoicePayment(
                new SimpleObjectIdentifier(Id ?? throw new DataException("InvoicePaymentEntity Id is null")),
                (EPaymentType)Enum.Parse(typeof(EPaymentType), Type),
                Date,
                TimeZoneInfo.Local,
                Amount
            );
        }

        public static InvoicePaymentEntity FromDomain(InvoicePayment domain)
        {
            return new InvoicePaymentEntity(
                domain.Id.Value,
                domain.Type.ToString(),
                domain.Date,
                domain.TimeZone.BaseUtcOffset.ToString(),
                domain.Amount
            );
        }
    }
}
