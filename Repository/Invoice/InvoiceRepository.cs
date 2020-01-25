using System.Collections.Generic;
using System.Linq;
using Core.Application.Entity.Receiver;
using Core.Application.Entity.Supplier;
using Core.Application.Invoice;
using Core.Application.Item;
using Core.Application.Payment;
using Core.Domain;
using Core.Domain.Exception;
using Repository.Invoice.Command;
using InvoiceDomain = Core.Domain.Invoice.Invoice;

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

        public List<InvoiceDomain> FindAll()
        {
            var command = new InvoiceFindAllCommand(_dataSource);
            var entity = command.Execute();
            return entity.Select(PrepareAggregate).ToList();
        }

        public InvoiceDomain FindById(IObjectIdentifier<ulong> id)
        {
            var command = new InvoiceFIndByIdCommand(_dataSource, id.Value);
            var entity = command.Execute() ?? throw new ResourceNotFoundException(typeof(InvoiceEntity), id);
            return PrepareAggregate(entity);
        }

        public InvoiceDomain Save(InvoiceDomain domain)
        {
            var entity = InvoiceEntity.FromDomain(domain);
            entity.ItemsRefs = domain.Items.Select(item => _itemRepository.Save(item))
                                           .Select(item => item.Id.Value)
                                           .ToList();
            
            entity.PaymentsRefs = domain.Payments.Select(payment => _paymentRepository.Save(payment))
                                                 .Select(payment => payment.Id.Value)
                                                 .ToList();
            
            entity.SupplierRef = _supplierRepository.Save(domain.Supplier).Id.Value;
            entity.ReceiverRef = _receiverRepository.Save(domain.Receiver).Id.Value;
            
            var command = new InvoiceSaveCommand(_dataSource, entity);
            entity = command.Execute();

            return PrepareAggregate(entity);
        }

        public void Delete(IObjectIdentifier<ulong> id)
        {
            var command = new InvoiceDeleteCommand(_dataSource, id.Value);
            if (!command.Execute())
            {
                throw new ResourceNotFoundException(typeof(InvoiceEntity), id);
            }
        }

        public InvoiceDomain Delete(InvoiceDomain domain)
        {
            Delete(domain.Id);
            return domain;
        }

        private void Populate(InvoiceEntity entity)
        {
            var itemCommand = new InvoiceFindAllItemsCommand(_dataSource);
            entity.ItemsRefs = itemCommand.Execute();

            var paymentsCommand = new InvoiceFindAllPaymentsCommand(_dataSource);
            entity.PaymentsRefs = paymentsCommand.Execute();
        }

        private InvoiceDomain Aggregate(InvoiceEntity entity)
        {
            return entity.ToDomain(
                entity.ItemsRefs.Select(item => _itemRepository.FindById(new SimpleObjectIdentifier(item))).ToList(),
                entity.PaymentsRefs.Select(payment => _paymentRepository.FindById(new SimpleObjectIdentifier(payment))).ToList(),
                _supplierRepository.FindById(new SimpleObjectIdentifier(entity.SupplierRef)),
                _receiverRepository.FindById(new SimpleObjectIdentifier(entity.ReceiverRef))
                
            );
        }

        private InvoiceDomain PrepareAggregate(InvoiceEntity entity)
        {
            Populate(entity);
            return Aggregate(entity);
        }
    }
}