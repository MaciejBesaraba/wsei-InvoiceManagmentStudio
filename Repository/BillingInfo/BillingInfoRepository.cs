using System.Collections.Generic;
using System.Linq;
using Core.Application.BillingInfo;
using Core.Domain;
using Core.Domain.Exception;
using Repository.Address;
using Repository.BillingInfo.Command;
using BillingInfoDomain = Core.Domain.BillingInfo.BillingInfo;
using ContactInfoDomain = Core.Domain.ContactInfo.ContactInfo;

namespace Repository.BillingInfo
{
    public class BillingInfoRepository : IBillingInfoRepository
    {
        private readonly IDataSourceConfig _dataSource;
        private readonly AddressRepository _addressRepository;
        
        public BillingInfoRepository(IDataSourceConfig dataSource, AddressRepository addressRepository)
        {
            _dataSource = dataSource;
            _addressRepository = addressRepository;
        }
        
        public List<BillingInfoDomain> FindAll()
        {
            var command = new BillingInfoFindAllCommand(_dataSource);
            return command.Execute().Select(Aggreagate).ToList();
        }

        public BillingInfoDomain FindById(IObjectIdentifier<ulong> id)
        {
            var command = new BillingInfoFIndByIdCommand(_dataSource, id.Value);
            var entity = command.Execute() ?? throw new ResourceNotFoundException(typeof(BillingInfoEntity), id);

            return Aggreagate(entity);
        }

        public BillingInfoDomain Save(BillingInfoDomain domain)
        {
            var entity = BillingInfoEntity.FromDomain(domain);
            var command = new BillingInfoSaveCommand(_dataSource, entity);
            entity = command.Execute();

            return Aggreagate(entity);
        }

        public void Delete(IObjectIdentifier<ulong> id)
        {
            var command = new BillingInfoDeleteCommand(_dataSource, id.Value);
            if (!command.Execute())
            {
                throw new ResourceNotFoundException(typeof(BillingInfoEntity), id);
            }
        }

        public BillingInfoDomain Delete(BillingInfoDomain domain)
        {
            Delete(domain.Id);
            return domain;
        }

        private BillingInfoDomain Aggreagate(BillingInfoEntity entity)
        {
            return entity.ToDomain(_addressRepository.FindById(new SimpleObjectIdentifier(entity.BillingAddressRef)));
        }
    }
}
