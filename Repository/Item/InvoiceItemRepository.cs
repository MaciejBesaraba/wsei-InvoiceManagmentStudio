using System.Collections.Generic;
using System.Linq;
using Core.Application.Item;
using Core.Domain;
using Core.Domain.Exception;
using Core.Domain.Item;
using Repository.Address;
using Repository.Item.Command;

namespace Repository.Item
{
    public class InvoiceItemRepository : IInvoiceItemRepository
    {
        private readonly IDataSourceConfig _dataSource;

        public InvoiceItemRepository(IDataSourceConfig dataSource)
        {
            _dataSource = dataSource;
        }


        public List<InvoiceItem> FindAll()
        {
            var command = new InvoiceItemFindAllCommand(_dataSource);
            return command.Execute().Select(entity => entity.ToDomain()).ToList();
        }

        public InvoiceItem FindById(IObjectIdentifier<ulong> id)
        {
            var command = new InvoiceItemFindByIdCommand(_dataSource, id.Value);
            var entity = command.Execute() ?? throw new ResourceNotFoundException(typeof(InvoiceItemEntity), id);

            return entity.ToDomain();
        }

        public InvoiceItem Save(InvoiceItem domain)
        {
            var entity = InvoiceItemEntity.FromDomain(domain);
            var command = new InvoiceItemSaveCommand(_dataSource, entity);
            entity = command.Execute();

            return entity.ToDomain();
        }

        public void Delete(IObjectIdentifier<ulong> id)
        {
            var command = new InvoiceItemDeleteCommand(_dataSource, id.Value);
            if (!command.Execute())
            {
                throw new ResourceNotFoundException(typeof(AddressEntity), id);
            }
        }

        public InvoiceItem Delete(InvoiceItem domain)
        {
            Delete(domain.Id);
            return domain;
        }
    }
}
