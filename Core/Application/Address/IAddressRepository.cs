namespace Core.Application.Address
{

    public interface IAddressRepository: ICrudRepository<ulong, Domain.Address.Address>
    {
        
    }

}
