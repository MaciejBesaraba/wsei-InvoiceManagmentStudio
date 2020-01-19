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
    public class InvoiceDto : IInvoiceDefinition, IEquatable<InvoiceDto>
    {
        private readonly IObjectIdentifier<ulong> _id;
        private readonly DateTime _issueDate;
        private readonly DateTime _dueDate;
        private readonly DateTime? _redemptionDate;
        private readonly List<IInvoiceItemDefinition> _items;
        private readonly List<IInvoicePaymentDefinition> _payments;
        private readonly IEntitySupplierDefinition _supplier;
        private readonly IEntityReceiverDefinition _reciever;

        public IObjectIdentifier<ulong> Id => _id;
        public DateTime IssueDate => _issueDate;
        public DateTime DueDate => _dueDate;
        public DateTime? RedemptionDate => _redemptionDate;
        public List<IInvoiceItemDefinition> Items => _items;
        public List<IInvoicePaymentDefinition> Payments => _payments;
        public IEntitySupplierDefinition Supplier => _supplier;
        public IEntityReceiverDefinition Receiver => _reciever;


        private InvoiceDto(
            IObjectIdentifier<ulong> id,
            DateTime issueDate,
            DateTime dueDate,
            DateTime? redemptionDate,
            List<IInvoiceItemDefinition> items,
            List<IInvoicePaymentDefinition> payments,
            IEntitySupplierDefinition supplier,
            IEntityReceiverDefinition reciever
        )
        {
            _id = id;
            _issueDate = issueDate;
            _dueDate = dueDate;
            _redemptionDate = redemptionDate;
            _items = items;
            _payments = payments;
            _supplier = supplier;
            _reciever = reciever;
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

        public bool Equals(InvoiceDto other)
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
            return obj.GetType() == this.GetType() && Equals((InvoiceDto)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_id != null ? _id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_issueDate != null ? _issueDate.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_dueDate != null ? _dueDate.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_redemptionDate != null ? _redemptionDate.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_items != null ? _items.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_payments != null ? _payments.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_supplier != null ? _supplier.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_reciever != null ? _reciever.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static InvoiceDto FromDomain(Invoice invoice)
        {
            return new InvoiceDto(
                invoice.Id,
                invoice.IssueDate,
                invoice.DueDate,
                invoice.RedemptionDate,
                invoice.Items,
                invoice.Payments,
                invoice.Supplier,
                invoice.Receiver
            );
        }
    }
}
