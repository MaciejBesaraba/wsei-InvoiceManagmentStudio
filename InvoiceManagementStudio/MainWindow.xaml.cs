using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Core.Domain;
using Core.Domain.Invoice;
using Infrastructure;
using AppContext = Infrastructure.AppContext;

namespace InvoiceManagementStudio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        
        private static readonly IAppContext AppContext = new AppContext();
        
        public MainWindow()
        {
//            var viewModel = new InvoiceHeaderViewModel(AppContext.InvoiceService.GetById(new SimpleObjectIdentifier(1L)));

            var viewModel = new InvoiceListViewModel(AppContext.InvoiceService.GetAll());
            DataContext = viewModel;

            InitializeComponent();
            
            // viewModel.FirstName = "Mark";
            // viewModel.OnPropertyChanged(nameof(ViewModel.FirstName));
        }
        
//        public class ViewModel : INotifyPropertyChanged
//        {
//            public event PropertyChangedEventHandler PropertyChanged;
//            
//            public string FirstName { get; set; }
//            
//            public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//
//        }

        public class InvoiceListViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            private readonly List<InvoiceDto> _invoices;

            public List<InvoiceHeaderViewModel> Invoices => _invoices.Select(invoice => new InvoiceHeaderViewModel(invoice)).ToList();

            public InvoiceListViewModel(List<InvoiceDto> invoices)
            {
                _invoices = invoices;
            }

            public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public class InvoiceHeaderViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            
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
            
            public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}