using System.Collections.Generic;
using System.Linq;
using Core.Application.Payment;
using Core.Domain;
using Core.Domain.Payment;

namespace Service.Payment
{
    public class InvoicePaymentService : IInvoicePaymentService
    {
        private readonly IInvoicePaymentRepository _repository;

        public InvoicePaymentService(IInvoicePaymentRepository repository)
        {
            _repository = repository;
        }

        public List<InvoicePaymentDto> GetAll() => _repository.FindAll().Select(InvoicePaymentDto.FromDomain).ToList();

        public InvoicePaymentDto GetById(IObjectIdentifier<ulong> id) => InvoicePaymentDto.FromDomain(_repository.FindById(id));
        
        public InvoicePaymentDto Create(InvoicePaymentDto entity)
        {
            throw new System.NotImplementedException();
        }

        public InvoicePaymentDto Delete(IObjectIdentifier<ulong> id)
        {
            var payment = _repository.FindById(id);
            _repository.Delete(payment.Id);
            return InvoicePaymentDto.FromDomain(payment);
        }

        public InvoicePaymentDto Delete(InvoicePaymentDto payment)
        {
            _repository.Delete(payment.Id);
            return payment;
        }
        
        
        // TODO deleteByInvoiceId
        // TODO getAllByInvoiceId
    }
}
