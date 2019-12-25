using InvoiceManagementStudio.Core.Domain;
using InvoiceManagementStudio.Core.Domain.Entity.Receiver;

namespace InvoiceManagementStudio.Core.Application.Entity.Receiver
{

    public interface IEntityReceiverRepository: ICrudRepository<ulong, IEntityReceiverDefinition>
    {
        
    }

}
