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
            string name,
            decimal unitPrice,
            EUnitType unitType,
            decimal discount,
            double quantity
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
