using Core.Domain.Entity;

namespace Core.Application.Entity
{

    public interface IEntityService : ICrudService<ulong, IEntityDefinition>
    {
        
    }

}
