using System.Collections.Generic;
using System.Linq;
using Core.Application.ContactInfo;
using Core.Domain;
using Core.Domain.Exception;
using Repository.ContactInfo.Command;
using ContactInfoDomain = Core.Domain.ContactInfo.ContactInfo;


namespace Repository.ContactInfo
{
    public class ContactInfoRepository : IContactInfoRepository
    {
        private readonly DataSourceConfig _dataSource;
        
        public ContactInfoRepository(DataSourceConfig dataSource)
        {
            _dataSource = dataSource;
        }

        public List<ContactInfoDomain> FindAll()
        {
            var command = new ContactInfoFindAllCommand(_dataSource);
            return command.Execute().Select(entity => entity.ToDomain()).ToList();
        }

        public ContactInfoDomain FindById(IObjectIdentifier<ulong> id)
        {
            var command = new ContactInfoFindByIdCommand(_dataSource, id.Value);
            var entity = command.Execute() ?? throw new ResourceNotFoundException(typeof(ContactInfoEntity), id);

            return entity.ToDomain();
        }

        public ContactInfoDomain Save(ContactInfoDomain domain)
        {
            var entity = ContactInfoEntity.FromDomain(domain);
            var command = new ContactInfoSaveCommand(_dataSource, entity);
            entity = command.Execute();

            return entity.ToDomain();
        }

        public void Delete(IObjectIdentifier<ulong> id)
        {
            var command = new ContactInfoDeleteCommand(_dataSource, id.Value);
            if (!command.Execute())
            {
                throw new ResourceNotFoundException(typeof(ContactInfoEntity), id);
            }
        }

        public ContactInfoDomain Delete(ContactInfoDomain domain)
        {
            Delete(domain.Id);
            return domain;
        }
    }
}
