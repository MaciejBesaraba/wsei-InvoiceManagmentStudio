using System.Collections.Generic;
using System.Linq;
using Core.Application.Entity.Receiver;
using Core.Domain;
using ReceiverDomain = Core.Domain.Entity.Receiver.EntityReceiver;
using Core.Domain.Exception;
using Repository.BillingInfo;
using Repository.ContactInfo;
using Repository.Entity.Receiver.Command;

namespace Repository.Entity.Receiver
{
    public class ReceiverRepository : IEntityReceiverRepository
    {
        private readonly IDataSourceConfig _dataSource;
        private readonly BillingInfoRepository _billingInfoRepository;
        private readonly ContactInfoRepository _contactInfoRepository;

        public ReceiverRepository(
            IDataSourceConfig dataSource,
            BillingInfoRepository billingInfoRepository,
            ContactInfoRepository contactInfoRepository
        )
        {
            _dataSource = dataSource;
            _billingInfoRepository = billingInfoRepository;
            _contactInfoRepository = contactInfoRepository;
        }


        public List<ReceiverDomain> FindAll()
        {
            var command = new ReceiverFindAllCommand(_dataSource);
            return command.Execute().Select(Aggreagate).ToList();
        }

        public ReceiverDomain FindById(IObjectIdentifier<ulong> id)
        {
            var command = new ReceiverFIndByIdCommand(_dataSource, id.Value);
            var entity = command.Execute() ?? throw new ResourceNotFoundException(typeof(ReceiverEntity), id);

            return Aggreagate(entity);
        }

        public ReceiverDomain Save(ReceiverDomain domain)
        {
            var entity = ReceiverEntity.FromDomain(domain);
            var command = new ReceiverSaveCommand(_dataSource, entity);
            entity = command.Execute();

            return Aggreagate(entity);
        }

        public void Delete(IObjectIdentifier<ulong> id)
        {
            var command = new ReceiverDeleteCommand(_dataSource, id.Value);
            if (!command.Execute())
            {
                throw new ResourceNotFoundException(typeof(ReceiverEntity), id);
            }
        }

        public ReceiverDomain Delete(ReceiverDomain domain)
        {
            Delete(domain.Id);
            return domain;
        }

        private ReceiverDomain Aggreagate(ReceiverEntity entity)
        {
            return entity.ToDomain(
                _billingInfoRepository.FindById(new SimpleObjectIdentifier(entity.BillingInfoRef)),
                _contactInfoRepository.FindById(new SimpleObjectIdentifier(entity.ContactInfoRef))
            );
        }
    }
}
