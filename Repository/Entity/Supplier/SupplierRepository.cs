using System.Collections.Generic;
using System.Linq;
using Core.Application.Entity.Supplier;
using Core.Domain;
using Core.Domain.Exception;
using Repository.BillingInfo;
using Repository.ContactInfo;
using Repository.Entity.Supplier.Command;
using SupplierDomain = Core.Domain.Entity.Supplier.EntitySupplier;

namespace Repository.Entity.Supplier
{
    public class SupplierRepository : IEntitySupplierRepository
    {
        private readonly IDataSourceConfig _dataSource;
        private readonly BillingInfoRepository _billingInfoRepository;
        private readonly ContactInfoRepository _contactInfoRepository;
        
        public SupplierRepository(
            IDataSourceConfig dataSource,
            BillingInfoRepository billingInfoRepository,
            ContactInfoRepository contactInfoRepository
        )
        {
            _dataSource = dataSource;
            _billingInfoRepository = billingInfoRepository;
            _contactInfoRepository = contactInfoRepository;
        }
        
        
        public List<SupplierDomain> FindAll()
        {
            var command = new SupplierFindAllCommand(_dataSource);
            return command.Execute().Select(Aggreagate).ToList();
        }

        public SupplierDomain FindById(IObjectIdentifier<ulong> id)
        {
            var command = new SupplierFIndByIdCommand(_dataSource, id.Value);
            var entity = command.Execute() ?? throw new ResourceNotFoundException(typeof(SupplierEntity), id);

            return Aggreagate(entity);
        }

        public SupplierDomain Save(SupplierDomain domain)
        {
            var entity = SupplierEntity.FromDomain(domain);
            var command = new SupplierSaveCommand(_dataSource, entity);
            entity = command.Execute();

            return Aggreagate(entity);
        }

        public void Delete(IObjectIdentifier<ulong> id)
        {
            var command = new SupplierDeleteCommand(_dataSource, id.Value);
            if (!command.Execute())
            {
                throw new ResourceNotFoundException(typeof(SupplierEntity), id);
            }
        }

        public SupplierDomain Delete(SupplierDomain domain)
        {
            Delete(domain.Id);
            return domain;
        }

        private SupplierDomain Aggreagate(SupplierEntity entity)
        {
            return entity.ToDomain(
                _billingInfoRepository.FindById(new SimpleObjectIdentifier(entity.BillingInfoRef)),
                _contactInfoRepository.FindById(new SimpleObjectIdentifier(entity.ContactInfoRef))
            );
        }
    }
}
