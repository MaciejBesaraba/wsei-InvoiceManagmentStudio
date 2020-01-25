using System.Collections.Generic;
using Core.Application.Entity.Receiver;
using Core.Domain;
using Core.Domain.Entity.Receiver;
using Repository.BillingInfo;
using Repository.ContactInfo;

namespace Repository.Entity.Receiver
{
    public class ReceiverRepository : IEntityReceiverRepository
    {
        private readonly DataSourceConfig _dataSource;
        private readonly BillingInfoRepository _billingInfoRepository;
        private readonly ContactInfoRepository _contactInfoRepository;
        
        public ReceiverRepository(
            DataSourceConfig dataSource,
            BillingInfoRepository billingInfoRepository,
            ContactInfoRepository contactInfoRepository
        )
        {
            _dataSource = dataSource;
            _billingInfoRepository = billingInfoRepository;
            _contactInfoRepository = contactInfoRepository;
        }
        
        
        public List<EntityReceiver> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public EntityReceiver FindById(IObjectIdentifier<ulong> id)
        {
            throw new System.NotImplementedException();
        }

        public EntityReceiver Save(EntityReceiver entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(IObjectIdentifier<ulong> id)
        {
            throw new System.NotImplementedException();
        }

        public EntityReceiver Delete(EntityReceiver entity)
        {
            throw new System.NotImplementedException();
        }
    }
}