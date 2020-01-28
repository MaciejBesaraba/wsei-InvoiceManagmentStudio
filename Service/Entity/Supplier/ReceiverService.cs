using System.Collections.Generic;
using System.Linq;
using Core.Application.Entity.Receiver;
using Core.Domain;
using Core.Domain.Entity.Receiver;

namespace Service.Entity.Supplier
{
    public class ReceiverService : IEntityReceiverService
    {
        private readonly IEntityReceiverRepository _repository;

        public ReceiverService(IEntityReceiverRepository repository)
        {
            _repository = repository;
        }

        public List<EntityReceiverDto> GetAll() => _repository.FindAll().Select(EntityReceiverDto.FromDomain).ToList();

        public EntityReceiverDto GetById(IObjectIdentifier<ulong> id) => EntityReceiverDto.FromDomain(_repository.FindById(id));

        public EntityReceiverDto Create(EntityReceiverDto entity)
        {
            throw new System.NotImplementedException();
        }

        public EntityReceiverDto Delete(IObjectIdentifier<ulong> id)
        {
            var receiver = _repository.FindById(id);
            _repository.Delete(receiver.Id);
            return EntityReceiverDto.FromDomain(receiver);
        }

        public EntityReceiverDto Delete(EntityReceiverDto receiver)
        {
            _repository.Delete(receiver.Id);
            return receiver;
        }
    }
}
