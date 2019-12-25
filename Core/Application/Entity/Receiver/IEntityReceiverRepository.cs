using Core.Domain.Entity.Receiver;

namespace Core.Application.Entity.Receiver
{

    public interface IEntityReceiverRepository: ICrudRepository<ulong, IEntityReceiverDefinition>
    {
        
    }

}
