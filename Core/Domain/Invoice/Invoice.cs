using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Core.Domain.Entity.Receiver;
using Core.Domain.Entity.Supplier;
using Core.Domain.Item;
using Core.Domain.Payment;

namespace Core.Domain.Invoice
{

    public class Invoice : IInvoiceDefinition, IEquatable<Invoice>
    {
        public IObjectIdentifier<ulong> Id { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? RedemptionDate { get; set; }
        public List<InvoiceItem> Items { get; set; }
        public List<InvoicePayment> Payments { get; set; }
        public EntitySupplier Supplier { get; set; }
        public EntityReceiver Receiver { get; set; }


        public Invoice(
            IObjectIdentifier<ulong> id,
            DateTime issueDate,
            DateTime dueDate,
            DateTime? redemptionDate,
            List<InvoiceItem> items,
            List<InvoicePayment> payments,
            EntitySupplier supplier,
            EntityReceiver receiver
        )
        {
            Id = id;
            IssueDate = issueDate;
            DueDate = dueDate;
            RedemptionDate = redemptionDate;
            Items = items;
            Payments = payments;
            Supplier = supplier;
            Receiver = receiver;
        }


        public string Serial => $"FV/{IssueDate.Year.ToString()}/{Id}";

        public decimal Total => Items.Sum(item => item.Total);

        public decimal Subtotal => Items.Sum(item => item.Subtotal);

        public decimal Discount => Items.Sum(item => item.Discount);

        public decimal Payed => Payments.Sum(payment => payment.Amount);

        public decimal Due => Total - Payed;

        public bool IsPayed => Total >= Payed;


        public override string ToString()
        {
            // TODO ArBy global culture, datetime format
            var formattedIssueDate = IssueDate.ToString("yyyy-MM-dd");
            var formattedDueDate = DueDate.ToString("yyyy-MM-dd");
            var formattedRedemptionDate = RedemptionDate != null ? RedemptionDate.Value.ToString("yyyy-MM-dd") : "n/a";

            return "Invoice(" +
                       $"serial={Serial}, " +
                       $"id={Id}, " +
                       $"isPayed={IsPayed.ToString()}, " +
                       $"issueDate={formattedIssueDate}, " +
                       $"dueDate={formattedDueDate}, " +
                       $"redemptionDate={formattedRedemptionDate}, " +
                       $"supplier={Supplier}, " +
                       $"receiver={Receiver}, " +
                       $"total={Total.ToString(CultureInfo.InvariantCulture)}, " +
                       $"subtotal={Subtotal.ToString(CultureInfo.InvariantCulture)}, " +
                       $"discount={Discount.ToString(CultureInfo.InvariantCulture)}, " +
                       $"payed={Payed.ToString(CultureInfo.InvariantCulture)}, " +
                       $"due={Due.ToString(CultureInfo.InvariantCulture)}, " +
                       $"items=[{string.Join(", ", Items)}], " +
                       $"payments=[{string.Join(", ", Payments)}]" +
                   ")";
        }

        public bool Equals(Invoice other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            // TODO ArBy redemptionDate equality
            return Equals(Id, other.Id) &&
                   IssueDate.Equals(other.IssueDate) &&
                   DueDate.Equals(other.DueDate) &&
                   RedemptionDate.Equals(other.RedemptionDate) &&
                   Equals(Items, other.Items) &&
                   Equals(Payments, other.Payments) &&
                   Equals(Supplier, other.Supplier) &&
                   Equals(Receiver, other.Receiver);
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
            return obj.GetType() == GetType() && Equals((Invoice) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ IssueDate.GetHashCode();
                hashCode = (hashCode * 397) ^ DueDate.GetHashCode();
                hashCode = (hashCode * 397) ^ RedemptionDate.GetHashCode();
                hashCode = (hashCode * 397) ^ (Items != null ? Items.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Payments != null ? Payments.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Supplier != null ? Supplier.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Receiver != null ? Receiver.GetHashCode() : 0);

                return hashCode;
            }
        }

        public static Invoice Create(
            DateTime issueDate,
            DateTime dueDate,
            List<InvoiceItem> items,
            List<InvoicePayment> payments,
            EntitySupplier supplier,
            EntityReceiver reciever
        )
        {
            return new Invoice(null, issueDate, dueDate, null, items, payments, supplier, reciever);
        }

    }

}
