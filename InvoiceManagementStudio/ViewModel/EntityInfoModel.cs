using Core.Domain.Entity;

namespace InvoiceManagementStudio.ViewModel
{
    public class EntityInfoViewModel
    {
        private readonly EntityDto _entity;

        private EntityInfoViewModel(EntityDto entity)
        {
            _entity = entity;
        }

        public string Name => _entity.BillingInfo.CompanyName;
        public string Zip => _entity.BillingInfo.ZipCode;
        public string Country => _entity.BillingInfo.BillingAddress.Country;
        public string City => _entity.BillingInfo.BillingAddress.City;
        public string Street => _entity.BillingInfo.BillingAddress.Street;
        public string State => _entity.BillingInfo.BillingAddress.State;
        public string BuildingNumber => _entity.BillingInfo.BillingAddress.BuildingNumber;
        public string FlatNumber => _entity.BillingInfo.BillingAddress.FlatNumber;
    }
}