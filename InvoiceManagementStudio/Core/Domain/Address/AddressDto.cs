using System;


namespace InvoiceManagementStudio.Core.Domain.Address
{
    public class AddressDto : IAddressDefinition, IEquatable<AddressDto>
    {
        public IObjectIdentifier<ulong> Id { get; }
        public string Country { get; }
        public string City { get; }
        public string Street { get; }
        public string State { get; }
        public string BuildingNumber { get; }
        public string FlatNumber { get; }

        private AddressDto(
            IObjectIdentifier<ulong> id,
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

        public override string ToString()
        {
            return "AddressDto(" +
                   $"id={Id}, " +
                   $"country={Country.ToString()}, " +
                   $"city={City.ToString()}, " +
                   $"street={Street.ToString()}, " +
                   $"state={State.ToString()}, " +
                   $"buildingNumber={BuildingNumber.ToString()}, " +
                   $"flatNumber={FlatNumber.ToString()}, " +
                   ")";
        }

        public bool Equals(AddressDto other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(Id, other.Id) &&
                   Equals(Country, other.Country) &&
                   Equals(City, other.City) &&
                   Equals(Street, other.Street) &&
                   Equals(State, other.State) &&
                   Equals(BuildingNumber, other.BuildingNumber) &&
                   Equals(FlatNumber, other.FlatNumber);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((Address) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Country != null ? Country.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (City != null ? City.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Street != null ? Street.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (State != null ? State.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BuildingNumber != null ? BuildingNumber.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FlatNumber != null ? FlatNumber.GetHashCode() : 0);

                return hashCode;
            }
        }

        public static AddressDto FromDomain(Address address)
        {
            return new AddressDto(
                address.Id,
                address.Country,
                address.City,
                address.Street,
                address.State,
                address.BuildingNumber,
                address.FlatNumber
            );
        }
    }

}