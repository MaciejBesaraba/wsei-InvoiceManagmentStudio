using Core.Domain.Invoice;

namespace InvoiceManagementStudio.ViewModel
{
    public class InvoiceHeaderViewModel
    {
        private const string DateFormat = "dddd, dd MMMM yyyy";

        private readonly InvoiceDto _invoice;

        public InvoiceHeaderViewModel(InvoiceDto invoice)
        {
            _invoice = invoice;
        }

        public string Title => _invoice.Serial;
        public string Issued => _invoice.IssueDate.ToString(DateFormat);
        public string Due => _invoice.DueDate.ToString(DateFormat);
        public string Redemption => _invoice.RedemptionDate?.ToString(DateFormat);
    }
}
