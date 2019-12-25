using System;


namespace Core.Domain.Address
{
    public class AddressDto : IAddressDefinition, IEquatable<AddressDto>
    {
        private readonly IObjectIdentifier<ulong> _id;
        private readonly string _country;
        private readonly string _city;
        private readonly string _street;
        private readonly string _state;
        private readonly string _buildingNumber;
        private readonly string _flatNumber;

        public IObjectIdentifier<ulong> Id => _id;
        public string Country => _country;
        public string City => _city;
        public string Street => _street;
        public string State => _state;
        public string BuildingNumber => _buildingNumber;
        public string FlatNumber => _flatNumber;


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
            _id = id;
            _country = country;
            _city = city;
            _street = street;
            _state = state;
            _buildingNumber = buildingNumber;
            _flatNumber = flatNumber;
        }

        public override string ToString()
        {
            return "AddressDto(" +
                   $"id={Id}, " +
                   $"country={Country}, " +
                   $"city={City}, " +
                   $"street={Street}, " +
                   $"state={State}, " +
                   $"buildingNumber={BuildingNumber}, " +
                   $"flatNumber={FlatNumber}, " +
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
            return Equals(_id, other._id) &&
                   string.Equals(_country, other._country) &&
                   string.Equals(_city, other._city) &&
                   string.Equals(_street, other._street) &&
                   string.Equals(_state, other._state) &&
                   string.Equals(_buildingNumber, other._buildingNumber) &&
                   string.Equals(_flatNumber, other._flatNumber);
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
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((AddressDto) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_id != null ? _id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_country != null ? _country.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_city != null ? _city.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_street != null ? _street.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_state != null ? _state.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_buildingNumber != null ? _buildingNumber.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_flatNumber != null ? _flatNumber.GetHashCode() : 0);
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