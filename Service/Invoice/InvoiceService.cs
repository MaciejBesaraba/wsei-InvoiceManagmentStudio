using System;
using System.Collections.Generic;
using System.Linq;
using Core.Application.Entity.Receiver;
using Core.Application.Entity.Supplier;
using Core.Application.Invoice;
using Core.Domain;
using Core.Domain.Invoice;
using Core.Domain.Item;
using Core.Domain.Payment;

namespace Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _repository;
        public InvoiceService(IInvoiceRepository repository)
        {
            _repository = repository;
        }

        public List<InvoiceDto> GetAll() => _repository.FindAll().Select(InvoiceDto.FromDomain).ToList();

        public InvoiceDto GetById(IObjectIdentifier<ulong> id) => InvoiceDto.FromDomain(_repository.FindById(id));

        // TODO validation
        // TODO command ddd
        // TODO item prototype
        public InvoiceDto Create(InvoiceDto invoiceDto)
        {
            return InvoiceDto.FromDomain(_repository.Save(Invoice.Create(
                invoiceDto.IssueDate,
                invoiceDto.DueDate,
                invoiceDto.Items.Select(itemDto => InvoiceItem.Create(
                    itemDto.Name,
                    itemDto.UnitPrice,
                    itemDto.UnitType,
                    itemDto.Discount,
                    itemDto.Quantity)
                ).ToList(),
                invoiceDto.Payments.Select(paymentDto => InvoicePayment.Create(
                    paymentDto.Type,
                    paymentDto.Date,
                    paymentDto.TimeZone,
                    paymentDto.Amount)
                ).ToList(),
                // TODO exist ? get : create
                _supplierService.Create(invoiceDto.Supplier).ToDomain(),
                _receiverRepository.Create(invoiceDto.Receiver).ToDomain()
            )));
        }

        public InvoiceDto Delete(IObjectIdentifier<ulong> id)
        {
            var invoice = _repository.FindById(id);
            return InvoiceDto.FromDomain(_repository.Delete(invoice));
        }

        public InvoiceDto Delete(InvoiceDto invoiceDto) =>  Delete(invoiceDto.Id);
    }
}
