using System.Collections.Generic;
using System.Linq;
using Core.Application.Payment;
using Core.Domain;
using Core.Domain.Exception;
using Core.Domain.Payment;
using Repository.Address;
using Repository.Payment.Command;

namespace Repository.Payment
{
    public class InvoicePaymentRepository : IInvoicePaymentRepository
    {
        private readonly IDataSourceConfig _dataSource;

        public InvoicePaymentRepository(IDataSourceConfig dataSource)
        {
            _dataSource = dataSource;
        }


        public List<InvoicePayment> FindAll()
        {
            var command = new InvoicePaymentFindAllCommand(_dataSource);
            return command.Execute().Select(entity => entity.ToDomain()).ToList();
        }

        public InvoicePayment FindById(IObjectIdentifier<ulong> id)
        {
            var command = new InvoicePaymentFindByIdCommand(_dataSource, id.Value);
            var entity = command.Execute() ?? throw new ResourceNotFoundException(typeof(InvoicePaymentEntity), id);

            return entity.ToDomain();
        }

        public InvoicePayment Save(InvoicePayment domain)
        {
            var entity = InvoicePaymentEntity.FromDomain(domain);
            var command = new InvoicePaymentSaveCommand(_dataSource, entity);
            entity = command.Execute();

            return entity.ToDomain();
        }

        public void Delete(IObjectIdentifier<ulong> id)
        {
            var command = new InvoicePaymentDeleteCommand(_dataSource, id.Value);
            if (!command.Execute())
            {
                throw new ResourceNotFoundException(typeof(AddressEntity), id);
            }
        }

        public InvoicePayment Delete(InvoicePayment domain)
        {
            Delete(domain.Id);
            return domain;
        }
    }
}
