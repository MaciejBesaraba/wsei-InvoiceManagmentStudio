using System.Collections.Generic;
using System.Linq;
using Core.Application.Invoice;
using Core.Domain;
using Core.Domain.Invoice;

namespace Service.Invoice
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

        public InvoiceDto Create(InvoiceDto invoiceDto)
        {
            throw new System.NotImplementedException();
        }

        public InvoiceDto Delete(IObjectIdentifier<ulong> id)
        {
            var invoice = _repository.FindById(id);
            return InvoiceDto.FromDomain(_repository.Delete(invoice));
        }

        public InvoiceDto Delete(InvoiceDto invoiceDto) => Delete(invoiceDto.Id);
    }
}
