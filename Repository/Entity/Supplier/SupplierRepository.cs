using System.Collections.Generic;
using Core.Application.Entity.Supplier;
using Core.Domain;
using Core.Domain.Entity.Supplier;
using Repository.BillingInfo;
using Repository.ContactInfo;

namespace Repository.Entity.Supplier
{
    public class SupplierRepository : IEntitySupplierRepository
    {
        private readonly DataSourceConfig _dataSource;
        private readonly BillingInfoRepository _billingInfoRepository;
        private readonly ContactInfoRepository _contactInfoRepository;
        
        public SupplierRepository(
            DataSourceConfig dataSource,
            BillingInfoRepository billingInfoRepository,
            ContactInfoRepository contactInfoRepository
        )
        {
            _dataSource = dataSource;
            _billingInfoRepository = billingInfoRepository;
            _contactInfoRepository = contactInfoRepository;
        }
        
        
        public List<EntitySupplier> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public EntitySupplier FindById(IObjectIdentifier<ulong> id)
        {
            throw new System.NotImplementedException();
        }

        public EntitySupplier Save(EntitySupplier entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(IObjectIdentifier<ulong> id)
        {
            throw new System.NotImplementedException();
        }

        public EntitySupplier Delete(EntitySupplier entity)
        {
            throw new System.NotImplementedException();
        }
    }
}