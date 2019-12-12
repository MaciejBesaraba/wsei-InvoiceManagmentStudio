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

    public class InvoiceItem : IInvoiceItemDefinition, IEquatable<InvoiceItem>
    {
        public IObjectIdentifier<ulong> Id { get; }
        public string Name { get; }
        public decimal UnitPrice { get; }
        public EUnitType UnitType { get; }
        public decimal Discount { get; }
        public double Quantity { get; }

        public InvoiceItem(
            IObjectIdentifier<ulong> id,
            string name,
            decimal unitPrice,
            EUnitType unitType,
            decimal discount,
            double quantity
        )
        {
            Id = id;
            Name = name;
            UnitPrice = unitPrice;
            UnitType = unitType;
            Discount = discount;
            Quantity = quantity;

        }

        public decimal Total => UnitPrice * Quantity;

        public decimal Subtotal => Total - Discount;
             
                

        public override string ToString()
        {            
            return "InvoiceItem(" +
                       $"id={Id}, " +
                       $"name={Name.ToString()}, " +
                       $"unitPrice={UnitPrice.ToString(CultureInfo.InvariantCulture)}, " +
                       $"unitType={UnitType}, " +
                       $"discount={Discount.ToString(CultureInfo.InvariantCulture)}, " +
                       $"subtotal={Subtotal.ToString(CultureInfo.InvariantCulture)}, " +
                       $"total={Total.ToString(CultureInfo.InvariantCulture)}, " +
                       $"quantity={Quantity.ToString()}, " +
                   ")";
        }

        public bool Equals(InvoiceItem other)
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
                   Equals(Name, other.Name) &&
                   Equals(UnitPrice, other.UnitPrice) &&
                   Equals(UnitType, other.UnitType) &&
                   Equals(Discount, other.Discount) &&
                   Equals(Quantity, other.Quantity);
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

            return obj.GetType() == GetType() && Equals((InvoiceItem)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (UnitPrice != null ? UnitPrice.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (UnitType != null ? UnitType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Discount != null ? Discount.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Quantity != null ? Quantity.GetHashCode() : 0);

                return hashCode;
            }
        }

    }

}

