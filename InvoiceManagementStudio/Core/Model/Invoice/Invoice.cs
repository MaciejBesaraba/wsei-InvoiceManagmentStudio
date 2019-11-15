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

        private readonly IObjectIdentifier<ulong> id;
        private readonly DateTime issueDate;
        private readonly DateTime dueDate;
        private readonly DateTime? redemptionDate;
        private readonly List<IInvoiceItemDefinition> items;
        private readonly List<IInvoicePaymentDefinition> payments;
        private readonly IEntitySupplierDefinition supplier;
        private readonly IEntityReceiverDefinition receiver;


        public IObjectIdentifier<ulong> Id => id;

        public DateTime IssueDate => issueDate;

        public DateTime DueDate => dueDate;

        public DateTime? RedemptionDate => redemptionDate;

        public List<IInvoiceItemDefinition> Items => items;

        public List<IInvoicePaymentDefinition> Payments => payments;

        public IEntitySupplierDefinition Supplier => supplier;

        public IEntityReceiverDefinition Receiver => receiver;


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
            this.id = id;
            this.issueDate = issueDate;
            this.dueDate = dueDate;
            this.redemptionDate = redemptionDate;
            this.items = items;
            this.payments = payments;
            this.supplier = supplier;
            this.receiver = receiver;
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
            // TODO ArBy global culture
            // TODO ArBy datetime format
            return "Invoice(" +
                       $"serial={Serial}, " +
                       $"id={Id}, " +
                       $"isPayed={IsPayed.ToString()}, " +
                       $"issueDate={IssueDate:yyyy-MM-dd}, " +
                       $"dueDate={DueDate:yyyy-MM-dd}, " +
                       $"redemptionDate={RedemptionDate:yyyy-MM-dd}, " +
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
        

        #endregion

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
            return Equals(id, other.id) &&
                   issueDate.Equals(other.issueDate) &&
                   dueDate.Equals(other.dueDate) &&
                   redemptionDate.Equals(other.redemptionDate) &&
                   Equals(items, other.items) &&
                   Equals(payments, other.payments) &&
                   Equals(supplier, other.supplier) &&
                   Equals(receiver, other.receiver);
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
                var hashCode = (id != null ? id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ issueDate.GetHashCode();
                hashCode = (hashCode * 397) ^ dueDate.GetHashCode();
                hashCode = (hashCode * 397) ^ redemptionDate.GetHashCode();
                hashCode = (hashCode * 397) ^ (items != null ? items.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (payments != null ? payments.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (supplier != null ? supplier.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (receiver != null ? receiver.GetHashCode() : 0);
                return hashCode;
            }
        }
    }

}
