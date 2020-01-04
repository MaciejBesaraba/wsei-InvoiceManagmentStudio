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
        public string Email=> _email;
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

        public override string ToString()
        {
            return "ContactInfoDto(" +
                   $"id={Id}, " +
                   $"email={Email}, " +
                   $"phone={Phone}, " +
                   $"mobile={Mobile}, " +
                   $"title={Title}, " +
                   $"sex={Sex}, " +
                   $"name={Name}, " +
                   $"surname={Surname}, " +
                   ")";
        }

        public bool Equals(ContactInfoDto other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(_id, other._id) &&
                   string.Equals(_email, other._email) &&
                   string.Equals(_phone, other._phone) &&
                   string.Equals(_mobile, other._mobile) &&
                   string.Equals(_title, other._title) &&
                   string.Equals(_sex, other._sex) &&
                   string.Equals(_name, other._name) &&
                   string.Equals(_surname, other._surname);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((ContactInfoDto) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_id != null ? _id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_email != null ? _email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_phone != null ? _phone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_mobile != null ? _mobile.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_title != null ? _title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_sex != null ? _sex.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_name != null ? _name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_surname != null ? _surname.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static ContactInfoDto FromDomain(ContactInfo contactInfo)
        {
            return new ContactInfoDto(
                contactInfo.Id,
                contactInfo.Email,
                contactInfo.Phone,
                contactInfo.Mobile,
                contactInfo.Title,
                contactInfo.Sex,
                contactInfo.Name,
                contactInfo.Surname
            );
        }
    }

}