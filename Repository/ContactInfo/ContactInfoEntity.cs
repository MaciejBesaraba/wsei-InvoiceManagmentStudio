using System;
using System.Data;
using Core.Domain;
using Core.Domain.Entity;
using ContactInfoDomain = Core.Domain.ContactInfo.ContactInfo;

namespace Repository.ContactInfo
{
    public class ContactInfoEntity
    {
        public ulong? Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public ContactInfoEntity(
            ulong id,
            string email,
            string phone,
            string mobile,
            string title,
            string gender,
            string name,
            string surname
        )
        {
            Id = id;
            Email = email;
            Phone = phone;
            Mobile = mobile;
            Title = title;
            Gender = gender;
            Name = name;
            Surname = surname;
        }

        public ContactInfoDomain ToDomain()
        {
            return new Core.Domain.ContactInfo.ContactInfo(
                new SimpleObjectIdentifier(Id ?? throw new DataException("Address Id is null")),
                Email,
                Phone,
                Mobile,
                Title,
                (EGender)Enum.Parse(typeof(EGender), Gender),
                Name,
                Surname
            );
        }

        public static ContactInfoEntity FromDomain(ContactInfoDomain domain)
        {
            return new ContactInfoEntity(
                domain.Id.Value,
                domain.Email,
                domain.Phone,
                domain.Mobile,
                domain.Title,
                domain.Gender.ToString(),
                domain.Name,
                domain.Surname
            );
        }
    }
}