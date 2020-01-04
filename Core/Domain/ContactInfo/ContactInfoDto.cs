using System;
using Core.Domain.Entity;

namespace Core.Domain.ContactInfo
{
    public class ContactInfoDto : IContactInfoDefinition, IEquatable<ContactInfoDto>
    {
        private readonly IObjectIdentifier<ulong> _id;
        private readonly string _email;
        private readonly string _phone;
        private readonly string _mobile;
        private readonly string _title;
        private readonly ESex _sex;
        private readonly string _name;
        private readonly string _surname;

    }    

}