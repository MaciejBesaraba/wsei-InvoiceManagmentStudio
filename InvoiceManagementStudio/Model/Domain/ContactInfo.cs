using System;
using InvoiceManagementStudio.Core.Definition;
using InvoiceManagementStudio.Core.Definition.ContactInfo;
using InvoiceManagementStudio.Core.Definition.Entity;



namespace InvoiceManagementStudio.Model.Domain
{

    public class ContactInfo : IContactInfoDefinition, IEquatable<ContactInfo>
    {
        public IObjectIdentifier<ulong> Id { get; }
        public string Email { get; }
        public string Phone { get; }
        public string Mobile { get; }
        public string Title { get; }
        public ESex Sex { get; }
        public string Name { get; }
        public string Surname { get; }


        public ContactInfo(
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
            Id = id;
            Email = email;
            Phone = phone;
            Mobile = mobile;
            Title = title;
            Sex = sex;
            Name = name;
            Surname = surname;


        }

        public override string ToString()
        {
            return "ContactInfo(" +
                       $"id={Id}, " +
                       $"email={Email.ToString()}, " +
                       $"phone={Phone.ToString()}, " +
                       $"mobile={Mobile.ToString()}, " +
                       $"title={Title.ToString()}, " +
                       $"sex={Sex}, " +
                       $"name={Name.ToString()}, " +
                       $"surname={Surname.ToString()}, " +
                   ")";
        }

        public bool Equals(ContactInfo other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(Id, other.Id) &&
                   Equals(Email, other.Email) &&
                   Equals(Phone, other.Phone) &&
                   Equals(Mobile, other.Mobile) &&
                   Equals(Title, other.Title) &&
                   Equals(Sex, other.Sex) &&
                   Equals(Name, other.Name) &&
                   Equals(Surname, other.Surname);

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

            return obj.GetType() == GetType() && Equals((ContactInfo)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Email != null ? Email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Phone != null ? Phone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Mobile != null ? Mobile.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Sex != null ? Sex.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Surname != null ? Surname.GetHashCode() : 0);

                return hashCode;
            }
        }

    }

}
