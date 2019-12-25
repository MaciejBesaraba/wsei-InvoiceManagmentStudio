using InvoiceManagementStudio.Core.Domain;
using InvoiceManagementStudio.Core.Domain.Entity.Supplier;

namespace InvoiceManagementStudio.Core.Application.Entity.Supplier
{

    public interface IEntitySupplierRepository: ICrudRepository<ulong, IEntitySupplierDefinition>
    {
        
    }

}
