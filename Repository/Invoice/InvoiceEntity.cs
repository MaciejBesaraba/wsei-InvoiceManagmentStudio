using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Core.Domain;
using Core.Domain.Entity.Receiver;
using Core.Domain.Entity.Supplier;
using Core.Domain.Item;
using Core.Domain.Payment;
using InvoiceDomain = Core.Domain.Invoice.Invoice;

namespace Repository.Invoice
{
    public class InvoiceEntity
    {
        public ulong? Id { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? RedemptionDate { get; set; }
        public List<ulong> ItemsRefs { get; set; }
        public List<ulong> PaymentsRefs { get; set; }
        public ulong SupplierRef { get; set; }
        public ulong ReceiverRef { get; set; }
        
        public InvoiceEntity(
            ulong? id,
            DateTime issueDate,
            DateTime dueDate,
            DateTime? redemptionDate,
            ulong supplierRef,
            ulong receiverRef
        )
        {
            Id = id;
            IssueDate = issueDate;
            DueDate = dueDate;
            RedemptionDate = redemptionDate;
            ItemsRefs = new List<ulong>();
            PaymentsRefs = new List<ulong>();
            SupplierRef = supplierRef;
            ReceiverRef = receiverRef;
        }

        public InvoiceEntity(
            ulong? id,
            DateTime issueDate,
            DateTime dueDate,
            DateTime? redemptionDate,
            List<ulong> itemsRefs,
            List<ulong> paymentsRefs,
            ulong supplierRef,
            ulong receiverRef
        )
        {
            Id = id;
            IssueDate = issueDate;
            DueDate = dueDate;
            RedemptionDate = redemptionDate;
            ItemsRefs = itemsRefs;
            PaymentsRefs = paymentsRefs;
            SupplierRef = supplierRef;
            ReceiverRef = receiverRef;
        }

        public InvoiceDomain ToDomain(
            List<InvoiceItem> items,
            List<InvoicePayment> payments,
            EntitySupplier supplier,
            EntityReceiver receiver
        )
        {
            return new InvoiceDomain(
                new SimpleObjectIdentifier(Id ?? throw new DataException("InvoiceEntity Id is null")),
                IssueDate,
                DueDate,
                RedemptionDate,
                items,
                payments,
                supplier,
                receiver
            );
        }

        public static InvoiceEntity FromDomain(InvoiceDomain domain)
        {
            return new InvoiceEntity(
                domain.Id.Value,
                domain.IssueDate,
                domain.DueDate,
                domain.RedemptionDate,
                domain.Items.Select(item => item.Id.Value).ToList(),
                domain.Payments.Select(payment => payment.Id.Value).ToList(),
                domain.Supplier.Id.Value,
                domain.Receiver.Id.Value
            );
        }
    }
}
