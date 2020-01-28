using Core.Application.Address;
using Core.Application.BillingInfo;
using Core.Application.ContactInfo;
using Core.Application.Entity.Receiver;
using Core.Application.Entity.Supplier;
using Core.Application.Invoice;
using Core.Application.Item;
using Core.Application.Payment;

namespace Infrastructure
{
    public interface IAppContext
    {
        IAddressService AddressService { get; }
        IBillingInfoService BillingInfoService { get; }
        IContactInfoService ContactInfoService { get; }
        IEntitySupplierService SupplierService { get; }
        IEntityReceiverService ReceiverService { get; }
        IInvoiceItemService ItemService { get; }
        IInvoicePaymentService PaymentService { get; }
        IInvoiceService InvoiceService { get; }
    }
}