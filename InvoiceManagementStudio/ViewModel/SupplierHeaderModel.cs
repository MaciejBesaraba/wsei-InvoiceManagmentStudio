using System.Linq;
using Core.Domain.Entity.Supplier;
using Core.Domain.Invoice;

namespace InvoiceManagementStudio.ViewModel
{
    public class SupplierHeaderViewModel
    {
        private static readonly string[] CompanyTypes = {" Sp. z o.o.", " s.c."};

        private readonly EntitySupplierDto _supplier;

        public SupplierHeaderViewModel(EntitySupplierDto supplier)
        {
            _supplier = supplier;
        }

        private static string FormatLogo(string companyName)
        {
            return CompanyTypes.Aggregate(companyName, (current, companyType) => current.Replace(companyType, ""));
        }

        // TODO store logo
        public string Logo => FormatLogo(_supplier.BillingInfo.CompanyName);
        public string Name => _supplier.BillingInfo.CompanyName;
        public string Zip => _supplier.BillingInfo.ZipCode;
    }
}
