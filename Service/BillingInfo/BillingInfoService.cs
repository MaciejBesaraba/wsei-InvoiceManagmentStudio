using System.Collections.Generic;
using System.Linq;
using Core.Application.BillingInfo;
using Core.Domain;
using Core.Domain.BillingInfo;

namespace Service.BillingInfo
{
    public class BillingInfoService : IBillingInfoService
    {
        private readonly IBillingInfoRepository _repository;

        public BillingInfoService(IBillingInfoRepository repository)
        {
            _repository = repository;
        }

        public List<BillingInfoDto> GetAll() => _repository.FindAll().Select(BillingInfoDto.FromDomain).ToList();

        public BillingInfoDto GetById(IObjectIdentifier<ulong> id) => BillingInfoDto.FromDomain(_repository.FindById(id));

        public BillingInfoDto Create(BillingInfoDto entity)
        {
            throw new System.NotImplementedException();
        }

        public BillingInfoDto Delete(IObjectIdentifier<ulong> id)
        {
            var billingInfo = _repository.FindById(id);
            _repository.Delete(billingInfo.Id);
            return BillingInfoDto.FromDomain(billingInfo);
        }

        public BillingInfoDto Delete(BillingInfoDto billingInfo)
        {
            _repository.Delete(billingInfo.Id);
            return billingInfo;
        }
    }
}
