using System.Collections.Generic;
using System.Linq;
using Core.Application.Item;
using Core.Domain;
using Core.Domain.Item;

namespace Service.Item
{
    public class InvoiceItemService : IInvoiceItemService
    {
        private readonly IInvoiceItemRepository _repository;

        public InvoiceItemService(IInvoiceItemRepository repository)
        {
            _repository = repository;
        }

        public List<InvoiceItemDto> GetAll() => _repository.FindAll().Select(InvoiceItemDto.FromDomain).ToList();

        public InvoiceItemDto GetById(IObjectIdentifier<ulong> id) => InvoiceItemDto.FromDomain(_repository.FindById(id));

        public InvoiceItemDto Create(InvoiceItemDto entity)
        {
            throw new System.NotImplementedException();
        }

        public InvoiceItemDto Delete(IObjectIdentifier<ulong> id)
        {
            var item = _repository.FindById(id);
            _repository.Delete(item.Id);
            return InvoiceItemDto.FromDomain(item);
        }

        public InvoiceItemDto Delete(InvoiceItemDto item)
        {
            _repository.Delete(item.Id);
            return item;
        }
        
        // TODO deleteByInvoiceId
        // TODO getAllByInvoiceId
    }
}
