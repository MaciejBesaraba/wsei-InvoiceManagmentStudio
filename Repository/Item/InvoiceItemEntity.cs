using System;
using System.Data;
using Core.Domain;
using Core.Domain.Item;

namespace Repository.Item
{
    public class InvoiceItemEntity
    {
        public ulong? Id { get; set; }
        public string Name { get; set;}
        public decimal UnitPrice { get; set; }
        public string UnitType { get; set; }
        public decimal Discount { get; set; }
        public double Quantity { get; set; }

        public InvoiceItemEntity(ulong? id, string name, decimal unitPrice, string unitType, decimal discount, double quantity)
        {
            Id = id;
            Name = name;
            UnitPrice = unitPrice;
            UnitType = unitType;
            Discount = discount;
            Quantity = quantity;
        }

        public InvoiceItem ToDomain()
        {
            return new InvoiceItem(
                new SimpleObjectIdentifier(Id ?? throw new DataException("InvoiceItem Id is null")),
                Name,
                UnitPrice,
                (EUnitType)Enum.Parse(typeof(EUnitType), UnitType),
                Discount,
                Quantity
            );
        }

        public static InvoiceItemEntity FromDomain(InvoiceItem domain)
        {
            return new InvoiceItemEntity(
                domain.Id.Value,
                domain.Name,
                domain.UnitPrice,
                domain.UnitType.ToString(),
                domain.Discount,
                domain.Quantity
            );
        }
    }
}
