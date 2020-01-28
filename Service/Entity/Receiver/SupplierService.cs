using System.Collections.Generic;
using System.Linq;
using Core.Application.Entity.Supplier;
using Core.Domain;
using Core.Domain.Entity.Supplier;

namespace Service.Entity.Receiver
{
    public class SupplierService : IEntitySupplierService
    {
        private readonly IEntitySupplierRepository _repository;

        public SupplierService(IEntitySupplierRepository repository)
        {
            _repository = repository;
        }

        public List<EntitySupplierDto> GetAll() => _repository.FindAll().Select(EntitySupplierDto.FromDomain).ToList();

        public EntitySupplierDto GetById(IObjectIdentifier<ulong> id) => EntitySupplierDto.FromDomain(_repository.FindById(id));

        public EntitySupplierDto Create(EntitySupplierDto entity)
        {
            throw new System.NotImplementedException();
        }

        public EntitySupplierDto Delete(IObjectIdentifier<ulong> id)
        {
            var supplier = _repository.FindById(id);
            _repository.Delete(supplier.Id);
            return EntitySupplierDto.FromDomain(supplier);
        }

        public EntitySupplierDto Delete(EntitySupplierDto supplier)
        {
            _repository.Delete(supplier.Id);
            return supplier;
        }
    }
}

