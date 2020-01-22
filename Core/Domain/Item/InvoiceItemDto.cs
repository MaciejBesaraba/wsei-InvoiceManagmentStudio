using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Core.Domain.Entity.Receiver;
using Core.Domain.Entity.Supplier;
using Core.Domain.Item;
using Core.Domain.Payment;

namespace Core.Domain.Item
{

    public class InvoiceItemDto : IInvoiceItemDefinition, IEquatable<InvoiceItemDto>
    {

        private readonly IObjectIdentifier<ulong> _id;
        private readonly string _name;
        private readonly decimal _unitPrice;
        private readonly EUnitType _unitType;
        private readonly decimal _discount;
        private readonly double _quantity;
        //add backing fields

        public IObjectIdentifier<ulong> Id => _id;
        public string Name => _name;
        public decimal UnitPrice => _unitPrice;
        public EUnitType UnitType => _unitType;
        public decimal Discount => _discount;
        public double Quantity => _quantity;
        //add properties with get only

        private InvoiceItemDto(
            IObjectIdentifier<ulong> id,
            string name,
            decimal unitPrice,
            EUnitType unitType,
            decimal discount,
            double quantity
            //add private constructor
        )
        {
            _id = id;
            _name = name;
            _unitPrice = unitPrice;
            _unitType = unitType;
            _discount = discount;
            _quantity = quantity;

        }

        public decimal Total => UnitPrice * (decimal)Quantity;

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

        public bool Equals(InvoiceItemDto other)
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
            return obj.GetType() == this.GetType() && Equals((InvoiceItemDto)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_name != null ? _name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_unitPrice != null ? _unitPrice.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_unitType != null ? _unitType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_discount != null ? _discount.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_quantity != null ? _quantity.GetHashCode() : 0);

                return hashCode;
            }
        }

        public static InvoiceItemDto FromDomain(InvoiceItem invoiceItem)
        {
            return new InvoiceItemDto(
                invoiceItem.Id,
                invoiceItem.Name,
                invoiceItem.UnitPrice,
                invoiceItem.UnitType,
                invoiceItem.Discount,
                invoiceItem.Quantity
            );
        }

    }

}
