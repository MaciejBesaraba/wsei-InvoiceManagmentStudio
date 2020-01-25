using Core.Domain.Entity;

namespace Core.Application.Entity
{

    public interface IEntityRepository : ICrudRepository<ulong, IEntityDefinition>
    {
        
    }

}
