using Core.Domain.Entity.Supplier;

namespace Core.Application.Entity.Supplier
{

    public interface IEntitySupplierRepository: ICrudRepository<ulong, IEntitySupplierDefinition>
    {
        
    }

}
