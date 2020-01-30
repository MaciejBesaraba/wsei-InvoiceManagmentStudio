using System.Collections.Generic;
using System.Linq;
using Core.Application.ContactInfo;
using Core.Domain;
using Core.Domain.ContactInfo;

namespace Service.ContactInfo
{
    public class ContactInfoService : IContactInfoService
    {
        private readonly IContactInfoRepository _repository;

        public ContactInfoService(IContactInfoRepository repository)
        {
            _repository = repository;
        }

        public List<ContactInfoDto> GetAll() => _repository.FindAll().Select(ContactInfoDto.FromDomain).ToList();

        public ContactInfoDto GetById(IObjectIdentifier<ulong> id) => ContactInfoDto.FromDomain(_repository.FindById(id));
        
        public ContactInfoDto Create(ContactInfoDto entity)
        {
            throw new System.NotImplementedException();
        }

        public ContactInfoDto Delete(IObjectIdentifier<ulong> id)
        {
            var contactInfo = _repository.FindById(id);
            _repository.Delete(contactInfo.Id);
            return ContactInfoDto.FromDomain(contactInfo);
        }

        public ContactInfoDto Delete(ContactInfoDto contactInfo)
        {
            _repository.Delete(contactInfo.Id);
            return contactInfo;
        }
    }
}
