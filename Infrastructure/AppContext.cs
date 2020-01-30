using Core.Application.Address;
using Core.Application.BillingInfo;
using Core.Application.ContactInfo;
using Core.Application.Entity.Receiver;
using Core.Application.Entity.Supplier;
using Core.Application.Invoice;
using Core.Application.Item;
using Core.Application.Payment;
using Repository;
using Repository.Address;
using Repository.BillingInfo;
using Repository.ContactInfo;
using Repository.Entity.Receiver;
using Repository.Entity.Supplier;
using Repository.Invoice;
using Repository.Item;
using Repository.Payment;
using Service.Address;
using Service.BillingInfo;
using Service.ContactInfo;
using Service.Entity.Receiver;
using Service.Entity.Supplier;
using Service.Invoice;
using Service.Item;
using Service.Payment;

namespace Infrastructure
{
    public class AppContext : IAppContext
    {
        private readonly IAppProfile _appProfile;

        private readonly IDataSourceConfig _dataSourceConfig;

        private readonly IAddressRepository _addressRepository;
        private readonly IBillingInfoRepository _billingInfoRepository;
        private readonly IContactInfoRepository _contactInfoRepository;
        private readonly IEntitySupplierRepository _supplierRepository;
        private readonly IEntityReceiverRepository _receiverRepository;
        private readonly IInvoiceItemRepository _itemRepository;
        private readonly IInvoicePaymentRepository _paymentRepository;
        private readonly IInvoiceRepository _invoiceRepository;

        private readonly IAddressService _addressService;
        private readonly IBillingInfoService _billingInfoService;
        private readonly IContactInfoService _contactInfoService;
        private readonly IEntitySupplierService _supplierService;
        private readonly IEntityReceiverService _receiverService;
        private readonly IInvoiceItemService _itemService;
        private readonly IInvoicePaymentService _paymentService;
        private readonly IInvoiceService _invoiceService;
        
        public IAddressService AddressService => _addressService;

        public IBillingInfoService BillingInfoService => _billingInfoService;

        public IContactInfoService ContactInfoService => _contactInfoService;

        public IEntitySupplierService SupplierService => _supplierService;

        public IEntityReceiverService ReceiverService => _receiverService;

        public IInvoiceItemService ItemService => _itemService;

        public IInvoicePaymentService PaymentService => _paymentService;

        public IInvoiceService InvoiceService => _invoiceService;

        public AppContext()
        {
            _appProfile = AppProfile.FromConfig();
            
            _dataSourceConfig = new DataSourceConfig(
                _appProfile.DataSource,
                _appProfile.Database,
                _appProfile.Username,
                _appProfile.Password
            );
                
            _addressRepository = new AddressRepository(_dataSourceConfig);
            _billingInfoRepository = new BillingInfoRepository(_dataSourceConfig, _addressRepository);
            _contactInfoRepository = new ContactInfoRepository(_dataSourceConfig);
            _supplierRepository = new SupplierRepository(_dataSourceConfig,_billingInfoRepository, _contactInfoRepository);
            _receiverRepository = new ReceiverRepository(_dataSourceConfig,_billingInfoRepository, _contactInfoRepository);
            _itemRepository = new InvoiceItemRepository(_dataSourceConfig);
            _paymentRepository = new InvoicePaymentRepository(_dataSourceConfig);
            _invoiceRepository = new InvoiceRepository(_dataSourceConfig, _supplierRepository, _receiverRepository, _itemRepository, _paymentRepository
            );
            
            _addressService = new AddressService(_addressRepository);
            _billingInfoService = new BillingInfoService(_billingInfoRepository);
            _contactInfoService = new ContactInfoService(_contactInfoRepository);
            _supplierService = new SupplierService(_supplierRepository);
            _receiverService = new ReceiverService(_receiverRepository);
            _itemService = new InvoiceItemService(_itemRepository);
            _paymentService = new InvoicePaymentService(_paymentRepository);
            _invoiceService = new InvoiceService(_invoiceRepository);
        }
    }
}
