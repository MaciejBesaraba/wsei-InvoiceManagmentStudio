using System.Collections.Generic;
using Core.Application.Entity.Receiver;
using Core.Application.Entity.Supplier;
using Core.Application.Invoice;
using Core.Application.Item;
using Core.Application.Payment;
using Core.Domain;

namespace Repository.Invoice
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IDataSourceConfig _dataSource;
        private readonly IEntitySupplierRepository _supplierRepository;
        private readonly IEntityReceiverRepository _receiverRepository;
        private readonly IInvoiceItemRepository _itemRepository;
        private readonly IInvoicePaymentRepository _paymentRepository;

        public InvoiceRepository(
            IDataSourceConfig dataSource,
            IEntitySupplierRepository supplierRepository,
            IEntityReceiverRepository receiverRepository,
            IInvoiceItemRepository itemRepository,
            IInvoicePaymentRepository paymentRepository
        )
        {
            _dataSource = dataSource;
            _supplierRepository = supplierRepository;
            _receiverRepository = receiverRepository;
            _itemRepository = itemRepository;
            _paymentRepository = paymentRepository;
        }

        public List<Core.Domain.Invoice.Invoice> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Core.Domain.Invoice.Invoice FindById(IObjectIdentifier<ulong> id)
        {
            throw new System.NotImplementedException();
        }

        public Core.Domain.Invoice.Invoice Save(Core.Domain.Invoice.Invoice entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(IObjectIdentifier<ulong> id)
        {
            throw new System.NotImplementedException();
        }

        public Core.Domain.Invoice.Invoice Delete(Core.Domain.Invoice.Invoice entity)
        {
            throw new System.NotImplementedException();
        }
    }
}