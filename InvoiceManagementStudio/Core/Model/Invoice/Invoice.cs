using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using InvoiceManagementStudio.Core.Definition;
using InvoiceManagementStudio.Core.Definition.Entity;
using InvoiceManagementStudio.Core.Definition.Invoice;


namespace InvoiceManagementStudio.Core.Model.Invoice
{

    public class Invoice : IInvoiceDefinition, IEquatable<Invoice>
    {
        #region class members

        private readonly IObjectIdentifier<ulong> _id;
        private readonly DateTime _issueDate;
        private readonly DateTime _dueDate;
        private readonly DateTime? _redemptionDate;
        private readonly List<IInvoiceItemDefinition> _items;
        private readonly List<IInvoicePaymentDefinition> _payments;
        private readonly IEntitySupplierDefinition _supplier;
        private readonly IEntityReceiverDefinition _receiver;


        public IObjectIdentifier<ulong> Id => _id;

        public DateTime IssueDate => _issueDate;

        public DateTime DueDate => _dueDate;

        public DateTime? RedemptionDate => _redemptionDate;

        public List<IInvoiceItemDefinition> Items => _items;

        public List<IInvoicePaymentDefinition> Payments => _payments;

        public IEntitySupplierDefinition Supplier => _supplier;

        public IEntityReceiverDefinition Receiver => _receiver;


        #endregion
        #region constructors


        public Invoice(
            IObjectIdentifier<ulong> id,
            DateTime issueDate,
            DateTime dueDate,
            DateTime? redemptionDate,
            List<IInvoiceItemDefinition> items,
            List<IInvoicePaymentDefinition> payments,
            IEntitySupplierDefinition supplier,
            IEntityReceiverDefinition receiver
        )
        {
            this._id = id;
            this._issueDate = issueDate;
            this._dueDate = dueDate;
            this._redemptionDate = redemptionDate;
            this._items = items;
            this._payments = payments;
            this._supplier = supplier;
            this._receiver = receiver;
        }


        #endregion
        #region properties


        public string Serial => $"FV/{IssueDate.Year.ToString()}/{Id}";

        public decimal Total => Items.Sum(item => item.Total);

        public decimal Subtotal => Items.Sum(item => item.Subtotal);

        public decimal Discount => Items.Sum(item => item.Discount);

        public decimal Payed => Payments.Sum(payment => payment.Amount);

        public decimal Due => Total - Payed;

        public bool IsPayed => Total >= Payed;


        #endregion
        #region operator overrides


        public override string ToString()
        {
            // TODO ArBy global culture, datetime format
            string formattedIssueDate = IssueDate.ToString("yyyy-MM-dd");
            string formattedDueDate = DueDate.ToString("yyyy-MM-dd");
            string formattedRedemptionDate = RedemptionDate != null ? RedemptionDate.Value.ToString("yyyy-MM-dd") : "n/a";

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
            return Equals(_id, other._id) &&
                   _issueDate.Equals(other._issueDate) &&
                   _dueDate.Equals(other._dueDate) &&
                   _redemptionDate.Equals(other._redemptionDate) &&
                   Equals(_items, other._items) &&
                   Equals(_payments, other._payments) &&
                   Equals(_supplier, other._supplier) &&
                   Equals(_receiver, other._receiver);
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
                var hashCode = (_id != null ? _id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _issueDate.GetHashCode();
                hashCode = (hashCode * 397) ^ _dueDate.GetHashCode();
                hashCode = (hashCode * 397) ^ _redemptionDate.GetHashCode();
                hashCode = (hashCode * 397) ^ (_items != null ? _items.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_payments != null ? _payments.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_supplier != null ? _supplier.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_receiver != null ? _receiver.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        #endregion
    }

}
