using System.Collections.Generic;
using System.Linq;
using Core.Application.Address;
using Core.Domain;
using Core.Domain.Address;

namespace Service.Address
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repository;

        public AddressService(IAddressRepository repository)
        {
            _repository = repository;
        }

        public List<AddressDto> GetAll() => _repository.FindAll().Select(AddressDto.FromDomain).ToList();
        
        public AddressDto GetById(IObjectIdentifier<ulong> id) => AddressDto.FromDomain(_repository.FindById(id));

        public AddressDto Create(AddressDto entity)
        {
            throw new System.NotImplementedException();
        }

        public AddressDto Delete(IObjectIdentifier<ulong> id)
        {
            var address = _repository.FindById(id);
            _repository.Delete(address.Id);
            return AddressDto.FromDomain(address);
        }

        public AddressDto Delete(AddressDto address)
        {
            _repository.Delete(address.Id);
            return address;
        }
    }
}
