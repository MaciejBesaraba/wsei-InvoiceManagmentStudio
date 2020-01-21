using System.Data;
using Core.Domain;

namespace Repository.Address
{
    public class AddressEntity
    {
        public ulong? Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set;}
        public string State { get; set; }
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }

        public AddressEntity(
            ulong id,
            string country,
            string city,
            string street,
            string state,
            string buildingNumber,
            string flatNumber
        )
        {
            Id = id;
            Country = country;
            City = city;
            Street = street;
            State = state;
            BuildingNumber = buildingNumber;
            FlatNumber = flatNumber;
        }
        
        public AddressEntity() { }

        public Core.Domain.Address.Address ToDomain()
        {
            return new Core.Domain.Address.Address(
                new SimpleObjectIdentifier(Id ?? throw new DataException("Address Id is null")),
                Country,
                City,
                Street,
                State,
                BuildingNumber,
                FlatNumber
            );
        }
        
        public static AddressEntity FromDomain(Core.Domain.Address.Address domain)
        {
            return new AddressEntity(
                domain.Id.Value,
                domain.Country,
                domain.City,
                domain.Street,
                domain.State,
                domain.BuildingNumber,
                domain.FlatNumber
            );
        }
    }
}
