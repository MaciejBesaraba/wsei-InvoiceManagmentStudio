using System;
using System.Data;
using Core.Domain;
using Core.Domain.Payment;

namespace Repository.Payment
{
    public class InvoicePaymentEntity
    {
        public ulong? Id { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; }
        public string TimeZone { get; set; }
        public decimal Amount { get; set; }

        public InvoicePaymentEntity(
            ulong? id,
            string type,
            DateTime date,
            TimeZoneInfo timeZone,
            decimal amount
        )
        {
            Id = id;
            Type = type;
            Date = date;
            // TODO ArBy timeZone
            TimeZone = TimeZoneInfo.Local.ToString();
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
    }
}