using System.Collections.Generic;
using System.Linq;
using Core.Application.Address;
using Core.Domain;
using Core.Domain.Exception;
using Repository.Address.Command;

namespace Repository.Address
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataSourceConfig _dataSource;

        public AddressRepository(DataSourceConfig dataSource)
        {
            _dataSource = dataSource;
        }


        public List<Core.Domain.Address.Address> FindAll()
        {
            var command = new AddressFindAllCommand(_dataSource);
            return command.Execute().Select(entity => entity.ToDomain()).ToList();
        }

        public Core.Domain.Address.Address FindById(IObjectIdentifier<ulong> id)
        {
            var command = new AddressFindByIdCommand(_dataSource, id.Value);
            var entity = command.Execute() ?? throw new ResourceNotFoundException(typeof(AddressEntity), id);

            return entity.ToDomain();
        }

        public Core.Domain.Address.Address Save(Core.Domain.Address.Address address)
        {
            var entity = AddressEntity.FromDomain(address);
            var command = new AddressSaveCommand(_dataSource, entity);
            entity = command.Execute();

            return entity.ToDomain();
        }

        public void Delete(IObjectIdentifier<ulong> id)
        {
            var command = new AddressDeleteCommand(_dataSource, id.Value);
            if (!command.Execute())
            {
                throw new ResourceNotFoundException(typeof(AddressEntity), id);
            }
        }

        public Core.Domain.Address.Address Delete(Core.Domain.Address.Address address)
        {
            Delete(address.Id);
            return address;
        }
    }
}