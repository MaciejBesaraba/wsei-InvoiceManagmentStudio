using Core.Domain.Address;

namespace Core.Application.Address
{

    public interface IAddressRepository: ICrudRepository<ulong, IAddressDefinition>
    {
        
    }

}
