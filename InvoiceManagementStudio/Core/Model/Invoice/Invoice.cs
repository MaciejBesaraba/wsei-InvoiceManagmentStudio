using System;
using System.Collections.Generic;
using InvoiceManagementStudio.Core.Definition;
using InvoiceManagementStudio.Core.Definition.Entity;
using InvoiceManagementStudio.Core.Definition.Invoice;


namespace InvoiceManagementStudio.Core.Model.Invoice
{

    public class Invoice : IInvoiceDefinition
    {
        private readonly IObjectIdentifier<ulong> id;
        private readonly DateTime issueDate;
        private readonly DateTime dueDate;
        private readonly DateTime? redemptionDate;
        private readonly bool isPayed;
        private readonly decimal payed;
        private readonly List<IInvoiceItemDefinition> items;
        private readonly List<IInvoicePaymentDefinition> payments;
        private readonly IEntitySupplierDefinition supplier;
        private readonly IEntityReceiverDefinition receiver;

        public IObjectIdentifier<ulong> Id => id;

        public DateTime IssueDate => issueDate;

        public DateTime DueDate => dueDate;

        public DateTime? RedemptionDate => redemptionDate;

        public decimal Payed => payed;
        
        public List<IInvoiceItemDefinition> Items => items;

        public List<IInvoicePaymentDefinition> Payments => payments;

        public IEntitySupplierDefinition Supplier => supplier;

        public IEntityReceiverDefinition Receiver => receiver;
        
    }

}
