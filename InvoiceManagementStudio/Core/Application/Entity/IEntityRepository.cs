using InvoiceManagementStudio.Core.Domain;
using InvoiceManagementStudio.Core.Domain.Entity;

namespace InvoiceManagementStudio.Core.Application.Entity
{

    public interface IEntityRepository : ICrudRepository<ulong, IEntityDefinition>
    {
        
    }

}
