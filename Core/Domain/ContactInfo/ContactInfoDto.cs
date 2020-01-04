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

        public IObjectIdentifier<ulong> Id => _id;
        public string Email => _email;
        public string Phone => _phone;
        public string Mobile => _mobile;
        public string Title => _title;
        public ESex Sex => _sex;
        public string Name => _name;
        public string Surname => _surname;


        private ContactInfoDto(
            IObjectIdentifier<ulong> id,
            string email,
            string phone,
            string mobile,
            string title,
            ESex sex,
            string name,
            string surname
        )
        {
            _id = id;
            _email = email;
            _phone = phone;
            _mobile = mobile;
            _title = title;
            _sex = sex;
            _name = name;
            _surname = surname;
        }

    }    

}