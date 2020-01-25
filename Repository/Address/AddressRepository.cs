using System.Collections.Generic;
using System.Linq;
using Core.Application.Address;
using Core.Domain;
using Core.Domain.Exception;
using Repository.Address.Command;
using AddressDomain = Core.Domain.Address.Address;

namespace Repository.Address
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IDataSourceConfig _dataSource;

        public AddressRepository(IDataSourceConfig dataSource)
        {
            _dataSource = dataSource;
        }


        public List<AddressDomain> FindAll()
        {
            var command = new AddressFindAllCommand(_dataSource);
            return command.Execute().Select(entity => entity.ToDomain()).ToList();
        }

        public AddressDomain FindById(IObjectIdentifier<ulong> id)
        {
            var command = new AddressFindByIdCommand(_dataSource, id.Value);
            var entity = command.Execute() ?? throw new ResourceNotFoundException(typeof(AddressEntity), id);

            return entity.ToDomain();
        }

        public AddressDomain Save(AddressDomain address)
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

        public AddressDomain Delete(AddressDomain address)
        {
            Delete(address.Id);
            return address;
        }
    }
}