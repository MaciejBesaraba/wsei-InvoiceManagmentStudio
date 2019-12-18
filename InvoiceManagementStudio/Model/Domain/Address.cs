using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using InvoiceManagementStudio.Core.Definition;
using InvoiceManagementStudio.Core.Definition.Entity.Receiver;
using InvoiceManagementStudio.Core.Definition.Entity.Supplier;
using InvoiceManagementStudio.Core.Definition.Invoice;
using InvoiceManagementStudio.Core.Definition.Item;
using InvoiceManagementStudio.Core.Definition.Payment;


namespace InvoiceManagementStudio.Model.Domain
{

    public class Address : IAddressDefinition, IEquatable<Address>
    {
        public IObjectIdentifier<ulong> Id { get; }
        public string Country { get; }
        public string City { get; }
        public string Street { get; }
        public string State { get; }
        public string BuildingNumber { get; }
        public string FlatNumber { get; }

        public Address(
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
            return "Address(" +
                       $"id={Id}, " +
                       $"country={Country.ToString()}, " +
                       $"city={City.ToString()}, " +
                       $"street={Street.ToString()}, " +
                       $"state={State.ToString()}, " +
                       $"buildingNumber={BuildingNumber.ToString()}, " +
                       $"flatNumber={FlatNumber.ToString()}, " +
                   ")";
        }

        public bool Equals(Address other)
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

            return obj.GetType() == GetType() && Equals((Address)obj);
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

    }

}